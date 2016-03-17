using AbiokaDDD.Infrastructure.Common.ApplicationSettings;
using AbiokaDDD.Infrastructure.Common.IoC;
using AbiokaDDD.Infrastructure.Framework.IoC;

namespace AbiokaDDD.ConsoleApp
{
    public class Bootstrapper
    {
        public static void Initialise() {
            DependencyContainer.SetContainer(new CastleContainer());

            ApplicationService.Bootstrapper.Initialise();
            DependencyContainer.Container.RegisterSingleton(typeof(IConnectionStringRepository), typeof(WebConfigConnectionStringRepository));
        }
    }
}
