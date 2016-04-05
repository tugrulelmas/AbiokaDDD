using AbiokaDDD.Domain;
using AbiokaDDD.Domain.Repositories;
using AbiokaDDD.Repository.MongoDB.DatabaseObjects;
using AbiokaDDD.Repository.MongoDB.Helper;
using MongoDB.Driver;

namespace AbiokaDDD.Repository.MongoDB.Repositories
{
    internal class UserRepository : MongoDBRepository<User, UserMongoDB>, IUserRepository
    {
        public UserRepository(IMongoDBContext mongoDBContext, IPropertyHelper propertyHelper)
            : base(mongoDBContext, propertyHelper) {
        }

        public User GetByEmail(string email) {
            var mongoResult = Collection.Find(u => u.Email.ToLowerInvariant() == email.ToLowerInvariant()).FirstOrDefault();
            if (mongoResult == null)
                return null;

            var result = new User();
            mongoResult.CopyToDomainObject(result);
            return result;
        }
    }
}
