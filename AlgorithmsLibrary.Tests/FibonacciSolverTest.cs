namespace AlgorithmsLibrary.Tests
{
    public class FibonacciSolverTest
    {
        [Fact]
        public void FibonacciSolver_DetermineByRecursionFibonacciSequenceFor5_ReturnsCorrectValue()
        {
            #region ARRANGE
            const int Nth_WORD_OF_FIBONACCI_SEQUENCE = 5;
            #endregion

            #region ACT
            long finalResult = FibonacciSolver.Recursion(Nth_WORD_OF_FIBONACCI_SEQUENCE);
            #endregion

            #region ASSERT
            Assert.Equal(5, finalResult);
            #endregion
        }

        [Fact]
        public void FibonacciSolver_DetermineByRecursionFibonacciSequenceFor15_ReturnsCorrectValue()
        {
            #region ARRANGE
            const int Nth_WORD_OF_FIBONACCI_SEQUENCE = 15;
            #endregion

            #region ACT
            long finalResult = FibonacciSolver.Recursion(Nth_WORD_OF_FIBONACCI_SEQUENCE);
            #endregion

            #region ASSERT
            Assert.Equal(610, finalResult);
            #endregion
        }

        [Fact]
        public void FibonacciSolver_DetermineByIterationFibonacciSequenceFor10_ReturnsCorrectValue()
        {
            #region ARRANGE
            const int Nth_WORD_OF_FIBONACCI_SEQUENCE = 10;
            #endregion

            #region ACT
            long finalResult = FibonacciSolver.Iteration(Nth_WORD_OF_FIBONACCI_SEQUENCE);
            #endregion

            #region ASSERT
            Assert.Equal(55, finalResult);
            #endregion
        }

        [Fact]
        public void FibonacciSolver_DetermineByIterationFibonacciSequenceFor20_ReturnsCorrectValue()
        {
            #region ARRANGE
            const int Nth_WORD_OF_FIBONACCI_SEQUENCE = 20;
            #endregion

            #region ACT
            long finalResult = FibonacciSolver.Iteration(Nth_WORD_OF_FIBONACCI_SEQUENCE);
            #endregion

            #region ASSERT
            Assert.Equal(6765, finalResult);
            #endregion
        }
    }
}