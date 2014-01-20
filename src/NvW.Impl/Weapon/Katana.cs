using NinjaVsWerewolves.Creature;
using NinjaVsWerewolves.World;

namespace NinjaVsWerewolves.Weapon
{
    public class Katana : IWeapon
    {
        private IRandom _rng;
        public Katana(IRandom rng)
        {
            _rng = rng;
        }

        public uint Damage
        {
            get { return _rng.Random(5u); }
        }

        public uint Attack(ICreature c)
        {
            var dmg = Damage;
            c.Health -= (int) dmg;
            return dmg;
        }

        public override string ToString()
        {
            return "Katana";
        }

    }
}
