using AbiokaDDD.Infrastructure.Common;
using AbiokaDDD.Infrastructure.Common.ApplicationSettings;
using AbiokaDDD.Infrastructure.Common.Domain;
using AbiokaDDD.Repository.MongoDB.DatabaseObjects;
using MongoDB.Driver;
using System.Collections.Generic;

namespace AbiokaDDD.Repository.MongoDB
{
    public abstract class MongoDBReadOnlyRepository<T, TDBObject, TId> : IReadOnlyRepository<T>
        where TDBObject : IIdMongoEntity<TId>
        where T : IEntity
    {
        protected virtual T FindById(TId id) {
            var result = Collection.Find(b => b.Id.Equals(id))
                .FirstOrDefault();
            if (result == null)
                return default(T);

            return (T)result.ToDomainObject();
        }

        public virtual IEnumerable<T> GetAll() {
            var list = Collection.Find(_ => true)
                .ToList();

            foreach (var item in list)
            {
                yield return (T)item.ToDomainObject();
            }
        }

        public virtual T FindById(object id) {
            return FindById((TId)id);
        }

        protected IMongoCollection<TDBObject> Collection { get { return MongoDBContext.GetCollection<TDBObject>(); } }
    }
}
