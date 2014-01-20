using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaVsWerewolves.World
{
    public interface IRandom
    {
        uint Random(uint upper_exclusive_bound);
        int Random(int upper_exclusive_bound);
    }
}
