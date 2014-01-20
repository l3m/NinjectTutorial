using NinjaVsWerewolves.World;
using Ninject;
using Ninject.Modules;

namespace NinjaVsWerewolves.CompositionRoot
{
    public class ModuleConfig 
    {
        public ModuleConfig()
        {
            INinjectModule[] x =
            {
                new CreatureModule(),
                new WeaponModule(),
                new WorldModule()
            };

            Kernel = new StandardKernel(x);
        }

        public IKernel Kernel { get; private set; }

        public ISimulationFactory CreateSimulationFactory()
        {
            return Kernel.Get<ISimulationFactory>();
        }
    }
}