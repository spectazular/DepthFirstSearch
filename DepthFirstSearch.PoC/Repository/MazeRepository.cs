using DepthFirstSearch.PoC.Helpers;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepthFirstSearch.PoC.Repository
{
    public class MazeRepository() : IMazeRepository
    {
        private string? _mazeFilePath;

        public IMazeRepository SetMazeFilePath(string mazeFilePath)
        {
            this._mazeFilePath = mazeFilePath;
            return this;
        }

        public Result<char[,]> GetMaze()
        {
            try
            {
                if (File.Exists(_mazeFilePath) == false)
                {
                    return Result.Fail<char[,]>("Maze file not found.");
                }

                var lines = File.ReadAllLines(_mazeFilePath).ToList();
                int rows = lines.Count;
                int cols = lines[0].Length;
                var retval = new char[rows, cols];

                lines.SelectMany((line, rowIndex) => line.Select((ch, colIndex) => new { ch, rowIndex, colIndex }))
                     .ToList()
                     .ForEach(x => retval[x.rowIndex, x.colIndex] = x.ch);

                if(MazeHelper.FindStart(retval).IsFailed)
                {
                    return Result.Fail<char[,]>("Maze does not contain a start point.");
                }

                if (MazeHelper.FindFinish(retval).IsFailed)
                {
                    return Result.Fail<char[,]>("Maze does not contain a finish point.");
                }

                return Result.Ok(retval);
            }
            catch (Exception ex)
            {
                return Result.Fail<char[,]>($"Error reading maze file: {ex.Message}");
            }
        }
    }
}
