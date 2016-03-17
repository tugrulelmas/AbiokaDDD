using AbiokaDDD.Infrastructure.Common.Domain;

namespace AbiokaDDD.Repository.MongoDB.DatabaseObjects
{
    internal abstract class IdMongoEntity<TId> : IIdMongoEntity<TId>
    {
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
