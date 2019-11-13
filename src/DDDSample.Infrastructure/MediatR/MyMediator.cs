using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DDDSample.Infrastructure.MediatR
{
    public class MyMediator : Mediator
    {
        private readonly Func<IEnumerable<Func<Task>>, Task> _publish;

        public MyMediator(ServiceFactory serviceFactory, Func<IEnumerable<Func<Task>>, Task> publish) : base(serviceFactory)
        {
            _publish = publish;
        }

        protected override Task PublishCore(IEnumerable<Func<Task>> allHandlers)
        {
            return _publish(allHandlers);
        }
    }
}
