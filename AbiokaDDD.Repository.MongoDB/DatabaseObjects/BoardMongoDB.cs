﻿using AbiokaDDD.Domain;
using AbiokaDDD.Infrastructure.Common.Domain;
using System;
using System.Collections.Generic;

namespace AbiokaDDD.Repository.MongoDB.DatabaseObjects
{
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
    }
}
