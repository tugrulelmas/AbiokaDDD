﻿using AbiokaDDD.Infrastructure.Common.Domain;
using System;
using System.Collections.Generic;

namespace AbiokaDDD.Domain.Repositories
{
    public interface IBoardRepository : IRepository<Board>
    {
        IEnumerable<Board> GetBoards(bool includeList, bool includeComments);

        Board GetBoard(Guid id, bool includeLists, bool includeComments);

        void AddList(Guid boardId, List list);

        void AddCard(Guid boardId, Guid listId, Card card);

        void AddComment(Guid boardId, Guid listId, Guid cardId, Comment comment);

        void AddLabel(Guid boardId, Guid listId, Guid cardId, Label label);

        void DeleteComment(Guid boardId, Guid listId, Guid cardId, Comment comment);
    }
}
