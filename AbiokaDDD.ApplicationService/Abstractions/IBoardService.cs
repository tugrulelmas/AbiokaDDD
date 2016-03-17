using AbiokaDDD.ApplicationService.Messaging;
using System;

namespace AbiokaDDD.ApplicationService.Abstractions
{
    public interface IBoardService
    {
        GetBoardByIdResponse GetBoardById(GetBoardByIdRequest request);

        AddBoardResponse AddBoard(AddBoardRequest request);

        DeleteBoardResponse DeleteBoard(Guid id);

        UpdateBoardResponse UpdateBoard(UpdateBoardRequest request);
    }
}
