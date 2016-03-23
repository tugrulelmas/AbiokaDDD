using AbiokaDDD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbiokaDDD.Repository.MongoDB.DatabaseObjects
{
    internal static class BoardMongoDBExtensions
    {
        public static ListMongoDB ToListMongoDB(this List list) {
            if (list == null)
                return null;

            var comments = new List<CommentMongoDB>();
            foreach (var card in list.Cards)
            {
                if(card.Id == Guid.Empty)
                {
                    card.Id = Guid.NewGuid();
                }
                comments.AddRange(card.Comments.ToMongoDBs(card.Id));
            }

            var listMongoDB =  new ListMongoDB
            {
                Id = list.Id,
                Name = list.Name,
                Cards = list.Cards?.ToMongoDBs().ToList(),
                Comments = comments
            };
            listMongoDB.SetDefault();
            return listMongoDB;
        }

        public static IEnumerable<ListMongoDB> ToListMongoDBs(this IEnumerable<List> lists) {
            if (lists == null)
                yield break;

            foreach (var item in lists)
            {
                yield return item.ToListMongoDB();
            }
        }

        public static List ToList(this ListMongoDB list) {
            if (list == null)
                return null;

            return new List
            {
                Id = list.Id,
                Name = list.Name,
                Cards = list.Cards.ToCards(list.Comments).ToList()
            };
        }

        public static IEnumerable<List> ToLists(this IEnumerable<ListMongoDB> lists) {
            if (lists == null)
                yield break;

            foreach (var item in lists)
            {
                yield return item.ToList();
            }
        }

        private static Card ToCard(this CardMongoDB card, IEnumerable<CommentMongoDB> comments) {
            if (card == null)
                return null;

            return new Card
            {
                Id = card.Id,
                Title = card.Title,
                Comments = comments.Where(c=>c.CardId == card.Id).ToComments().ToList()
            };
        }

        private static IEnumerable<Card> ToCards(this IEnumerable<CardMongoDB> cards, IEnumerable<CommentMongoDB> comments) {
            if (cards == null)
                yield break;

            foreach (var item in cards)
            {
                yield return item.ToCard(comments);
            }
        }

        public static CardMongoDB ToCardMongoDB(this Card card) {
            if (card == null)
                return null;

            var result = new CardMongoDB
            {
                Id = card.Id,
                Title = card.Title
            };
            result.SetDefault();
            return result;
        }

        private static IEnumerable<CardMongoDB> ToMongoDBs(this IEnumerable<Card> cards) {
            if (cards == null)
                yield break;

            foreach (var item in cards)
            {
                yield return item.ToCardMongoDB();
            }
        }

        public static CommentMongoDB ToCommentMongoDB(this Comment comment, Guid cardId) {
            if (comment == null)
                return null;

            var result = new CommentMongoDB
            {
                Id = comment.Id,
                CardId = cardId,
                Text = comment.Text
            };
            result.SetDefault();
            return result;
        }

        private static IEnumerable<CommentMongoDB> ToMongoDBs(this IEnumerable<Comment> comments, Guid cardId) {
            if (comments == null)
                yield break;

            foreach (var item in comments)
            {
                yield return item.ToCommentMongoDB(cardId);
            }
        }

        private static Comment ToComment(this CommentMongoDB comment) {
            if (comment == null)
                return null;

            return new Comment
            {
                Id = comment.Id,
                Text = comment.Text
            };
        }

        private static IEnumerable<Comment> ToComments(this IEnumerable<CommentMongoDB> comments) {
            if (comments == null)
                yield break;

            foreach (var item in comments)
            {
                yield return item.ToComment();
            }
        }
    }
}
