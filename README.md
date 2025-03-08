# Deep First Search

This code base is related to learning maze search algorithms, starting with Depth First Search (DFS).

> :warning: **Warning:** The search (Deep First Search) logic is a work in progress and is not yet complete.

## Project Structure

- `DepthFirstSearch.PoC/Program.cs`: The main entry point of the application.
- `DepthFirstSearch.PoC/Helpers/MazeHelper.cs`: Contains helper methods for maze operations.
- `DepthFirstSearch.PoC/Repository/MazeRepository.cs`: Handles maze file reading and provides the maze data.
- `DepthFirstSearch.PoC/SearchLogic/DeepFirstSearch.cs`: Implements the Depth First Search algorithm for solving the maze.

## Features

- Read maze structure from a file.
- Perform Depth First Search to find a path from the start to the finish (algorythm still being worked on!!).
- Visualize the search process in the console.

## Usage

1. Ensure you have .NET 9 installed.
2. Clone the repository.
3. Open the solution in Visual Studio 2022.
4. Update the maze txt file and file path in `Program.cs` if necessary.
5. Run the project.

## Example

### Define the maze structure
The maze1.txt file contains the maze structure represented as a grid of characters. Each character in the file represents a specific element of the maze. 
The file is read line by line, and each line corresponds to a row in the maze.

#### Characters Used
- `S`: Start position
- `F`: Finish position
- `#`: Wall
- ` ` (space): Open path

#### Example
Here is an example of what the maze1.txt file might look like:
```
#######
#   #F#
# # # #
#S#   #
#######
```

Here is an example of how to use the `MazeRepository` and `DeepFirstSearch` classes:

```csharp
using DepthFirstSearch.PoC.Helpers;
using DepthFirstSearch.PoC.Repository;
using DepthFirstSearch.PoC.SearchLogic;
using Serilog;
using FluentResults;

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

    var search = new DeepFirstSearch()
        .SetMaze(maze)
        .ExecuteSearch();
}
```

## Contributing

Contributions are welcome! Please open an issue or submit a pull request.

## License

This project is licensed under the MIT License.

