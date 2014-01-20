using System;

namespace NinjaVsWerewolves.World
{
    public class WrappedRandom : IRandom
    {
        private System.Random _random = new System.Random();

        public uint Random(uint upper_exclusive_bound)
        {
            return Convert.ToUInt32(_random.Next((int)upper_exclusive_bound));
        }

        public int Random(int upper_exclusive_bound)
        {
            return _random.Next(upper_exclusive_bound);
        }
    }
}
