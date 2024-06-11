using BenchmarkDotNet.Attributes;

namespace ConsoleAlgorithms
{
    public record FibonacciBenchmarks([property: Params(10)] int N)
    {
        [Benchmark]
        public int FibonacciRecursive() => FibonacciRecursive(N);

        static int FibonacciRecursive(int n)
        {
            if (n < 3)
                return 1;
            else
                return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
        }

        [Benchmark]
        public int FibonacciIterative()
        {
            if (N <= 1)
                return N;

            int a = 0, b = 1;
            for (int i = 2; i <= N; i++)
            {
                int temp = a + b;
                a = b;
                b = temp;
            }
            return b;
        }
    }
}