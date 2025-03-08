using DepthFirstSearch.PoC.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepthFirstSearch.PoC.SearchLogic
{
    public class DeepFirstSearch
    {
        private char[,] _maze;
        private (int, int)[] _directions = { (0, 1), (1, 0), (0, -1), (-1, 0) }; // Right, Down, Left, Up

        private (int, int) _start;
        private (int, int) _finish;

        private int _rows;
        private int _cols;

        //public DeepFirstSearch() { }

        public DeepFirstSearch SetMaze(char[,] maze)
        {
            _maze = maze;
            _start = MazeHelper.FindStart(_maze).Value;
            _finish = MazeHelper.FindFinish(_maze).Value;
            _rows = _maze.GetLength(0);
            _cols = _maze.GetLength(1);
            return this;
        }

        public DeepFirstSearch ExecuteSearch()
        {
            Stack<(int, int)> stack = new Stack<(int, int)>();
            HashSet<(int, int)> visited = new HashSet<(int, int)>();

            stack.Push(_start);
            visited.Add(_start);

            while (stack.Count > 0)
            {
                var (x, y) = stack.Pop();

                if ((_maze[x, y] != 'S') && (_maze[x, y] != 'F'))
                { 
                    _maze[x, y] = '.'; // Mark visited
                } 

                MazeHelper.PrintMaze(_maze);
                Thread.Sleep(1000); // Pause for visualization

                Console.WriteLine($"Visiting ({x}, {y})");

                if ((x, y) == _finish)
                {
                    Console.WriteLine("Exit found!");
                    return this;
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
            return this;
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
