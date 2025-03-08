using FluentResults;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepthFirstSearch.PoC.Helpers
{
    public static class MazeHelper
    {
        public static Result<(int,int)> FindStart(char[,] maze)
        {
            return FindLocation('S', maze);
        }

        public static Result<(int, int)> FindFinish(char[,] maze)
        {
            return FindLocation('F', maze);
        }

        public static Result<(int, int)> FindLocation(char target, char[,] maze)
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (maze[i, j] == target)
                    {
                        return Result.Ok((i, j));
                    }
                }
            }
            return Result.Fail<(int, int)>($"'{target}' not found in the maze.");
        }

        public static void PrintMaze(char[,] maze)
        {
            int rows = maze.GetLength(0);
            int cols = maze.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(maze[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
