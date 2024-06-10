int result1 = FibonacciRecursive(10);
int result2 = FibonacciIterative(10);
Console.WriteLine($"R: {result1} | I: {result2}");
Console.ReadLine();


static int FibonacciRecursive(int n)
{
    if (n < 3)
        return 1;
    else
        return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
}

static int FibonacciIterative(int n)
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
