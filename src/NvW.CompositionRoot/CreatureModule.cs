using NinjaVsWerewolves.Creature;
using Ninject.Extensions.Factory;
using Ninject.Modules;

namespace NinjaVsWerewolves.CompositionRoot
{
    public class CreatureModule : NinjectModule
    {
        public override void Load()
        {
            Bind<INinja>().To<Ninja>();
            Bind<IWerewolf>().To<Werewolf>();
            Bind<IJogger>().To<Jogger>();

            Bind<ICreatureFactory>().ToFactory();
        }
    }
}
