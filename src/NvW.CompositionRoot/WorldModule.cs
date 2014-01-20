using NinjaVsWerewolves.World;
using Ninject.Extensions.Factory;
using Ninject.Extensions.NamedScope;
using Ninject.Modules;

namespace NinjaVsWerewolves.CompositionRoot
{
    public class WorldModule : NinjectModule
    {
        public string SimulationContext = "SimulationContext";

        public override void Load()
        {
            Bind<ISimulation>().To<Simulation>().DefinesNamedScope(SimulationContext);
            Bind<ISimulationFactory>().ToFactory();

            Bind<IWorld>().To<SimpleWorld>().InNamedScope(SimulationContext);

            Bind<IRandom>().To<WrappedRandom>().InSingletonScope();
        }
    }
}
