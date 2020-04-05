namespace JustChess.Engine.Initializations
{
    using System;
    using System.Collections.Generic;

    using Board.Contracts;
    using Common;
    using Contracts;
    using Figures;
    using Figures.Contracts;
    using Players.Contracts;

    public class StandardStartGameInitializationStrategy : IGameInitializationStrategy
    {
        private const int BoardTotalRowsAndCols = 8;

        private readonly IList<FigureType> figureTypes;

        public StandardStartGameInitializationStrategy()
        {
            this.figureTypes = new List<FigureType>
            {
                FigureType.Rook,
                FigureType.Knight,
                FigureType.Bishop,
                FigureType.Queen,
                FigureType.King,
                FigureType.Bishop,
                FigureType.Knight,
                FigureType.Rook
            };
        }

        public void Initialize(IList<IPlayer> players, IBoard board)
        {
            this.ValidateStrategy(players, board);

            var firstPlayer = players[0];
            var secondPlayer = players[1];

            this.AddArmyToBoardRow(firstPlayer, board, 1);
            this.AddPawnsToBoardRow(firstPlayer, board, 2);

            this.AddPawnsToBoardRow(secondPlayer, board, 7);
            this.AddArmyToBoardRow(secondPlayer, board, 8);
        }

        private void AddPawnsToBoardRow(IPlayer player, IBoard board, int chessRow)
        {
            for (int i = 0; i < BoardTotalRowsAndCols; i++)
            {
                var pawn = new Figure(player.Color, FigureType.Pawn);
                player.AddFigure(pawn);
                var position = new Position(chessRow, (char)(i + 'a'));
                board.AddFigure(pawn, position);
            }
        }

        private void AddArmyToBoardRow(IPlayer player, IBoard board, int chessRow)
        {
            for (int i = 0; i < BoardTotalRowsAndCols; i++)
            {
                Figure figure = new Figure(player.Color, this.figureTypes[i]);
                player.AddFigure(figure);
                var position = new Position(chessRow, (char)(i + 'a'));
                board.AddFigure(figure, position);
            }
        }

        private void ValidateStrategy(ICollection<IPlayer> players, IBoard board)
        {
            if (players.Count != GlobalConstants.StandardGameNumberOfPlayers)
            {
                throw new InvalidOperationException("Standard Start Game Initialization Strategy needs exactly two players!");
            }

            if (board.TotalRows != BoardTotalRowsAndCols || board.TotalCols != BoardTotalRowsAndCols)
            {
                throw new InvalidOperationException("Standard Start Game Initialization Strategy needs 8x8 board!");
            }
        }
    }
}
