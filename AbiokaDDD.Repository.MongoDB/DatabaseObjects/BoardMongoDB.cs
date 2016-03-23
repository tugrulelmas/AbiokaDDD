using AbiokaDDD.Domain;
using AbiokaDDD.Infrastructure.Common.Domain;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace AbiokaDDD.Repository.MongoDB.DatabaseObjects
{
    [BsonIgnoreExtraElements]
    internal class BoardMongoDB : IdMongoEntity<Guid>
    {
        public string Name { get; set; }

        public IEnumerable<ListMongoDB> Lists { get; set; }

        public override IEntity ToDomainObject() {
            var result = new Board
            {
                Id = this.Id,
                Name = this.Name,
                Lists = Lists.ToLists()
            };
            return result;
        }

        public override void SetDefault() {
            foreach (var listItem in Lists)
            {
                listItem.SetDefault();
            }
        }
    }
}
