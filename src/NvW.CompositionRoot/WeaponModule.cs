using NinjaVsWerewolves.Creature;
using NinjaVsWerewolves.Weapon;
using Ninject.Modules;

namespace NinjaVsWerewolves.CompositionRoot
{
    public class WeaponModule : NinjectModule 
    {
        public override void Load()
        {
            Bind<IWeapon>().To<Teeth>().WhenInjectedInto<IWerewolf>();
            Bind<IWeapon>().To<Katana>().WhenInjectedInto<INinja>();
        }
    }
}
