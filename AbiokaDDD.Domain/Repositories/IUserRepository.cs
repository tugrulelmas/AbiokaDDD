using AbiokaDDD.Infrastructure.Common.Domain;

namespace AbiokaDDD.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByEmail(string email);
    }
}
