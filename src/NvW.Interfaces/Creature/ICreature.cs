using System.Collections.Generic;
using System.Reflection;
using NinjaVsWerewolves.World;

namespace NinjaVsWerewolves.Creature
{
    public interface ICreature
    {
        int Health { get; set; }
        bool Infected { get; set; }

        char Sprite { get; }

        string Encounter(ICreature cs);
        string Encounter(IEnumerable<ICreature> cs);

        string Name { get; set; }

        uint Position { get; set; }
        uint Direction { get; set; }
    }
}
