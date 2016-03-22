﻿using AbiokaDDD.Domain;
using AbiokaDDD.Domain.Repositories;
using AbiokaDDD.Repository.MongoDB.DatabaseObjects;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace AbiokaDDD.Repository.MongoDB.Repositories
{
    internal class BoardRepository : MongoDBRepository<Board, BoardMongoDB, Guid>, IBoardRepository
    {
        public BoardRepository(IMongoDBContext mongoDBContext)
            : base(mongoDBContext) {
        }

        public void AddList(Guid boardId, List list) {
            if(list.Id == Guid.Empty)
            {
                list.Id = Guid.NewGuid();
            }

            var listMongoDB = list.ToListMongoDB();
            var update = Builders<BoardMongoDB>.Update.Push(b => b.Lists, listMongoDB);
            Collection.UpdateOne(b => b.Id == boardId, update);
        }

        public Board GetBoard(Guid id, bool includeList) {
            var query = Collection.Find(b => b.Id == id);
            if (!includeList)
            {
                query = query.Project<BoardMongoDB>(Builders<BoardMongoDB>.Projection.Exclude(b => b.Lists));
            }

            var board = query.FirstOrDefault();
            return (Board)board.ToDomainObject();
        }

        public IEnumerable<Board> GetBoards(bool includeList) {
            var query = Collection.Find(_ => true);
            if (!includeList)
            {
                query = query.Project<BoardMongoDB>(Builders<BoardMongoDB>.Projection.Exclude(b => b.Lists));
            }

            var list = query.ToList();

            foreach (var item in list)
            {
                yield return (Board)item.ToDomainObject();
            }
        }
    }
}
