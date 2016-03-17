using AbiokaDDD.Domain;
using AbiokaDDD.Domain.Repositories;
using AbiokaDDD.Repository.MongoDB.DatabaseObjects;
using System;

namespace AbiokaDDD.Repository.MongoDB.Repositories
{
    public class BoardRepository : MongoDBRepository<Board, BoardMongoDB, Guid>, IBoardRepository
    {
    }
}
