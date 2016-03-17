namespace AbiokaDDD.Infrastructure.Common.Domain
{
    public interface IRepository<T> : IReadOnlyRepository<T> where T : IEntity
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
