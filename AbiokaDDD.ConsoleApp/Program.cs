using AbiokaDDD.ApplicationService.Abstractions;
using AbiokaDDD.ApplicationService.DTOs;
using AbiokaDDD.ApplicationService.Messaging;
using AbiokaDDD.Infrastructure.Common.IoC;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbiokaDDD.ConsoleApp
{
    class Program
    {
        static void Main(string[] args) {
            Bootstrapper.Initialise();

            var boardService = DependencyContainer.Container.Resolve<IBoardService>();

            var addBoardRequest = new AddBoardRequest
            {
                Board = new BoardDTO
                {
                    Name = "Yaprak",
                    Lists = new List<ListDTO>
                    {
                        new ListDTO {
                            Name = "List 1" ,
                            Cards = new List<CardDTO> {
                                new CardDTO {
                                    Title = "Doing",
                                    Comments = new List<CommentDTO> { new CommentDTO { Text = "Hadi bakalım" } }
                                }
                            }
                        }
                    }
                }
            };
            var addBoardResponse = boardService.AddBoard(addBoardRequest);
            Console.WriteLine($"Added board with id {addBoardResponse.Board.Id}");

            boardService.DeleteBoard(addBoardResponse.Board.Id);
            Console.WriteLine($"Deleted board with id {addBoardResponse.Board.Id}");

            var boardResponse = boardService.GetBoardById(new GetBoardByIdRequest
            {
                BoardId = Guid.Parse("8c692d6c-d118-4a54-ab23-70d14ec36bd8"),
                IncludeList = false
            });
            if (boardResponse.Board != null)
            {
                Console.WriteLine($"Got Id: {boardResponse.Board.Id}, Name: {boardResponse.Board.Name}");
                boardResponse.Board.Name = $"{boardResponse.Board.Name.Split('-').First().Trim()} - {DateTime.Now}";
                var updateResponse = boardService.UpdateBoard(new UpdateBoardRequest
                {
                    Board = boardResponse.Board
                });
                Console.WriteLine($"Updated Id: {updateResponse.Board.Id}, Name: {updateResponse.Board.Name}");

                var list = new ListDTO { Name = $"List - {DateTime.Now}" };
                var addListResponse = boardService.AddList(new AddListRequest { BoardId = boardResponse.Board.Id, List = list });
                Console.WriteLine($"Added List Board Id: {updateResponse.Board.Id}, List Id: {addListResponse.List.Id}");

                var card = new CardDTO { Title = $"Doing - {DateTime.Now}" };
                var addCardResponse = boardService.AddCard(new AddCardRequest { BoardId = updateResponse.Board.Id, ListId = addListResponse.List.Id, Card = card });
                Console.WriteLine($"Added Card Board Id: {updateResponse.Board.Id}, List Id: {addListResponse.List.Id}, Card Id: {addCardResponse.Card.Id}");

                var comment = new CommentDTO { Text = $"Yapariz - {DateTime.Now}" };
                var addCommentResponse = boardService.AddComment(new AddCommentRequest { BoardId = updateResponse.Board.Id, ListId = addListResponse.List.Id, CardId = addCardResponse.Card.Id, Comment = comment });
                Console.WriteLine($"Added Comment Board Id: {updateResponse.Board.Id}, List Id: {addListResponse.List.Id}, Card Id: {addCardResponse.Card.Id}, Comment Id: {addCommentResponse.Comment.Id}");
            }
            else
            {
                Console.WriteLine($"Board couldn't be found.");
            }
            Console.ReadLine();
        }
    }
}
