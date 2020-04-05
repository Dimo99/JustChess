namespace JustChess.Players
{
    using System;
    using System.Collections.Generic;

    using Common;
    using Contracts;
    using Figures.Contracts;

    public class Player : IPlayer
    {
        private readonly ICollection<IFigure> figures;

        public Player(string name, ChessColor color)
        {
            // TODO: validate name length
            this.Name = name;
            this.figures = new List<IFigure>();
            this.Color = color;
        }

        public string Name { get; private set; }

        public ChessColor Color { get; private set; }

        public void AddFigure(IFigure figure)
        {
            ObjectValidator.CheckIfObjectIsNull(figure, GlobalErrorMessages.NullFigureErrorMessage);

            this.CheckFigureColor(figure);
            this.CheckIfFigureExists(figure);
            this.figures.Add(figure);
        }

        public void RemoveFigure(IFigure figure)
        {
            ObjectValidator.CheckIfObjectIsNull(figure, GlobalErrorMessages.NullFigureErrorMessage);

            this.CheckFigureColor(figure);
            this.CheckIfFigureDoesNotExist(figure);
            this.figures.Remove(figure);
        }

        private void CheckFigureColor(IFigure figure)
        {
            if (figure.Color != this.Color)
            {
                throw new InvalidOperationException(
                    $"{this.Color.ToString()} player can't operate with {figure.Color.ToString()} figure!");
            }
        }

        private void CheckIfFigureExists(IFigure figure)
        {
            if (this.figures.Contains(figure))
            {
                throw new InvalidOperationException("This player already owns this figure!");
            }
        }

        private void CheckIfFigureDoesNotExist(IFigure figure)
        {
            if (!this.figures.Contains(figure))
            {
                throw new InvalidOperationException("This player does not own this figure!");
            }
        }
    }
}
