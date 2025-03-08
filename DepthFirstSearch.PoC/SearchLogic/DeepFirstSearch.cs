using DepthFirstSearch.PoC.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepthFirstSearch.PoC.SearchLogic
{
    public class DeepFirstSearch : IMazeSearch
    {
        private readonly char[,] _maze;
        private readonly (int, int)[] _directions = { (0, 1), (1, 0), (0, -1), (-1, 0) }; // Right, Down, Left, Up TODO: I wonder if randomising direction gives better performance?

        private readonly (int, int) _start;
        private readonly (int, int) _finish;

        private readonly int _rows;
        private readonly int _cols;

        private readonly int _delay;

        public DeepFirstSearch(char[,] maze, int delay = 1000)
        {
            _maze = maze;
            _start = MazeHelper.FindStart(_maze).Value;
            _finish = MazeHelper.FindFinish(_maze).Value;
            _rows = _maze.GetLength(0);
            _cols = _maze.GetLength(1);
            _delay = delay;
        }

        public IMazeSearch SetDelay(int delay)
        {
            return new DeepFirstSearch(_maze, delay);
        }

        private IMazeSearch ExecuteSearchRecursive(Stack<(int, int)> stack, HashSet<(int, int)> visited)
        {
            if (stack.Count == 0)
            {
                Console.WriteLine("No path found.");
                return this;
            }

            var (x, y) = stack.Pop();

            if ((_maze[x, y] != 'S') && (_maze[x, y] != 'F'))
            {
                _maze[x, y] = '.'; // Mark visited
            }

            MazeHelper.PrintMaze(_maze);
            Thread.Sleep(_delay); // Pause for visualization

            Console.WriteLine($"Visiting ({x}, {y})");

            if (CheckIfFinish(x, y))
            {
                return this;
            }

            var newStack = ProcessNeighbors(x, y, stack, visited);
            return ExecuteSearchRecursive(newStack, visited);
        }

        public IMazeSearch ExecuteSearch()
        {
            var stack = new Stack<(int, int)>();
            var visited = new HashSet<(int, int)>();

            stack.Push(_start);
            visited.Add(_start);

            return ExecuteSearchRecursive(stack, visited);
        }

        private bool CheckIfFinish(int x, int y)
        {
            if ((x, y) == _finish)
            {
                Console.WriteLine("Exit found!");
                return true;
            }
            return false;
        }

        private Stack<(int, int)> ProcessNeighbors(int x, int y, Stack<(int, int)> stack, HashSet<(int, int)> visited)
        {
            var newStack = new Stack<(int, int)>(stack);

            foreach (var (dx, dy) in _directions)
            {
                int newX = x + dx;
                int newY = y + dy;

                if (IsValid(newX, newY, visited))
                {
                    newStack.Push((newX, newY));
                    visited.Add((newX, newY));
                }
            }

            return newStack;
        }

        private bool IsValid(int x, int y, HashSet<(int, int)> visited)
        {
            if (_maze[x, y] == 'F') //Is this the finish?
            {
                return true;
            }

            if (x < 0 || x >= _rows) //Am I within the height of the maze?
            {
                return false;
            }

            if (y < 0 || y >= _cols) //Am I within the width of the maze?
            {
                return false;
            }

            if (_maze[x, y] != ' ') //Is this a wall?
            {
                return false;
            }

            if (visited.Contains((x, y))) //Have I already visited this cell?
            {
                return false;
            }

            return true;
        }
    }

}
