namespace JustChess.Board.Contracts
{
    using JustChess.Common;
    using JustChess.Figures.Contracts;

    public interface IBoard
    {
        int TotalRows { get; }

        int TotalCols { get; }

        void AddFigure(Figure figure, Position position);

        void RemoveFigure(Position position);

        Figure GetFigureAtPosition(Position position);

        void MoveFigureAtPosition(Figure figure, Position from, Position to);
    }
}
