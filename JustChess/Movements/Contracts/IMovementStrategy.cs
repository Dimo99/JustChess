namespace JustChess.Movements.Contracts
{
    using JustChess.Figures;
    using System.Collections.Generic;

    public interface IMovementStrategy
    {
        IList<IMovement> GetMovements(FigureType figureType);
    }
}
