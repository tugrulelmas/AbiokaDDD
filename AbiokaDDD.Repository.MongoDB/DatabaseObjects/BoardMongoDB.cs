using AbiokaDDD.Domain;
using AbiokaDDD.Infrastructure.Common.Domain;
using System;

namespace AbiokaDDD.Repository.MongoDB.DatabaseObjects
{
    internal class BoardMongoDB : GuidMongoEntity
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
}
