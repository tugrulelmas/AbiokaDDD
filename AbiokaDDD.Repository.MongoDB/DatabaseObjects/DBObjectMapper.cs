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
            mapActions.Add(typeof(User).TypeHandle, (entity) => ToUserMongoDB((User)entity));
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

        private static UserMongoDB ToUserMongoDB(User user) {
            var result = new UserMongoDB
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                ProviderToken = user.ProviderToken,
                AuthProvider = user.AuthProvider.ToString(),
                Token = user.Token,
                ImageUrl = user.ImageUrl,
                Password = user.GetHashedPassword(),
                Initials = user.Initials,
            };
            result.SetDefault();
            return result;
        }
    }
}
