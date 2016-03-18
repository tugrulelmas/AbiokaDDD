using AbiokaDDD.Infrastructure.Common.Domain;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace AbiokaDDD.Repository.MongoDB.DatabaseObjects
{
    internal abstract class GuidMongoEntity : IdMongoEntity<Guid>
    {

    }

    internal abstract class IdMongoEntity<TId> : IIdMongoEntity<TId>
    {
        [BsonId]
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
}
