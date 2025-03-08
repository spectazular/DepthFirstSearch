using DepthFirstSearch.PoC.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepthFirstSearch.PoC.SearchLogic
{
    public class DeepFirstSearch(char[,] _maze)
    {
        private (int, int)[] _directions = { (0, 1), (1, 0), (0, -1), (-1, 0) }; // Right, Down, Left, Up

        private (int, int) _start = MazeHelper.FindStart(_maze).Value;
        private (int, int) _finish = MazeHelper.FindFinish(_maze).Value;

        private int _rows = _maze.GetLength(0);
        private int _cols = _maze.GetLength(1);

        public void ExecuteSearch()
        {
            Stack<(int, int)> stack = new Stack<(int, int)>();
            HashSet<(int, int)> visited = new HashSet<(int, int)>();

            stack.Push(_start);
            visited.Add(_start);

            while (stack.Count > 0)
            {
                var (x, y) = stack.Pop();
                if (_maze[x, y] != 'S') _maze[x, y] = '.'; // Mark visited

                MazeHelper.PrintMaze(_maze);
                Thread.Sleep(300); // Pause for visualization

                if ((x, y) == _finish)
                {
                    Console.WriteLine("Exit found!");
                    return;
                }

                foreach (var (dx, dy) in _directions)
                {
                    int newX = x + dx;
                    int newY = y + dy;

                    if (IsValid(newX, newY, visited))
                    {
                        stack.Push((newX, newY));
                        visited.Add((newX, newY));
                    }
                }
            }

            Console.WriteLine("No path found.");
        }

        private bool IsValid(int x, int y, HashSet<(int, int)> visited)
        {
            return x >= 0 && x < _rows && y >= 0 && y < _cols &&
                   _maze[x, y] == ' ' && !visited.Contains((x, y));
        }
    }

}
