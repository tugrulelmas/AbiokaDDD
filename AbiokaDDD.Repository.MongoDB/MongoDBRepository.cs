using AbiokaDDD.Infrastructure.Common.Domain;
using AbiokaDDD.Repository.MongoDB.DatabaseObjects;
using DDDTest.Repository.MongoDB.DatabaseObjects;
using MongoDB.Driver;
using System;

namespace AbiokaDDD.Repository.MongoDB
{
    internal abstract class MongoDBRepository<T, TDBObject, TId> : MongoDBReadOnlyRepository<T, TDBObject, TId>, IRepository<T>
        where TDBObject : IIdMongoEntity<TId>
        where T : IEntity
    {
        public MongoDBRepository(IMongoDBContext mongoDBContext)
            : base(mongoDBContext) {
        }

        public virtual void Add(T entity) {
            var dbObject = DBObjectMapper.FromDomainObject(entity);
            Collection.InsertOne((TDBObject)dbObject);

            if (entity is IIdEntity<TId>)
            {
                ((IIdEntity<TId>)entity).Id = ((TDBObject)dbObject).Id;
            }
        }

        public virtual void Delete(T entity) {
            var dbObject = (IIdMongoEntity<TId>)DBObjectMapper.FromDomainObject(entity);
            var filter = Builders<TDBObject>.Filter.Where(o => o.Id.Equals(dbObject.Id));
            Collection.DeleteOne(filter);
        }

        public virtual void Update(T entity) {
            var dbObject = (IIdMongoEntity<TId>)DBObjectMapper.FromDomainObject(entity);
            Collection.FindOneAndReplace(o => o.Id.Equals(dbObject.Id), (TDBObject)dbObject);
        }
    }
}
