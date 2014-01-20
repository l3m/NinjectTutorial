using System;
using System.Collections.Generic;
using NinjaVsWerewolves.Creature;

namespace NinjaVsWerewolves.World
{
    /// <summary>
    /// A simple 2d grid. 
    /// 
    /// Directions are encoded as follows (with x being the creature).
    ///     0 1 2 
    ///     7 x 3
    ///     6 5 4
    /// </summary>
    public interface IWorld
    {
        IEnumerable<ICreature> FindNeighbors(ICreature c);

        bool PlaceRandomly(ICreature c);
        bool PlaceCreature(ICreature c, uint pos);
        bool MoveCreature(ICreature c);
        void RemoveCreature(ICreature c);

        string Name { get; }

        string AsciiVisualization { get; }
    }
}
