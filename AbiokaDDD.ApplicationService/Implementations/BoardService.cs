using AbiokaDDD.ApplicationService.Abstractions;
using AbiokaDDD.ApplicationService.Map;
using AbiokaDDD.ApplicationService.Messaging;
using AbiokaDDD.Domain;
using AbiokaDDD.Domain.Repositories;
using System;
using System.Linq;

namespace AbiokaDDD.ApplicationService.Implementations
{
    public class BoardService : IBoardService
    {
        IBoardRepository boardRepository;

        public BoardService(IBoardRepository boardRepository) {
            this.boardRepository = boardRepository;
        }

        public GetBoardByIdResponse GetBoardById(GetBoardByIdRequest request) {
            Board board = boardRepository.GetBoard(request.BoardId, request.IncludeList, request.IncludeComments);
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

        public AddListResponse AddList(AddListRequest request) {
            var list = request.List.ToDomainObject();
            boardRepository.AddList(request.BoardId, list);

            return new AddListResponse
            {
                List = list.ToDTO()
            };
        }

        public AddCardResponse AddCard(AddCardRequest request) {
            var card = request.Card.ToDomainObject();
            boardRepository.AddCard(request.BoardId, request.ListId, card);

            return new AddCardResponse
            {
                Card = card.ToDTO()
            };
        }

        public AddCommentResponse AddComment(AddCommentRequest request) {
            var comment = request.Comment.ToDomainObject();
            boardRepository.AddComment(request.BoardId, request.ListId, request.CardId, comment);

            return new AddCommentResponse
            {
                Comment = comment.ToDTO()
            };
        }

        public GetCardResponse GetCard(GetCardRequest request) {
            var board = boardRepository.GetBoard(request.BoardId, true, true);
            var card = board.Lists.FirstOrDefault(l => l.Id == request.ListId)?.Cards.FirstOrDefault(c => c.Id == request.CardId);
            var result = new GetCardResponse
            {
                Card = card?.ToDTO()
            };
            return result;
        }

        public AddLabelResponse AddLabel(AddLabelRequest request) {
            var label = request.Label.ToDomainObject();
            boardRepository.AddLabel(request.BoardId, request.ListId, request.CardId, label);

            return new AddLabelResponse
            {
                Label = label.ToDTO()
            };
        }
    }
}
