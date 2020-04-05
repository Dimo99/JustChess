namespace JustChess.Engine.Contracts
{
    using System.Collections.Generic;

    using Board;
    using Player;

    public interface IGameInitializationStrategy
    {
        void Initialize(IList<Player> players, Board board);
    }
}
