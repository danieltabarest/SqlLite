using System.Globalization;

namespace System
{
    public static class DecimalExtensions
    {
        public static string ToCurrency(this decimal value)
        {
            return value.ToString("C", new CultureInfo("en-us"));
        }
    }
}
