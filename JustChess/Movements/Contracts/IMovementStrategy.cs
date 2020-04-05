namespace JustChess.Movements.Contracts
{
    using System.Collections.Generic;

    using Figure;

    public interface IMovementStrategy
    {
        IList<IMovement> GetMovements(FigureType figureType);
    }
}
