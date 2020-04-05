namespace JustChess.Figure
{
    using System.Collections.Generic;

    using Common;
    using Movements.Contracts;

    public class Figure
    {
        public Figure(ChessColor color, FigureType figureType)
        {
            this.Color = color;
            this.FigureType = figureType;
        }

        public FigureType FigureType { get; private set; }

        public ChessColor Color { get; private set; }

        public ICollection<IMovement> Move(IMovementStrategy strategy)
        {
            return strategy.GetMovements(this.FigureType);
        }
    }
}
