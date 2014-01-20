using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NinjaVsWerewolves.Creature;

namespace NinjaVsWerewolves.Weapon
{
    public abstract class Weapon
    {
        public string Name { get; set; }

        protected Weapon(string name)
        {
            Name = name;
        }
        public abstract uint Damage { get; }

        public virtual uint Attack(ICreature c)
        {
            var dmg = Damage;
            c.Health -= (int)dmg;
            return dmg;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
