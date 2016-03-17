using AbiokaDDD.ApplicationService.Abstractions;
using AbiokaDDD.ApplicationService.Implementations;
using AbiokaDDD.Domain.Repositories;
using AbiokaDDD.Infrastructure.Common.ApplicationSettings;
using AbiokaDDD.Infrastructure.Common.IoC;
using AbiokaDDD.Infrastructure.Framework.IoC;
using AbiokaDDD.Repository.MongoDB.Repositories;

namespace AbiokaDDD.ConsoleApp
{
    public class Bootstrapper
    {
        public static void Initialise() {
            DependencyContainer.SetContainer(new CastleContainer());

            DependencyContainer.Container.RegisterSingleton(typeof(IConnectionStringRepository), typeof(WebConfigConnectionStringRepository));

            DependencyContainer.Container.RegisterSingleton(typeof(IBoardRepository), typeof(BoardRepository));
            DependencyContainer.Container.RegisterSingleton(typeof(IBoardService), typeof(BoardService));
        }
    }
}
