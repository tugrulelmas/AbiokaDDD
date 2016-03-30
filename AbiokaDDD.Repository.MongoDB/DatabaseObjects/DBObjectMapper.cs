using AbiokaDDD.Domain;
using AbiokaDDD.Infrastructure.Common.Domain;
using AbiokaDDD.Repository.MongoDB.DatabaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DDDTest.Repository.MongoDB.DatabaseObjects
{
    internal class DBObjectMapper
    {
        private static readonly IDictionary<RuntimeTypeHandle, Func<IEntity, IMongoEntity>> mapActions;

        static DBObjectMapper() {
            mapActions = new Dictionary<RuntimeTypeHandle, Func<IEntity, IMongoEntity>>();
            mapActions.Add(typeof(Board).TypeHandle, (entity) => ToBoardMongoDB((Board)entity));
        }

        internal static IMongoEntity FromDomainObject(IEntity entity) {
            var typeHandle = entity.GetType().TypeHandle;
            if (!mapActions.ContainsKey(typeHandle))
            {
                throw new NotImplementedException($"{entity.GetType().Name} is not implemented in MongoDB object mapper.");
            }
            return mapActions[typeHandle](entity);
        }

        private static BoardMongoDB ToBoardMongoDB(Board board) {
            var result = new BoardMongoDB
            {
                Id = board.Id,
                Name = board.Name,
                Lists = board.Lists?.ToListMongoDBs().ToList()
            };
            result.SetDefault();
            return result;
        }
    }
}
