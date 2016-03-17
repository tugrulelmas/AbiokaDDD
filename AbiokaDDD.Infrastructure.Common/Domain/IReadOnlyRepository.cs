using System.Collections.Generic;

namespace AbiokaDDD.Infrastructure.Common.Domain
{
    public interface IReadOnlyRepository<T> where T : IEntity
    {
        T FindById(object id);

        IEnumerable<T> GetAll();
    }
}
