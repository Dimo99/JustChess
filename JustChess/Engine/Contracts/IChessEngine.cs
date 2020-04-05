namespace JustChess.Engine.Contracts
{
    using System.Collections.Generic;
    using Player;

    public interface IChessEngine
    {
        IEnumerable<Player> Players { get; }

        void Initialize(IGameInitializationStrategy gameInitializationStrategy);

        void Start();

        void WinningConditions();
    }
}
