namespace AlgorithmsLibrary
{
    public static class FibonacciSolver
    {
        public static int Recursion(int n)
        {
            if (n < 3)
                return 1;
            else
                return Recursion(n - 1) + Recursion(n - 2);
        }

        public static int Iteration(int n)
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
    }
}
