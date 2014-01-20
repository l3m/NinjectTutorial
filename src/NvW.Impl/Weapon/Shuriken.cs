using System.Reflection;
using NinjaVsWerewolves.Creature;

namespace NinjaVsWerewolves.Weapon
{
    public class Shuriken : IWeapon
    {
        public uint Damage
        {
            get { return 1; }
        }

        public uint Attack(ICreature c)
        {
            uint dmg = Damage;
            c.Health -= (int) dmg;
            return dmg;
        }

        public override string ToString()
        {
            return "Shuriken";
        }

    }
}
