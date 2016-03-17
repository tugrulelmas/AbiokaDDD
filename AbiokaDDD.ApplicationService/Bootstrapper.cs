using AbiokaDDD.ApplicationService.Abstractions;
using AbiokaDDD.ApplicationService.Implementations;
using AbiokaDDD.Infrastructure.Common.IoC;

namespace AbiokaDDD.ApplicationService
{
    public class Bootstrapper
    {
        public static void Initialise() {
            Repository.MongoDB.Bootstrapper.Initialise();

            DependencyContainer.Container.RegisterSingleton(typeof(IBoardService), typeof(BoardService));
        }
    }
}
