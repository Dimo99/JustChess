namespace JustChess.Renderers
{
    using System;
    using System.Threading;

    using Board;
    using Common;
    using Common.Console;
    using Contracts;

    public class ConsoleRenderer : IRenderer
    {
        private const string Logo = "JUST CHESS";
        private const ConsoleColor DarkSquareConsoleColor = ConsoleColor.DarkGray;
        private const ConsoleColor LightSquareConsoleColor = ConsoleColor.Gray;

        public ConsoleRenderer()
        {
            // TODO: change these magic values to something calculated
            if (Console.WindowWidth < ConsoleConstants.NeededWindowWidth || ConsoleConstants.NeededWindowHeight < 80)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Clear();
                Console.WriteLine("Please, set the Console window and buffer size to 100x80. For best experience use Raster Fonts 8x8!");
                Environment.Exit(0);
            }
        }

        public void RenderMainMenu()
        {
            ConsoleHelpers.SetCursorAtCenter(Logo.Length);
            Console.WriteLine(Logo);

            // TODO: add main menu
            Thread.Sleep(1000);
        }

        public void RenderBoard(Board board)
        {
            // TODO: validate Console dimensions
            var startColPrint = (Console.WindowWidth / 2) - (board.TotalRows / 2 * ConsoleConstants.CharactersPerRowPerBoardSquare);
            var startRowPrint = (Console.WindowHeight / 2) - (board.TotalCols / 2 * ConsoleConstants.CharactersPerColPerBoardSquare);

            ConsoleHelpers.PrintBorder(startColPrint, startRowPrint, board.TotalRows, board.TotalCols, DarkSquareConsoleColor);

            DrawMainBoard(board, startColPrint, startRowPrint);
        }

        private static void DrawMainBoard(Board board, int startColPrint, int startRowPrint)
        {
            int counter = 1;
            for (int top = 0; top < board.TotalRows; top++)
            {
                for (int left = 0; left < board.TotalCols; left++)
                {
                    var currentColPrint = startColPrint + (left * ConsoleConstants.CharactersPerColPerBoardSquare);
                    var currentRowPrint = startRowPrint + (top * ConsoleConstants.CharactersPerRowPerBoardSquare);

                    ConsoleColor backgroundColor;
                    if (counter % 2 == 0)
                    {
                        backgroundColor = DarkSquareConsoleColor;
                    }
                    else
                    {
                        backgroundColor = LightSquareConsoleColor;
                    }

                    var position = Position.FromArrayCoordinates(top, left, board.TotalRows);

                    var figure = board.GetFigureAtPosition(position);
                    ConsoleHelpers.PrintFigure(figure, backgroundColor, currentRowPrint, currentColPrint);

                    counter++;
                }

                counter++;
            }
        }

        public void PrintErrorMessage(string errorMessage)
        {
            ConsoleHelpers.ClearRow(ConsoleConstants.ConsoleRowForPlayerIO);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition((Console.WindowWidth / 2) - (errorMessage.Length / 2), ConsoleConstants.ConsoleRowForPlayerIO);
            Console.Write(errorMessage);
            Thread.Sleep(2000);
            ConsoleHelpers.ClearRow(ConsoleConstants.ConsoleRowForPlayerIO);
        }
    }
}
