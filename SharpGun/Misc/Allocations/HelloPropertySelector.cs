using System;
using System.Linq;
using System.Reflection;
using Autofac.Core;

namespace SharpGun.Misc.Allocations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class HelloPropertyAttribute : Attribute
    {
    }

    public class HelloPropertySelector : IPropertySelector
    {
        public bool InjectProperty(PropertyInfo propertyInfo, object instance) {
            return propertyInfo.CustomAttributes
                .Any(it => it.AttributeType == typeof(HelloPropertyAttribute));
        }
    }
}
