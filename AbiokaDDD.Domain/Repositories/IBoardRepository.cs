using AbiokaDDD.Infrastructure.Common.Domain;
using System;
using System.Collections.Generic;

namespace AbiokaDDD.Domain.Repositories
{
    public interface IBoardRepository : IRepository<Board>
    {
        IEnumerable<Board> GetBoards(bool includeList);

        Board GetBoard(Guid id, bool includeLists);

        void AddList(Guid boardId, List list);
    }
}
