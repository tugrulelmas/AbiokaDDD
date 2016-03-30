using AbiokaDDD.Infrastructure.Common.Domain;
using AbiokaDDD.Repository.MongoDB.DatabaseObjects;
using AbiokaDDD.Repository.MongoDB.Helper;
using DDDTest.Repository.MongoDB.DatabaseObjects;
using MongoDB.Driver;
using System;

namespace AbiokaDDD.Repository.MongoDB
{
    internal abstract class MongoDBRepository<T, TDBObject> : MongoDBReadOnlyRepository<T, TDBObject>, IRepository<T>
        where TDBObject : IMongoEntity
        where T : IEntity
    {
        private readonly IPropertyHelper propertyHelper;

        public MongoDBRepository(IMongoDBContext mongoDBContext, IPropertyHelper propertyHelper)
            : base(mongoDBContext) {
            this.propertyHelper = propertyHelper;
        }

        public virtual void Add(T entity) {
            var dbObject = DBObjectMapper.FromDomainObject(entity);
            Collection.InsertOne((TDBObject)dbObject);
            dbObject.CopyToDomainObject(entity);
        }

        public virtual void Delete(T entity) {
            var dbObject = DBObjectMapper.FromDomainObject(entity);
            var filter = Builders<TDBObject>.Filter.Where(o => o.Id == dbObject.Id);
            Collection.DeleteOne(filter);
        }

        public virtual void Update(T entity) {
            var dbObject = DBObjectMapper.FromDomainObject(entity);
            var updatableProperties = propertyHelper.GetUpdatableProperties<TDBObject>();
            UpdateDefinition<TDBObject> updateBuilder = null;
            foreach (var propertyItem in updatableProperties)
            {
                updateBuilder = Builders<TDBObject>.Update.Set(propertyItem.Name, propertyItem.GetValue(dbObject));
            }

            Collection.UpdateOne(o => o.Id == dbObject.Id, updateBuilder);
        }
    }
}
