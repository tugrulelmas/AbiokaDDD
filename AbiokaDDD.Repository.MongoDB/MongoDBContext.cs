using AbiokaDDD.Infrastructure.Common.ApplicationSettings;
using AbiokaDDD.Infrastructure.Common.IoC;
using AbiokaDDD.Repository.MongoDB.DatabaseObjects;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace AbiokaDDD.Repository.MongoDB
{
    internal class MongoDBContext : IMongoDBContext
    {
        private Lazy<IMongoDatabase> database { get; set; }
        private readonly IDictionary<RuntimeTypeHandle, string> collectionNames;

        public MongoDBContext() {
            collectionNames = new Dictionary<RuntimeTypeHandle, string>();
            collectionNames.Add(typeof(BoardMongoDB).TypeHandle, "board");
            collectionNames.Add(typeof(UserMongoDB).TypeHandle, "user");
            database = new Lazy<IMongoDatabase>(() => SetDatabase());
        }

        public IMongoCollection<T> GetCollection<T>() {
            var typeHandle = typeof(T).TypeHandle;
            if (!collectionNames.ContainsKey(typeHandle))
                throw new NotSupportedException(string.Format("{0} is not registered type in collection names.", typeof(T).Name));
            
            var collectionName = collectionNames[typeHandle];
            return database.Value.GetCollection<T>(collectionName);
        }

        private IMongoDatabase SetDatabase() {
            var connectionStringRepository = DependencyContainer.Container.Resolve<IConnectionStringRepository>();
            string connectionString = connectionStringRepository.ReadConnectionString(ConfigConst.ConnectionStringName);
            var client = new MongoClient(connectionString);
            var databaseName = connectionStringRepository.ReadAppSetting(ConfigConst.Database);

            return client.GetDatabase(databaseName);
        }
    }
}
