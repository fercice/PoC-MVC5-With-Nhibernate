namespace PoC.WebUI.Helpers
{
    using System.Collections.Generic;
    using System.Linq;

    public static class ExtensionMethods
    {
        public static bool AnySafe<T>(this IEnumerable<T> items)
        {
            return items != null && items.Any();
        }

        public static bool ContainsNumber(string value)
        {
            return value.Any(v => char.IsDigit(v));
        }
    }
}