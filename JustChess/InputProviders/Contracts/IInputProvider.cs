namespace JustChess.InputProviders.Contracts
{
    using System.Collections.Generic;

    using Common;
    using Player;

    public interface IInputProvider
    {
        IList<Player> GetPlayers(int numberOfPlayers);

        Move GetNextPlayerMove(Player player);
    }
}
