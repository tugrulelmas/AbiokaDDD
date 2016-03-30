using AbiokaDDD.ApplicationService.DTOs;
using AbiokaDDD.Domain;
using System.Collections.Generic;
using System.Linq;

namespace AbiokaDDD.ApplicationService.Map
{
    public static class BoardDTOMapper
    {
        public static BoardDTO ToDTO(this Board board) {
            var result = new BoardDTO
            {
                Id = board.Id,
                Name = board.Name,
                Lists = board.Lists.ToDTOs().ToList()
            };
            return result;
        }

        public static IEnumerable<BoardDTO> ToDomainObject(this IEnumerable<Board> board) {
            foreach (var item in board)
            {
                yield return item.ToDTO();
            }
        }

        public static Board ToDomainObject(this BoardDTO dto) {
            var result = new Board
            {
                Id = dto.Id,
                Name = dto.Name,
                Lists = dto.Lists.ToDomainObject().ToList()
            };
            return result;
        }

        public static ListDTO ToDTO(this List list) {
            if (list == null)
                return null;

            var result = new ListDTO
            {
                Id = list.Id,
                Name = list.Name
            };
            return result;
        }

        public static List ToDomainObject(this ListDTO list) {
            if (list == null)
                return null;

            var result = new List
            {
                Id = list.Id,
                Name = list.Name,
                Cards = list.Cards.ToDomainObject().ToList()
            };
            return result;
        }

        private static IEnumerable<List> ToDomainObject(this IEnumerable<ListDTO> lists) {
            if (lists == null)
                yield break;

            foreach (var item in lists)
            {
                yield return item.ToDomainObject();
            }
        }

        private static ListDTO ToDTOList(this List list) {
            if (list == null)
                return null;

            var result = new ListDTO
            {
                Id = list.Id,
                Name = list.Name,
                Cards = list.Cards.ToDTOs().ToList()
            };
            return result;
        }

        private static IEnumerable<ListDTO> ToDTOs(this IEnumerable<List> lists) {
            if (lists == null)
                yield break;

            foreach (var item in lists)
            {
                yield return item.ToDTOList();
            }
        }

        public static Card ToDomainObject(this CardDTO card) {
            if (card == null)
                return null;

            var result = new Card
            {
                Id = card.Id,
                Title = card.Title,
                Comments = card.Comments.ToDomainObject().ToList(),
                Labels = card.Labels.ToDomainObject().ToList()
            };
            return result;
        }

        private static IEnumerable<Card> ToDomainObject(this IEnumerable<CardDTO> cards) {
            if (cards == null)
                yield break;

            foreach (var item in cards)
            {
                yield return item.ToDomainObject();
            }
        }

        public static CardDTO ToDTO(this Card card) {
            if (card == null)
                return null;

            var result = new CardDTO
            {
                Id = card.Id,
                Title = card.Title,
                Comments = card.Comments.ToDTOs().ToList(),
                Labels = card.Labels.ToDTOs().ToList()
            };
            return result;
        }

        private static IEnumerable<CardDTO> ToDTOs(this IEnumerable<Card> cards) {
            if (cards == null)
                yield break;

            foreach (var item in cards)
            {
                yield return item.ToDTO();
            }
        }

        public static Comment ToDomainObject(this CommentDTO comment) {
            if (comment == null)
                return null;

            var result = new Comment
            {
                Id = comment.Id,
                Text = comment.Text
            };
            return result;
        }

        private static IEnumerable<Comment> ToDomainObject(this IEnumerable<CommentDTO> comments) {
            if (comments == null)
                yield break;

            foreach (var item in comments)
            {
                yield return item.ToDomainObject();
            }
        }

        public static CommentDTO ToDTO(this Comment comment) {
            if (comment == null)
                return null;

            var result = new CommentDTO
            {
                Id = comment.Id,
                Text = comment.Text,
            };
            return result;
        }

        private static IEnumerable<CommentDTO> ToDTOs(this IEnumerable<Comment> comments) {
            if (comments == null)
                yield break;

            foreach (var item in comments)
            {
                yield return item.ToDTO();
            }
        }

        public static Label ToDomainObject(this LabelDTO label) {
            if (label == null)
                return null;

            var result = new Label
            {
                Id = label.Id,
                Name = label.Name
            };
            return result;
        }

        private static IEnumerable<Label> ToDomainObject(this IEnumerable<LabelDTO> labels) {
            if (labels == null)
                yield break;

            foreach (var item in labels)
            {
                yield return item.ToDomainObject();
            }
        }

        public static LabelDTO ToDTO(this Label label) {
            if (label == null)
                return null;

            var result = new LabelDTO
            {
                Id = label.Id,
                Name = label.Name,
            };
            return result;
        }

        private static IEnumerable<LabelDTO> ToDTOs(this IEnumerable<Label> labels) {
            if (labels == null)
                yield break;

            foreach (var item in labels)
            {
                yield return item.ToDTO();
            }
        }
    }
}
