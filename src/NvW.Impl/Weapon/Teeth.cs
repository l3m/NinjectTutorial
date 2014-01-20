using System;
using NinjaVsWerewolves.Creature;
using NinjaVsWerewolves.World;

namespace NinjaVsWerewolves.Weapon
{
    public class Teeth : IWeapon
    {
        private readonly IRandom _random;

        public Teeth(IRandom random)
        {
            _random = random;
        }

        public uint Damage
        {
            get { return 1; }
        }

        public uint Attack(ICreature c)
        {
            uint dmg = Damage;
            c.Health -= (int) dmg;

            if (_random.Random(2) == 0)
                c.Infected = true;

            return dmg;
        }

        public override string ToString()
        {
            return "Teeth";
        }

    }
}
