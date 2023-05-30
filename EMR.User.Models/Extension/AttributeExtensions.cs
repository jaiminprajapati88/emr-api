using EMR.Data.Attributes;
using System.Reflection;

namespace EMR.Data.Extension
{
    public static class AttributeExtensions
    {
        public static PropertyInfo[] GetFilteredProperties(this PropertyInfo[] properties)
        {
            return properties.Where(pi => !Attribute.IsDefined(pi, typeof(SkipPropertyAttribute))).ToArray();
        }
    }
}
