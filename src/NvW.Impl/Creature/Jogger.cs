using System.Collections.Generic;

namespace NinjaVsWerewolves.Creature
{
    public class Jogger : IJogger
    {
        public Jogger()
        {
            Health = 2;
            Name = "Jogger_";
        }

        public int Health { get; set; }

        public bool Infected { get; set; }

        public char Sprite
        {
            get { return 'j'; }
        }

        public string Encounter(ICreature cs)
        {
            return "";
        }

        public string Encounter(IEnumerable<ICreature> nbs)
        {
            return "";
        }

        public string Name { get; set; }

        public uint Position { get; set; }
        public uint Direction { get; set; }
    }
}
