using AbiokaDDD.ApplicationService.Abstractions;
using AbiokaDDD.ApplicationService.Messaging;
using AbiokaDDD.Domain;
using AbiokaDDD.Domain.Repositories;
using AbiokaDDD.ApplicationService.Map;
using System;

namespace AbiokaDDD.ApplicationService.Implementations
{
    public class BoardService : IBoardService
    {
        IBoardRepository boardRepository;

        public BoardService(IBoardRepository boardRepository) {
            this.boardRepository = boardRepository;
        }

        public GetBoardByIdResponse GetBoardById(GetBoardByIdRequest request) {
            Board board = boardRepository.FindById(request.BoardId);
            var result = new GetBoardByIdResponse
            {
                Board = board?.ToViewModel()
            };
            return result;
        }

        public AddBoardResponse AddBoard(AddBoardRequest request) {
            var board = request.Board.ToDomainObject();
            boardRepository.Add(board);

            return new AddBoardResponse
            {
                Board = board.ToViewModel()
            };
        }

        public UpdateBoardResponse UpdateBoard(UpdateBoardRequest request) {
            var board = request.Board.ToDomainObject();
            boardRepository.Update(board);

            return new UpdateBoardResponse
            {
                Board = board.ToViewModel()
            };
        }

        public DeleteBoardResponse DeleteBoard(Guid id) {
            var board = new Board
            {
                Id = id
            };

            boardRepository.Delete(board);

            return new DeleteBoardResponse();
        }
    }
}
