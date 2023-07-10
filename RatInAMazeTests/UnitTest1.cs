using RatInAMazeConsole;

namespace RatInAMazeTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            int [,] mazeInputArray = new int[,]
            {
                { 1, 0, 0, 0 },
                { 1, 1, 0, 1 },
                { 0, 1, 0, 0 },
                { 1, 1, 1, 1 }
            };

            int[,] mazeSolution = new int[,]
            {
                { 1, 0, 0, 0 },
                { 1, 1, 0, 0 },
                { 0, 1, 0, 0 },
                { 0, 1, 1, 1 }
            };

            int[,] result = new BackingTrackSolution().SolveMaze(mazeInputArray);
            Assert.IsTrue(mazeSolution.Cast<int>().SequenceEqual(result.Cast<int>()));
        }
    }
}