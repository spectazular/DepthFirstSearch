using DepthFirstSearch.PoC.SearchLogic;


namespace DeepFirstSearch.PoC.Tests
{
    [TestClass]
    public sealed class DeepFirstSearchTests
    {
        private char[,] _validMaze;
        private char[,] _noStartMaze;
        private char[,] _noFinishMaze;
        private int _delay = 0;

        [TestInitialize]
        public void Setup()
        {
            _validMaze = new char[,]
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

            _noStartMaze = new char[,]
            {
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', ' ', '#', '#', '#', '#', '#', '#', ' ', '#' },
                { '#', ' ', '#', ' ', ' ', ' ', ' ', '#', ' ', '#' },
                { '#', ' ', '#', ' ', '#', '#', ' ', '#', ' ', '#' },
                { '#', ' ', '#', ' ', '#', '#', ' ', '#', ' ', '#' },
                { '#', ' ', '#', ' ', ' ', ' ', ' ', '#', 'F', '#' },
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
            };

            _noFinishMaze = new char[,]
            {
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
                { '#', 'S', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                { '#', ' ', '#', '#', '#', '#', '#', '#', ' ', '#' },
                { '#', ' ', '#', ' ', ' ', ' ', ' ', '#', ' ', '#' },
                { '#', ' ', '#', ' ', '#', '#', ' ', '#', ' ', '#' },
                { '#', ' ', '#', ' ', '#', '#', ' ', '#', ' ', '#' },
                { '#', ' ', '#', ' ', ' ', ' ', ' ', '#', ' ', '#' },
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
            };
        }

        [TestMethod]
        public void ExecuteSearch_ValidMaze_FindsExit()
        {
            var result = new DepthFirstSearch.PoC.SearchLogic.DeepFirstSearch()
                .SetMaze(_validMaze)
                .SetDelay(_delay)
                .ExecuteSearch();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ExecuteSearch_NoStartMaze_ThrowsException()
        {
            string expectedError = "Result is in status failed. Value is not set. Having: Error with Message=''S' not found in the maze.'";
            string actualError = string.Empty;

            try
            {
                var search = new DepthFirstSearch.PoC.SearchLogic.DeepFirstSearch()
                    .SetMaze(_noStartMaze)
                    .SetDelay(_delay)
                    .ExecuteSearch();
            }
            catch (Exception ex)
            {
                actualError = ex.Message;
            }

            Assert.AreEqual(expectedError, actualError);
        }

        [TestMethod]
        public void ExecuteSearch_NoFinishMaze_ThrowsException()
        {
            string expectedError = "Result is in status failed. Value is not set. Having: Error with Message=''F' not found in the maze.'";
            string actualError = string.Empty;

            try
            {
                var search = new DepthFirstSearch.PoC.SearchLogic.DeepFirstSearch()
                    .SetMaze(_noFinishMaze)
                    .SetDelay(_delay)
                    .ExecuteSearch();
            }
            catch (Exception ex)
            {
                actualError = ex.Message;
            }

            Assert.AreEqual(expectedError, actualError);
        }
    }
}
