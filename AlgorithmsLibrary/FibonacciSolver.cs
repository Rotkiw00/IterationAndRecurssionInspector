namespace AlgorithmsLibrary
{
    public static class FibonacciSolver
    {
        public static long Recursion(long n)
        {
            if (n < 3)
                return 1;
            else
                return Recursion(n - 1) + Recursion(n - 2);
        }

        public static long Iteration(long n)
        {
            if (n <= 1)
                return n;

            int a = 0, b = 1;
            for (int i = 2; i <= n; i++)
            {
                int temp = a + b;
                a = b;
                b = temp;
            }
            return b;
        }

        public static (long, List<long>) GetSumAndFibonacciSequence(long n)
        {
            List<long> fibonacciSequence = [];
            for (int i = 0; i <= n; i++)
            {
                long fiboNum = Iteration(i);
                fibonacciSequence.Add(fiboNum);
            }

            long sumOfFiboSequence = fibonacciSequence.Sum();

            return (sumOfFiboSequence, fibonacciSequence);
        }
    }
}
