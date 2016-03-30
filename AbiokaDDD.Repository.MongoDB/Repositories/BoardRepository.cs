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
            var update = Builders<BoardMongoDB>.Update.Push(b => b.Lists.ElementAt(-1).Cards, cardMongoDB);
            Collection.UpdateOne(b => b.Id == boardId && b.Lists.Any(l => l.Id == listId), update);
            card.Id = cardMongoDB.Id;
        }

        public void AddComment(Guid boardId, Guid listId, Guid cardId, Comment comment) {
            var commentMongoDB = comment.ToCommentMongoDB(cardId);
            var update = Builders<BoardMongoDB>.Update.Push(b => b.Lists.ElementAt(-1).Comments, commentMongoDB);
            Collection.UpdateOne(b => b.Id == boardId && b.Lists.Any(l => l.Id == listId), update);
            comment.Id = commentMongoDB.Id;
        }

        public void AddLabel(Guid boardId, Guid listId, Guid cardId, Label label) {
            var labelMongoDB = label.ToLabelMongoDB(cardId);
            var update = Builders<BoardMongoDB>.Update.Push(b => b.Lists.ElementAt(-1).Labels, labelMongoDB);
            Collection.UpdateOne(b => b.Id == boardId && b.Lists.Any(l => l.Id == listId), update);
            label.Id = labelMongoDB.Id;
        }

        public void AddList(Guid boardId, List list) {
            var listMongoDB = list.ToListMongoDB();
            var update = Builders<BoardMongoDB>.Update.Push(b => b.Lists, listMongoDB);
            Collection.UpdateOne(b => b.Id == boardId, update);
            list.Id = listMongoDB.Id;
        }

        public Board GetBoard(Guid id, bool includeList, bool includeComments) {
            var query = Collection.Find(b => b.Id == id);
            if (!includeList)
            {
                query = query.Project<BoardMongoDB>(Builders<BoardMongoDB>.Projection.Exclude(b => b.Lists));
            }
            if (!includeComments)
            {
                query = query.Project<BoardMongoDB>(Builders<BoardMongoDB>.Projection.Exclude("Lists.Comments"));
            }
            var board = query.FirstOrDefault();
            return (Board)board.ToDomainObject();
        }

        public IEnumerable<Board> GetBoards(bool includeList, bool includeComments) {
            var query = Collection.Find(_ => true);
            if (!includeList)
            {
                query = query.Project<BoardMongoDB>(Builders<BoardMongoDB>.Projection.Exclude(b => b.Lists));
            }
            if (!includeComments)
            {
                query = query.Project<BoardMongoDB>(Builders<BoardMongoDB>.Projection.Exclude("Lists.Comments"));
            }

            var list = query.ToList();

            foreach (var item in list)
            {
                yield return (Board)item.ToDomainObject();
            }
        }
    }
}
