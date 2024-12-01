using System.Dynamic;

namespace MyVideoResume.Extensions
{
    public partial class Util
    {
        public static bool HasProperty(dynamic item, string propertyName)
        {
            if (item is ExpandoObject eo)
            {
                return (eo as IDictionary<string, object>).ContainsKey(propertyName);
            }
            else
            {
                return item.GetType().GetProperty(propertyName);
            }
        }

    }
}
