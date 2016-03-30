using AbiokaDDD.Domain;
using AbiokaDDD.Infrastructure.Common.Domain;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace AbiokaDDD.Repository.MongoDB.DatabaseObjects
{
    [BsonIgnoreExtraElements]
    internal class BoardMongoDB : MongoEntity
    {
        public string Name { get; set; }

        public IEnumerable<ListMongoDB> Lists { get; set; }

        public override void CopyToDomainObject(IEntity entity) {
            if (entity == null)
                entity = new Board();

            var board = (Board)entity;
            board.Id = this.Id;
            board.Name = this.Name;
            board.Lists = Lists.ToLists();
        }

        public override void SetDefault() {
            if (Lists == null)
                return;

            foreach (var listItem in Lists)
            {
                listItem.SetDefault();
            }
        }
    }
}
