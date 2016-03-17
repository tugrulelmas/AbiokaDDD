using AbiokaDDD.Domain;
using AbiokaDDD.Infrastructure.Common.Domain;
using System;

namespace AbiokaDDD.Repository.MongoDB.DatabaseObjects
{
    public class BoardMongoDB : IdMongoEntity<Guid>
    {
        public string Name { get; set; }

        public override IEntity ToDomainObject() {
            var result = new Board
            {
                Id = this.Id,
                Name = this.Name
            };
            return result;
        }
    }

    public abstract class IdMongoEntity<TId> : IIdMongoEntity<TId>
    {
        public TId Id { get; set; }

        public abstract IEntity ToDomainObject();
    }

    public interface IIdMongoEntity<TId> : IMongoEntity
    {
        TId Id { get; set; }

        IEntity ToDomainObject();
    }

    public interface IMongoEntity
    {

    }
}
