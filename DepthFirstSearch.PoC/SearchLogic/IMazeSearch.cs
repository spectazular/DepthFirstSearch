namespace DepthFirstSearch.PoC.SearchLogic
{
    public interface IMazeSearch
    {
        IMazeSearch SetMaze(char[,] maze);
        IMazeSearch ExecuteSearch();
    }
}
