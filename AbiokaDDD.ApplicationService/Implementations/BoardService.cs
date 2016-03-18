using AbiokaDDD.ApplicationService.Abstractions;
using AbiokaDDD.ApplicationService.Map;
using AbiokaDDD.ApplicationService.Messaging;
using AbiokaDDD.Domain;
using AbiokaDDD.Domain.Repositories;
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
                Board = board?.ToDTO()
            };
            return result;

        }

        public AddBoardResponse AddBoard(AddBoardRequest request) {
            var board = request.Board.ToDomainObject();
            boardRepository.Add(board);

            return new AddBoardResponse
            {
                Board = board.ToDTO()
            };
        }

        public UpdateBoardResponse UpdateBoard(UpdateBoardRequest request) {
            var board = request.Board.ToDomainObject();
            boardRepository.Update(board);

            return new UpdateBoardResponse
            {
                Board = board.ToDTO()
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
