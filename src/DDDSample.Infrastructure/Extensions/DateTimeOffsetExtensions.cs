using System;

namespace DDDSample.Infrastructure.Extensions
{
    public static class DateTimeOffsetExtensions
    {
        public static DateTimeOffset ToChinaStandardTime(this DateTimeOffset dateTime)
        {
            if (dateTime == null)
            {
                throw new ArgumentNullException(nameof(dateTime));
            }

            dateTime = dateTime.ToUniversalTime().AddHours(8);
            return new DateTimeOffset(dateTime.DateTime, TimeSpan.FromHours(8));
        }
    }
}
