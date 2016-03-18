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
    }

    internal interface IIdMongoEntity<TId> : IMongoEntity
    {
        TId Id { get; set; }

        IEntity ToDomainObject();
    }

    internal interface IMongoEntity
    {

    }

    internal abstract class MongoValueObject : IMongoValueObject
    {
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        public Guid Id { get; set; }
    }

    internal interface IMongoValueObject
    {
        Guid Id { get; set; }
    }
}
