using DepthFirstSearch.PoC.Helpers;
using DepthFirstSearch.PoC.Repository;
using Serilog;
using Microsoft.Extensions.DependencyInjection;
using FluentResults;
using DepthFirstSearch.PoC.SearchLogic;

char[,] maze = null;

using var log = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("log.txt")
    .CreateLogger();

Console.WriteLine("Starting Maze app!");

Result<char[,]> mazeResult = new MazeRepository()
    .SetMazeFilePath(@"MazeStructure\maze1.txt")
    .GetMaze();

if (mazeResult.IsFailed)
{
    Console.WriteLine(mazeResult.Errors[0].Message);
}
else
{
    maze = mazeResult.Value;
    MazeHelper.PrintMaze(maze);

    DeepFirstSearch deepFirstSearch = new DeepFirstSearch()
        .SetMaze(maze)
        .ExecuteSearch();
}
