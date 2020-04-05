namespace JustChess.Movements.Contracts
{
    using Board;
    using Common;
    using Figure;

    public interface IMovement
    {
        void ValidateMove(Figure figure, Board board, Move move);
    }
}
