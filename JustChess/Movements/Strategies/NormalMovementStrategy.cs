namespace JustChess.Movements.Strategies
{
    using System.Collections.Generic;

    using Contracts;
    using JustChess.Figures;

    public class NormalMovementStrategy : IMovementStrategy
    {
        private readonly IDictionary<FigureType, IList<IMovement>> movements = new Dictionary<FigureType, IList<IMovement>>
        {
            { FigureType.Pawn, new List<IMovement>
                 {
                     new NormalPawnMovement()
                 }
            },
            { FigureType.Bishop, new List<IMovement>
                 {
                     new NormalBishopMovement()
                 }
            },
            { FigureType.Knight, new List<IMovement>
                 {
                     new NormalKnightMovement()
                 }
            },
            { FigureType.King, new List<IMovement>
                 {
                     new NormalKingMovement()
                 }
            },
            { FigureType.Rook, new List<IMovement>
                 {
                     new NormalRookMovement()
                 }
            },
            { FigureType.Queen, new List<IMovement>
                 {
                     new NormalBishopMovement(),
                     new NormalRookMovement()
                 }
            },
        };

        public IList<IMovement> GetMovements(FigureType figureType)
        {
            return this.movements[figureType];
        }
    }
}
