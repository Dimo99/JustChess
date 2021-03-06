﻿namespace JustChess.Movements
{
    using System;

    using Board;
    using Common;
    using Figure;
    using Movements.Contracts;

    public class NormalKnightMovement : IMovement
    {
        private const string KnightInvalidMove = "{0}s cannot move this way!";

        public void ValidateMove(Figure figure, Board board, Move move)
        {
            var rowDistance = Math.Abs(move.From.Row - move.To.Row);
            var colDistance = Math.Abs(move.From.Col - move.To.Col);
            var color = figure.Color;
            var to = move.To;
            var figureAtPosition = board.GetFigureAtPosition(to);

            if (figureAtPosition == null || color != figureAtPosition.Color)
            {
                if (rowDistance == 2 && colDistance == 1)
                {
                    return;
                }
                else if (colDistance == 2 && rowDistance == 1)
                {
                    return;
                }
            }

            throw new InvalidOperationException(KnightInvalidMove);
        }
    }
}
