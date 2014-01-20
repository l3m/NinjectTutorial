namespace NinjaVsWerewolves.Weapon
{
    public class Claws : Weapon, IWeapon
    {
        public Claws()
            : base("Claws")
        {
        }

        public override uint Damage
        {
            get { return 2; }
        }
    }
}
