using AbiokaDDD.Domain.Repositories;
using AbiokaDDD.Infrastructure.Common.IoC;
using AbiokaDDD.Repository.MongoDB.Helper;
using AbiokaDDD.Repository.MongoDB.Repositories;

namespace AbiokaDDD.Repository.MongoDB
{
    public class Bootstrapper
    {
        public static void Initialise() {
            DependencyContainer.Container.RegisterSingleton(typeof(IMongoDBContext), typeof(MongoDBContext));
            DependencyContainer.Container.RegisterSingleton(typeof(IBoardRepository), typeof(BoardRepository));
            DependencyContainer.Container.RegisterSingleton(typeof(IPropertyHelper), typeof(PropertyHelper));
        }
    }
}
