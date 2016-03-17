namespace AbiokaDDD.Infrastructure.Common.Domain
{
    public interface IIdEntity<TId> : IEntity
    {
        TId Id { get; set; }
    }
}
