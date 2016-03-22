using AbiokaDDD.Domain;
using AbiokaDDD.Domain.Repositories;
using AbiokaDDD.Repository.MongoDB.DatabaseObjects;
using AbiokaDDD.Repository.MongoDB.Helper;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbiokaDDD.Repository.MongoDB.Repositories
{
    internal class BoardRepository : MongoDBRepository<Board, BoardMongoDB, Guid>, IBoardRepository
    {
        public BoardRepository(IMongoDBContext mongoDBContext, IPropertyHelper propertyHelper)
            : base(mongoDBContext, propertyHelper) {
        }

        public void AddCard(Guid boardId, Guid listId, Card card) {
            var cardMongoDB = card.ToCardMongoDB();
            cardMongoDB.SetDefault();
            var update = Builders<BoardMongoDB>.Update.Push(b => b.Lists.ElementAt(-1).Cards, cardMongoDB);
            Collection.UpdateOne(b => b.Id == boardId && b.Lists.Any(l => l.Id == listId), update);
            card.Id = cardMongoDB.Id;
        }

        public void AddList(Guid boardId, List list) {
            var listMongoDB = list.ToListMongoDB();
            listMongoDB.SetDefault();
            var update = Builders<BoardMongoDB>.Update.Push(b => b.Lists, listMongoDB);
            Collection.UpdateOne(b => b.Id == boardId, update);
            list.Id = listMongoDB.Id;
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
