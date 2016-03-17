using AbiokaDDD.Infrastructure.Common.Domain;
using AbiokaDDD.Repository.MongoDB.DatabaseObjects;
using DDDTest.Repository.MongoDB.DatabaseObjects;
using MongoDB.Driver;

namespace AbiokaDDD.Repository.MongoDB
{
    public abstract class MongoDBRepository<T, TDBObject, TId> : MongoDBReadOnlyRepository<T, TDBObject, TId>, IRepository<T>
        where TDBObject : IIdMongoEntity<TId>
        where T : IEntity
    {
        public virtual void Add(T entity) {
            var dbObject = DBObjectMapper.FromDomainObject(entity);
            Collection.InsertOne((TDBObject)dbObject);
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
