using AbiokaDDD.Repository.MongoDB.DatabaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AbiokaDDD.Repository.MongoDB.Helper
{
    internal class PropertyHelper : IPropertyHelper
    {
        private readonly IDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>> updatableProperties;

        public PropertyHelper() {
            updatableProperties = new Dictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>>();

            var type = typeof(IMongoEntity);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && p.IsClass);

            foreach (var typeItem in types)
            {
                var properties = typeItem.GetProperties();
                SetUpdatableProperties(typeItem, properties);
            }
        }

        private void SetUpdatableProperties(Type type, IEnumerable<PropertyInfo> propertyInfos) {
            var properties = new List<PropertyInfo>();
            foreach (var propertyItem in propertyInfos)
            {
                if (propertyItem.PropertyType.GetInterfaces().Contains(typeof(IMongoValueObject))
                    || (propertyItem.PropertyType.IsGenericType && propertyItem.PropertyType.GetGenericArguments()[0].GetInterfaces().Contains(typeof(IMongoValueObject))))
                    continue;

                properties.Add(propertyItem);
            }
            updatableProperties.Add(type.TypeHandle, properties);
        }

        public IEnumerable<PropertyInfo> GetUpdatableProperties<T>() {
            return updatableProperties[typeof(T).TypeHandle];
        }
    }
}
