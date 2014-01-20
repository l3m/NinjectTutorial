using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaVsWerewolves.World
{
    public interface ISimulationFactory
    {
        ISimulation CreateSimulation();
    }
}
