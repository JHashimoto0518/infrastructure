using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using JHashimoto.Infrastructure.Diagnostics;

namespace JHashimoto.Infrastructure.Extensions {
    public static class SystemReflectionPropertyInfoExtensions {
        public static T GetAttributeFromMetaData<T>(this PropertyInfo self) where T : Attribute {
            Guard.ArgumentNotNull<PropertyInfo>(self, "self", "nullに対してGetAttributeFromMetaDataを呼び出すことはできません。");            

            MetadataTypeAttribute metadataType = self.ReflectedType.GetCustomAttributes(typeof(MetadataTypeAttribute), false).Cast<MetadataTypeAttribute>().FirstOrDefault();
            if (metadataType == null)
                return null;

            PropertyInfo property = metadataType.MetadataClassType.GetProperty(self.Name);
            if (property == null)
                return null;

            return property.GetCustomAttributes(typeof(T), false).Cast<T>().FirstOrDefault();
        }
    }
}
