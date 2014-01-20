using System.Collections.Generic;
using NinjaVsWerewolves.Weapon;
using NinjaVsWerewolves.World;

namespace NinjaVsWerewolves.Creature
{
    public class Werewolf : Warrior, IWerewolf
    {
        public Werewolf(IRandom r, IWeapon weapon)
            : base("Werewolf_", r.Random(1) == 0, weapon)
        {
            Infected = true;
            Health = 4;
        }

        public int Health { get; set; }
        public bool Infected { get; set; }
        public char Sprite
        {
            get { return 'w'; }
        }

        public string Encounter(ICreature c)
        {
            var w = c as IWerewolf;
            if (w != null)
            {
                return "";
            }

            return Attack(c);
        }

        public string Encounter(IEnumerable<ICreature> nbs)
        {
            foreach (var nb in nbs)
            {
                var w = nb as IWerewolf;
                if (w != null)
                {
                    continue;
                }

                return Attack(nb);
            }
            return "";
        }


        public uint Position { get; set; }
        public uint Direction { get; set; }

    }
}
