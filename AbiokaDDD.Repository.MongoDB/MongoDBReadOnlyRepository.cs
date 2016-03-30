using AbiokaDDD.Infrastructure.Common.Domain;
using AbiokaDDD.Repository.MongoDB.DatabaseObjects;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace AbiokaDDD.Repository.MongoDB
{
    internal abstract class MongoDBReadOnlyRepository<T, TDBObject> : IReadOnlyRepository<T>
        where TDBObject : IMongoEntity
        where T : IEntity
    {
        private readonly IMongoDBContext mongoDBContext;

        public MongoDBReadOnlyRepository(IMongoDBContext mongoDBContext) {
            this.mongoDBContext = mongoDBContext;
        }

        protected virtual T FindById(Guid id) {
            var mongoResult = Collection.Find(b => b.Id.Equals(id))
                .FirstOrDefault();
            if (mongoResult == null)
                return default(T);

            T result = default(T);
            mongoResult.CopyToDomainObject(result);
            return result;
        }

        public virtual IEnumerable<T> GetAll() {
            var list = Collection.Find(_ => true)
                .ToList();

            foreach (var item in list)
            {
                T result = default(T);
                item.CopyToDomainObject(result);
                yield return result;
            }
        }

        public virtual T FindById(object id) {
            return FindById((Guid)id);
        }

        protected IMongoCollection<TDBObject> Collection { get { return mongoDBContext.GetCollection<TDBObject>(); } }
    }
}
