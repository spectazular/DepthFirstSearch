using FluentResults;

namespace DepthFirstSearch.PoC.Repository
{
    public interface IMazeRepository
    {
        IMazeRepository SetMazeFilePath(string mazeFilePath);
        Result<char[,]> GetMaze();
    }
}
