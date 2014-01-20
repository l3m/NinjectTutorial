using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NinjaVsWerewolves.Weapon;

namespace NinjaVsWerewolves.Creature
{
    public interface INinja : ICreature
    {
        IWeapon Weapon { get; }
    }
}
