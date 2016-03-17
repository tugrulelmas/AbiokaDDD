using AbiokaDDD.Repository.MongoDB.DatabaseObjects;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

namespace AbiokaDDD.Repository.MongoDB
{
    internal class Mapper
    {
        internal static void Map() {
            BsonClassMap.RegisterClassMap<BoardMongoDB>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(c => c.Id).SetIdGenerator(GuidGenerator.Instance);
            });
        }
    }
}
