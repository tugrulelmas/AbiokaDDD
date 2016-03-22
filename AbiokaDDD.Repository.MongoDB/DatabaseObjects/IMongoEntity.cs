using AbiokaDDD.Infrastructure.Common.Domain;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;

namespace AbiokaDDD.Repository.MongoDB.DatabaseObjects
{
    internal abstract class IdMongoEntity<TId> : IIdMongoEntity<TId>
    {
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        public TId Id { get; set; }

        public abstract IEntity ToDomainObject();

        public abstract void SetDefault();
    }

    internal interface IIdMongoEntity<TId> : IMongoEntity
    {
        TId Id { get; set; }

        IEntity ToDomainObject();
    }

    internal interface IMongoEntity
    {
        void SetDefault();
    }

    internal abstract class MongoValueObject : IMongoValueObject
    {
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        public Guid Id { get; set; }

        public void SetDefault() {
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
