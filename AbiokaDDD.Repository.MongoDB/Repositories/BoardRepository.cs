using AbiokaDDD.Domain;
using AbiokaDDD.Domain.Repositories;
using AbiokaDDD.Repository.MongoDB.DatabaseObjects;
using System;

namespace AbiokaDDD.Repository.MongoDB.Repositories
{
    internal class BoardRepository : MongoDBRepository<Board, BoardMongoDB, Guid>, IBoardRepository
    {
        public BoardRepository(IMongoDBContext mongoDBContext)
            : base(mongoDBContext) {
        }
    }
}
