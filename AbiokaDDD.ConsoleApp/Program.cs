using AbiokaDDD.ApplicationService.Abstractions;
using AbiokaDDD.ApplicationService.Messaging;
using AbiokaDDD.ApplicationService.ViewModel;
using AbiokaDDD.Infrastructure.Common.IoC;
using System;
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
                Board = new BoardViewModel
                {
                    Id = Guid.NewGuid(),
                    Name = "Yaprak"
                }
            };
            var addBoardResponse = boardService.AddBoard(addBoardRequest);
            Console.WriteLine($"Added board with id {addBoardResponse.Board.Id}");

            boardService.DeleteBoard(addBoardResponse.Board.Id);
            Console.WriteLine($"Deleted board with id {addBoardResponse.Board.Id}");

            var boardResponse = boardService.GetBoardById(new GetBoardByIdRequest
            {
                BoardId = Guid.Parse("ca735fdf-5fcb-4189-8cc0-e953ae0af502")
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
