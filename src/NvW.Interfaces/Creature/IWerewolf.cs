using NinjaVsWerewolves.Weapon;

namespace NinjaVsWerewolves.Creature
{
    public interface IWerewolf : ICreature
    {
        IWeapon Weapon { get; }
    }
}
