using AbiokaDDD.Infrastructure.Common.Domain;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;

namespace AbiokaDDD.Repository.MongoDB.DatabaseObjects
{
    internal abstract class MongoEntity : IMongoEntity
    {
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        public Guid Id { get; set; }

        public abstract void CopyToDomainObject(IEntity entity);

        public abstract void SetDefault();
    }

    internal interface IMongoEntity
    {
        Guid Id { get; set; }
        void CopyToDomainObject(IEntity entity);
        void SetDefault();
    }

    internal abstract class MongoValueObject : IMongoValueObject
    {
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        public Guid Id { get; set; }

        public virtual void SetDefault() {
            if (Id == Guid.Empty)
            {
                Id = Guid.NewGuid();
            }
        }
    }

    internal interface IMongoValueObject
    {
        Guid Id { get; set; }

        void SetDefault();
    }
}
