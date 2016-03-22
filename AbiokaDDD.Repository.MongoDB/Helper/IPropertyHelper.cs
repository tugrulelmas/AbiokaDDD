using AbiokaDDD.Repository.MongoDB.DatabaseObjects;
using System.Collections.Generic;
using System.Reflection;

namespace AbiokaDDD.Repository.MongoDB.Helper
{
    internal interface IPropertyHelper
    {
        IEnumerable<PropertyInfo> GetUpdatableProperties<T>();
    }
}
