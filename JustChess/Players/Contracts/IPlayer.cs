namespace JustChess.Players.Contracts
{
    using Common;
    using Figure;

    public interface IPlayer
    {
        string Name { get; }

        ChessColor Color { get; }

        void AddFigure(Figure figure);

        void RemoveFigure(Figure figure);
    }
}
