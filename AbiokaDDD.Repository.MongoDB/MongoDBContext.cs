using AbiokaDDD.Infrastructure.Common.ApplicationSettings;
using AbiokaDDD.Infrastructure.Common.IoC;
using AbiokaDDD.Repository.MongoDB.DatabaseObjects;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace AbiokaDDD.Repository.MongoDB
{
    internal class MongoDBContext
    {
        private IMongoDatabase database { get; set; }
        private static MongoDBContext mongoDBContext;


        private static readonly IDictionary<RuntimeTypeHandle, string> collectionNames;

        static MongoDBContext() {
            collectionNames = new Dictionary<RuntimeTypeHandle, string>();
            collectionNames.Add(typeof(BoardMongoDB).TypeHandle, "board");
        }

        private MongoDBContext() { }

        private static MongoDBContext Create() {
            if (mongoDBContext == null)
            {
                var connectionStringRepository = DependencyContainer.Container.Resolve<IConnectionStringRepository>();
                string connectionString = connectionStringRepository.ReadConnectionString(ConfigConst.ConnectionStringName);
                var client = new MongoClient(connectionString);
                var databaseName = connectionStringRepository.ReadAppSetting(ConfigConst.Database);
                mongoDBContext = new MongoDBContext
                {
                    database = client.GetDatabase(databaseName)
                };
            }
            return mongoDBContext;
        }

        public static IMongoCollection<T> GetCollection<T>() {
            var typeHandle = typeof(T).TypeHandle;
            if (!collectionNames.ContainsKey(typeHandle))
                throw new NotSupportedException(string.Format("{0} is not registered type in collection names.", typeof(T).Name));

            var context = Create();
            var collectionName = collectionNames[typeHandle];
            return context.database.GetCollection<T>(collectionName);
        }
    }
}
