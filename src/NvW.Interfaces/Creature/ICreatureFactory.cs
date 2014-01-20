namespace NinjaVsWerewolves.Creature
{
    public interface ICreatureFactory
    {
        INinja CreateNinja();
        IWerewolf CreateWerewolf();
        IJogger CreateJogger();
    }
}
