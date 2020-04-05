namespace JustChess.Engine.Contracts
{
    using System.Collections.Generic;

    using Board;
    using Players.Contracts;

    public interface IGameInitializationStrategy
    {
        void Initialize(IList<IPlayer> players, Board board);
    }
}
