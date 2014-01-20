using System;
using System.Collections.Generic;
using System.Text;
using NinjaVsWerewolves.Weapon;
using NinjaVsWerewolves.World;

namespace NinjaVsWerewolves.Creature
{
    public class Ninja : Warrior, INinja
    {
        public Ninja(IRandom r, IWeapon w)
            : base("Ninja_", r.Random(1) == 0, w)
        {
            Health = 3;
        }

        public int Health { get; set; }

        public bool Infected { get; set; }
        public char Sprite
        {
            get { return 'N'; }
        }

        public string Encounter(ICreature c)
        {
            var w = c as IWerewolf;
            if (w == null)
            {
                return "";
            }

            return Attack(c);
        }

        public string Encounter(IEnumerable<ICreature> cs)
        {
            var sb = new StringBuilder();
            foreach (var c in cs)
            {
                var s = Encounter(c);
                if (s != "")
                {
                    sb.AppendLine(s);
                }
            }
            return sb.ToString();
        }

        public uint Position { get; set; }
        public uint Direction { get; set; }
    }
}
