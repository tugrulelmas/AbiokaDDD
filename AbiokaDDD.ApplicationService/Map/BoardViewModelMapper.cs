using AbiokaDDD.ApplicationService.DTOs;
using AbiokaDDD.Domain;
using System.Collections.Generic;

namespace AbiokaDDD.ApplicationService.Map
{
    public static class BoardViewModelMapper
    {
        public static BoardDTO ToDTO(this Board board) {
            var result = new BoardDTO
            {
                Id = board.Id,
                Name = board.Name
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
                Name = dto.Name
            };
            return result;
        }
    }
}
