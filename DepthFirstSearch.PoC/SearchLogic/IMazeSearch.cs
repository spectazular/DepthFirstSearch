namespace DepthFirstSearch.PoC.SearchLogic
{
    public interface IMazeSearch
    {
        IMazeSearch ExecuteSearch();
        IMazeSearch SetDelay(int delay);
    }
}
