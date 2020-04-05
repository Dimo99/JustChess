namespace JustChess.Player
{
    using System;
    using System.Collections.Generic;

    using Common;
    using Figure;

    public class Player
    {
        private readonly ICollection<Figure> figures;

        public Player(string name, ChessColor color)
        {
            // TODO: validate name length
            this.Name = name;
            this.figures = new List<Figure>();
            this.Color = color;
        }

        public string Name { get; private set; }

        public ChessColor Color { get; private set; }

        public void AddFigure(Figure figure)
        {
            ObjectValidator.CheckIfObjectIsNull(figure, GlobalErrorMessages.NullFigureErrorMessage);

            this.CheckFigureColor(figure);
            this.CheckIfFigureExists(figure);
            this.figures.Add(figure);
        }

        public void RemoveFigure(Figure figure)
        {
            ObjectValidator.CheckIfObjectIsNull(figure, GlobalErrorMessages.NullFigureErrorMessage);

            this.CheckFigureColor(figure);
            this.CheckIfFigureDoesNotExist(figure);
            this.figures.Remove(figure);
        }

        private void CheckFigureColor(Figure figure)
        {
            if (figure.Color != this.Color)
            {
                throw new InvalidOperationException(
                    $"{this.Color.ToString()} player can't operate with {figure.Color.ToString()} figure!");
            }
        }

        private void CheckIfFigureExists(Figure figure)
        {
            if (this.figures.Contains(figure))
            {
                throw new InvalidOperationException("This player already owns this figure!");
            }
        }

        private void CheckIfFigureDoesNotExist(Figure figure)
        {
            if (!this.figures.Contains(figure))
            {
                throw new InvalidOperationException("This player does not own this figure!");
            }
        }
    }
}
