using MongoDB.Driver;

namespace AbiokaDDD.Repository.MongoDB
{
    internal interface IMongoDBContext
    {
        IMongoCollection<T> GetCollection<T>();
    }
}
