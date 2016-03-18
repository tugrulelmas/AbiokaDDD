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
                        new ListDTO { Name = "List 1" }
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
                IncludeList = true
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
            }
            else
            {
                Console.WriteLine($"Board couldn't be found.");
            }
            Console.ReadLine();
        }
    }
}
