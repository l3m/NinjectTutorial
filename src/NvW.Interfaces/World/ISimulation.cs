using System.Collections.Generic;
using NinjaVsWerewolves.Creature;

namespace NinjaVsWerewolves.World
{
    public interface ISimulation
    {
        IWorld World { get; }

        IEnumerable<ICreature> Creatures { get; }

        IEnumerable<INinja> Ninjas { get; }
        IEnumerable<IWerewolf> Werewolves { get; }
        IEnumerable<IJogger> Joggers { get; }

        void Step();
        bool ShouldStop();

        void Visualize();
        string GetAndClearLog();
        string Summary { get; }

        string Name { get; }
    }
}
