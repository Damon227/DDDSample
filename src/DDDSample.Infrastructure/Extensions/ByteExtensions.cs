using System;
using System.Text;

namespace DDDSample.Infrastructure.Extensions
{
    public static class ByteExtensions
    {
        public static string ToPrintableString(this byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }

            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString().ToUpperInvariant();
        }
    }
}
