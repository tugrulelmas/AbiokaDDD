using AbiokaDDD.ApplicationService.ViewModel;
using AbiokaDDD.Domain;
using System.Collections.Generic;

namespace AbiokaDDD.ApplicationService.Map
{
    public static class BoardViewModelMapper
    {
        public static BoardViewModel ToViewModel(this Board board) {
            var result = new BoardViewModel
            {
                Id = board.Id,
                Name = board.Name
            };
            return result;
        }

        public static IEnumerable<BoardViewModel> ToDomainObject(this IEnumerable<Board> board) {
            foreach (var item in board)
            {
                yield return item.ToViewModel();
            }
        }

        public static Board ToDomainObject(this BoardViewModel viewModel) {
            var result = new Board
            {
                Id = viewModel.Id,
                Name = viewModel.Name
            };
            return result;
        }
    }
}
