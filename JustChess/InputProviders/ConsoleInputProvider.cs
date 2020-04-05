namespace JustChess.InputProviders
{
    using System;
    using System.Collections.Generic;

    using Common;
    using Common.Console;
    using Contracts;
    using Player;

    public class ConsoleInputProvider : IInputProvider
    {
        private const string PlayerNameText = "Enter Player {0} name: ";

        public IList<Player> GetPlayers(int numberOfPlayers)
        {
            var players = new List<Player>();
            for (int i = 1; i <= numberOfPlayers; i++)
            {
                Console.Clear();
                ConsoleHelpers.SetCursorAtCenter(PlayerNameText.Length);
                Console.Write(string.Format(PlayerNameText, i));
                string name = Console.ReadLine();
                var player = new Player(name, (ChessColor)(i - 1));
                players.Add(player);
            }

            return players;
        }

        /// <summary>
        /// Command is in format : a5-c5
        /// </summary>
        public Move GetNextPlayerMove(Player player)
        {
            ConsoleHelpers.ClearRow(ConsoleConstants.ConsoleRowForPlayerIO);
            Console.SetCursorPosition((Console.WindowWidth / 2) - 10, ConsoleConstants.ConsoleRowForPlayerIO);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("{0} is next: ", player.Name);
            var positionAsString = Console.ReadLine().Trim().ToLower();
            return ConsoleHelpers.CreateMoveFromCommand(positionAsString);
        }
    }
}
