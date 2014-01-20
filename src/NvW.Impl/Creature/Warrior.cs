using NinjaVsWerewolves.Weapon;

namespace NinjaVsWerewolves.Creature
{
    public class Warrior
    {
        public string GenderPronoun { get; private set; }
        public IWeapon Weapon { get; private set; }

        public string Name { get; set; }

        public Warrior(string name, bool is_male, IWeapon weapon)
        {
            GenderPronoun = is_male ? "his" : "her";
            Weapon = weapon;
            Name = name;
        }

        protected string Attack(ICreature c)
        {
            var dmg = Weapon.Attack(c);
            return string.Format("{0} attacks {1} using {2} {3} for {4} damage.",
                Name, c.Name, GenderPronoun, Weapon, dmg);
        }
    }
}
