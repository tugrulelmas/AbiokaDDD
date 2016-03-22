using AbiokaDDD.Domain;
using System.Collections.Generic;
using System.Linq;

namespace AbiokaDDD.Repository.MongoDB.DatabaseObjects
{
    internal static class BoardMongoDBExtensions
    {
        public static ListMongoDB ToListMongoDB(this List list) {
            if (list == null)
                return null;

            return new ListMongoDB
            {
                Id = list.Id,
                Name = list.Name,
                Cards = list.Cards?.ToMongoDBs().ToList()
            };
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
                Cards = list.Cards.ToCards()
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

        private static Card ToCard(this CardMongoDB card) {
            if (card == null)
                return null;

            return new Card
            {
                Id = card.Id,
                Title = card.Title
            };
        }

        private static IEnumerable<Card> ToCards(this IEnumerable<CardMongoDB> cards) {
            if (cards == null)
                yield break;

            foreach (var item in cards)
            {
                yield return item.ToCard();
            }
        }

        public static CardMongoDB ToCardMongoDB(this Card card) {
            if (card == null)
                return null;

            return new CardMongoDB
            {
                Id = card.Id,
                Title = card.Title
            };
        }

        private static IEnumerable<CardMongoDB> ToMongoDBs(this IEnumerable<Card> cards) {
            if (cards == null)
                yield break;

            foreach (var item in cards)
            {
                yield return item.ToCardMongoDB();
            }
        }
    }
}
