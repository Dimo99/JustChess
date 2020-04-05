namespace JustChess.Renderers.Contracts
{
    using Board;

    public interface IRenderer
    {
        void RenderMainMenu();

        void RenderBoard(Board board);

        void PrintErrorMessage(string errorMessage);
    }
}
