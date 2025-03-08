using DepthFirstSearch.PoC.Helpers;

namespace DeepFirstSearch.PoC.Tests;

[TestClass]
public class MazeHelperTests
{
    private char[,] _maze;

    [TestInitialize]
    public void Setup()
    {
        _maze = new char[,]
        {
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
                { '#', 'S', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', ' ', '#', '#', '#', '#', '#', '#', ' ', '#' },
                { '#', ' ', '#', ' ', ' ', ' ', ' ', '#', ' ', '#' },
                { '#', ' ', '#', ' ', '#', '#', ' ', '#', ' ', '#' },
                { '#', ' ', '#', ' ', '#', '#', ' ', '#', ' ', '#' },
                { '#', ' ', '#', ' ', ' ', ' ', ' ', '#', 'F', '#' },
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
        };
    }

    [TestMethod]
    public void FindStart_ValidMaze_ReturnsStartPosition()
    {
        var result = MazeHelper.FindStart(_maze);

        Assert.IsTrue(result.IsSuccess);
        Assert.AreEqual((1, 1), result.Value);
    }

    [TestMethod]
    public void FindFinish_ValidMaze_ReturnsFinishPosition()
    {
        var result = MazeHelper.FindFinish(_maze);

        Assert.IsTrue(result.IsSuccess);
        Assert.AreEqual((6, 8), result.Value);
    }

    [TestMethod]
    public void FindLocation_TargetExists_ReturnsPosition()
    {
        var result = MazeHelper.FindLocation('S', _maze);

        Assert.IsTrue(result.IsSuccess);
        Assert.AreEqual((1, 1), result.Value);
    }

    [TestMethod]
    public void FindLocation_TargetDoesNotExist_ReturnsError()
    {
        var result = MazeHelper.FindLocation('X', _maze);

        Assert.IsFalse(result.IsSuccess);
        Assert.AreEqual("'X' not found in the maze.", result.Errors[0].Message);
    }
}
