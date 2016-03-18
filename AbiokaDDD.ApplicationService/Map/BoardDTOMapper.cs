using AbiokaDDD.ApplicationService.DTOs;
using AbiokaDDD.Domain;
using System.Collections.Generic;

namespace AbiokaDDD.ApplicationService.Map
{
    public static class BoardDTOMapper
    {
        public static BoardDTO ToDTO(this Board board) {
            var result = new BoardDTO
            {
                Id = board.Id,
                Name = board.Name,
                Lists = board.Lists.ToDTOs()
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
                Lists = dto.Lists.ToDomainObject()
            };
            return result;
        }

        private static List ToDomainList(this ListDTO list) {
            if (list == null)
                return null;

            var result = new List
            {
                Id = list.Id,
                Name = list.Name
            };
            return result;
        }

        private static IEnumerable<List> ToDomainObject(this IEnumerable<ListDTO> lists) {
            if (lists == null)
                yield break;// return null;

            foreach (var item in lists)
            {
                yield return item.ToDomainList();
            }
        }

        private static ListDTO ToDTOList(this List list) {
            if (list == null)
                return null;

            var result = new ListDTO
            {
                Id = list.Id,
                Name = list.Name
            };
            return result;
        }

        private static IEnumerable<ListDTO> ToDTOs(this IEnumerable<List> lists) {
            if (lists == null)
                yield break;// return null;

            foreach (var item in lists)
            {
                yield return item.ToDTOList();
            }
        }
    }
}
