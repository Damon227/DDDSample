using System;

namespace DDDSample.Infrastructure.Extensions
{
    public static class GuidExtensions
    {
        public static string ToGuidString(this Guid value)
        {
            return value.ToString("N").ToUpperInvariant();
        }
    }
}
