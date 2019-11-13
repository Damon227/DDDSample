using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace DDDSample.Infrastructure.MediatR
{
    public class Publisher
    {
        public Publisher(ServiceFactory serviceFactory)
        {
            _publishStrategies[PublishStrategy.Async] = new MyMediator(serviceFactory, AsyncContinueOnException);
            _publishStrategies[PublishStrategy.ParallelNoWait] = new MyMediator(serviceFactory, ParallelNoWait);
            _publishStrategies[PublishStrategy.ParallelWhenAll] = new MyMediator(serviceFactory, ParallelWhenAll);
            _publishStrategies[PublishStrategy.ParallelWhenAny] = new MyMediator(serviceFactory, ParallelWhenAny);
            _publishStrategies[PublishStrategy.SyncContinueOnException] = new MyMediator(serviceFactory, SyncContinueOnException);
            _publishStrategies[PublishStrategy.SyncStopOnException] = new MyMediator(serviceFactory, SyncStopOnException);
        }

        public readonly IDictionary<PublishStrategy, IMediator> _publishStrategies = new Dictionary<PublishStrategy, IMediator>();
        public PublishStrategy DefaultStrategy { get; set; } = PublishStrategy.SyncContinueOnException;

        public Task Publish<TNotification>(TNotification notification)
        {
            return Publish(notification, DefaultStrategy, default(CancellationToken));
        }

        public Task Publish<TNotification>(TNotification notification, PublishStrategy strategy)
        {
            return Publish(notification, strategy, default(CancellationToken));
        }

        public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken)
        {
            return Publish(notification, DefaultStrategy, cancellationToken);
        }

        public Task Publish<TNotification>(TNotification notification, PublishStrategy strategy, CancellationToken cancellationToken)
        {
            if (!_publishStrategies.TryGetValue(strategy, out IMediator mediator))
            {
                throw new ArgumentException($"Unknown strategy: {strategy}");
            }

            return mediator.Publish(notification, cancellationToken);
        }

        private static Task ParallelWhenAll(IEnumerable<Func<Task>> handlers)
        {
            List<Task> tasks = new List<Task>();

            foreach (Func<Task> handler in handlers)
            {
                tasks.Add(Task.Run(() => handler()));
            }

            return Task.WhenAll(tasks);
        }

        private static Task ParallelWhenAny(IEnumerable<Func<Task>> handlers)
        {
            List<Task> tasks = new List<Task>();

            foreach (Func<Task> handler in handlers)
            {
                tasks.Add(Task.Run(() => handler()));
            }

            return Task.WhenAny(tasks);
        }

        private static Task ParallelNoWait(IEnumerable<Func<Task>> handlers)
        {
            foreach (Func<Task> handler in handlers)
            {
                Task.Run(() => handler());
            }

            return Task.CompletedTask;
        }

        private static async Task AsyncContinueOnException(IEnumerable<Func<Task>> handlers)
        {
            List<Task> tasks = new List<Task>();
            List<Exception> exceptions = new List<Exception>();

            foreach (Func<Task> handler in handlers)
            {
                try
                {
                    tasks.Add(handler());
                }
                catch (Exception ex) when (!(ex is OutOfMemoryException || ex is StackOverflowException))
                {
                    exceptions.Add(ex);
                }
            }

            try
            {
                await Task.WhenAll(tasks).ConfigureAwait(false);
            }
            catch (AggregateException ex)
            {
                exceptions.AddRange(ex.Flatten().InnerExceptions);
            }
            catch (Exception ex) when (!(ex is OutOfMemoryException || ex is StackOverflowException))
            {
                exceptions.Add(ex);
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }
        }

        private static async Task SyncStopOnException(IEnumerable<Func<Task>> handlers)
        {
            foreach (Func<Task> handler in handlers)
            {
                await handler().ConfigureAwait(false);
            }
        }

        private static async Task SyncContinueOnException(IEnumerable<Func<Task>> handlers)
        {
            List<Exception> exceptions = new List<Exception>();

            foreach (Func<Task> handler in handlers)
            {
                try
                {
                    await handler().ConfigureAwait(false);
                }
                catch (AggregateException ex)
                {
                    exceptions.AddRange(ex.Flatten().InnerExceptions);
                }
                catch (Exception ex) when (!(ex is OutOfMemoryException || ex is StackOverflowException))
                {
                    exceptions.Add(ex);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
