using NinjaVsWerewolves.Creature;

namespace NinjaVsWerewolves.Weapon
{
    public interface IWeapon
    {
        uint Damage { get; }
        uint Attack(ICreature c);
    }
}
