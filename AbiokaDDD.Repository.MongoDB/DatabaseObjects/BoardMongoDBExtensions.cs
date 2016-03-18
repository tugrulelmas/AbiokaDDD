using AbiokaDDD.Domain;
using System.Collections.Generic;

namespace AbiokaDDD.Repository.MongoDB.DatabaseObjects
{
    internal static class BoardMongoDBExtensions
    {
        public static ListMongoDB ToListMongoDB(this List list) {
            if (list == null)
                return null;

            return new ListMongoDB
            {
                Id = list.Id,
                Name = list.Name
            };
        }

        public static IEnumerable<ListMongoDB> ToListMongoDBs(this IEnumerable<List> lists) {
            if (lists == null)
                yield break;

            foreach (var item in lists)
            {
                yield return item.ToListMongoDB();
            }
        }

        public static List ToList(this ListMongoDB list) {
            if (list == null)
                return null;

            return new List
            {
                Id = list.Id,
                Name = list.Name
            };
        }

        public static IEnumerable<List> ToLists(this IEnumerable<ListMongoDB> lists) {
            if (lists == null)
                yield break;

            foreach (var item in lists)
            {
                yield return item.ToList();
            }
        }
    }
}
