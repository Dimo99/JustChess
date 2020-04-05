namespace JustChess.Common.Console
{
    using System;
    using System.Collections.Generic;

    using Figure;

    public static partial class ConsoleHelpers
    {
        public static void PrintFigure(Figure figure, ConsoleColor backgroundColor, int top, int left)
        {
            if (figure == null)
            {
                PrintEmptySquare(backgroundColor, top, left);
                return;
            }

            if (!Patterns.ContainsKey(figure.FigureType))
            {
                return;
            }

            var figurePattern = Patterns[figure.FigureType];

            for (int i = 0; i < figurePattern.GetLength(0); i++)
            {
                for (int j = 0; j < figurePattern.GetLength(1); j++)
                {
                    Console.SetCursorPosition(left + j, top + i);
                    if (figurePattern[i, j])
                    {
                        Console.BackgroundColor = figure.Color.ToConsoleColor();
                    }
                    else
                    {
                        Console.BackgroundColor = backgroundColor;
                    }

                    Console.Write(" ");
                }
            }
        }

        public static void PrintBorder(int startCol, int startRow, int boardTotalRows, int boardTotalCols, ConsoleColor borderColor)
        {
            DrawLetters(startCol, startRow, boardTotalRows, boardTotalCols);
            DrawNumbers(startCol, startRow, boardTotalRows, boardTotalCols);

            DrawTopBorder(startCol, startRow, boardTotalRows, borderColor);
            DrawBottomBorder(startCol, startRow, boardTotalRows, borderColor);
            DrawRightBorder(startCol, startRow, boardTotalRows, boardTotalCols, borderColor);
            DrawLeftBorder(startCol, startRow, boardTotalCols, borderColor);
        }

        public static void SetCursorAtCenter(int lengthOfMessage)
        {
            int centerRow = Console.WindowHeight / 2;
            int centerCol = (Console.WindowWidth / 2) - (lengthOfMessage / 2);
            Console.SetCursorPosition(centerCol, centerRow);
        }

        public static ConsoleColor ToConsoleColor(this ChessColor chessColor)
        {
            switch (chessColor)
            {
                case ChessColor.Black:
                    return ConsoleColor.Black;
                case ChessColor.White:
                    return ConsoleColor.White;
                case ChessColor.Brown:
                    return ConsoleColor.DarkYellow;
                default:
                    throw new InvalidOperationException("Cannot convert chess color!");
            }
        }

        public static Move CreateMoveFromCommand(string command)
        {
            var positionAsStringParts = command.Split('-');
            if (positionAsStringParts.Length != 2)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            var fromAsString = positionAsStringParts[0];
            var toAsString = positionAsStringParts[1];

            var fromPosition = Position.FromChessCoordinates(fromAsString[1] - '0', fromAsString[0]);
            var toPosition = Position.FromChessCoordinates(toAsString[1] - '0', toAsString[0]);

            return new Move(fromPosition, toPosition);
        }

        public static void ClearRow(int row)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, row);
            Console.Write(new string(' ', Console.WindowWidth)); 
        }

        private static void PrintEmptySquare(ConsoleColor backgroundColor, int top, int left)
        {
            Console.BackgroundColor = backgroundColor;
            for (int i = 0; i < ConsoleConstants.CharactersPerRowPerBoardSquare; i++)
            {
                for (int j = 0; j < ConsoleConstants.CharactersPerColPerBoardSquare; j++)
                {
                    Console.SetCursorPosition(left + j, top + i);
                    Console.Write(" ");
                }
            }
        }

        private static void DrawLetters(int startCol, int startRow, int boardTotalRows, int boardTotalCols)
        {
            var start = startCol + (ConsoleConstants.CharactersPerRowPerBoardSquare / 2);
            for (int i = 0; i < boardTotalCols; i++)
            {
                Console.SetCursorPosition(start + (i * ConsoleConstants.CharactersPerRowPerBoardSquare), startRow - 1);
                Console.Write((char)('A' + i));
                Console.SetCursorPosition(start + (i * ConsoleConstants.CharactersPerRowPerBoardSquare), startRow + (boardTotalRows * ConsoleConstants.CharactersPerRowPerBoardSquare));
                Console.Write((char)('A' + i));
            }
        }

        private static void DrawNumbers(int startCol, int startRow, int boardTotalRows, int boardTotalCols)
        {
            var start = startRow + (ConsoleConstants.CharactersPerColPerBoardSquare / 2);
            for (int i = 0; i < boardTotalRows; i++)
            {
                Console.SetCursorPosition(startCol - 1, start + (i * ConsoleConstants.CharactersPerColPerBoardSquare));
                Console.Write(boardTotalRows - i);
                Console.SetCursorPosition(startCol + (boardTotalCols * ConsoleConstants.CharactersPerColPerBoardSquare), start + (i * ConsoleConstants.CharactersPerColPerBoardSquare));
                Console.Write(boardTotalRows - i);
            }
        }

        private static void DrawTopBorder(int startCol, int startRow, int boardTotalRows, ConsoleColor borderColor)
        {
            for (int i = startCol - 2; i < startCol + (boardTotalRows * ConsoleConstants.CharactersPerRowPerBoardSquare) + 2; i++)
            {
                DrawBorderBolck(i, startRow - 2, borderColor);
            }
        }

        private static void DrawBottomBorder(int startCol, int startRow, int boardTotalRows, ConsoleColor borderColor)
        {
            for (int i = startCol - 2; i < startCol + (boardTotalRows * ConsoleConstants.CharactersPerRowPerBoardSquare) + 2; i++)
            {
                DrawBorderBolck(i, startRow + (boardTotalRows * ConsoleConstants.CharactersPerRowPerBoardSquare) + 1, borderColor);
            }
        }

        private static void DrawRightBorder(int startCol, int startRow, int boardTotalRows, int boardTotalCols, ConsoleColor borderColor)
        {
            for (int i = startRow - 2; i < startRow + (boardTotalCols * ConsoleConstants.CharactersPerColPerBoardSquare) + 2; i++)
            {
                DrawBorderBolck(startCol + (boardTotalRows * ConsoleConstants.CharactersPerRowPerBoardSquare) + 1, i, borderColor);
            }
        }

        private static void DrawLeftBorder(int startCol, int startRow, int boardTotalCols, ConsoleColor borderColor)
        {
            for (int i = startRow - 2; i < startRow + (boardTotalCols * ConsoleConstants.CharactersPerColPerBoardSquare) + 2; i++)
            {
                DrawBorderBolck(startCol - 2, i, borderColor);
            }
        }

        private static void DrawBorderBolck(int col, int row, ConsoleColor borderColor)
        {
            Console.BackgroundColor = borderColor;
            Console.SetCursorPosition(col, row);
            Console.Write(" ");
        }
    }
}
