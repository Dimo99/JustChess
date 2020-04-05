﻿namespace JustChess.Movements.Contracts
{
    using Board.Contracts;
    using Common;
    using Figures.Contracts;

    public interface IMovement
    {
        void ValidateMove(Figure figure, IBoard board, Move move);
    }
}
