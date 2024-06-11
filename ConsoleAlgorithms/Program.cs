using BenchmarkDotNet.Running;
using System.Diagnostics;

//BenchmarkRunner.Run<Benchmarks>();

Stopwatch stopwatch1 = new Stopwatch();
stopwatch1.Start();
int reuslt1 = FibonacciRecursive(50);
stopwatch1.Stop();

Stopwatch stopwatch2 = new Stopwatch();
stopwatch2.Start();
int reuslt2 = FibonacciIterative(50);
stopwatch2.Stop();

Console.WriteLine($"Wyniki:\nRecursive: {reuslt1}, Time: {stopwatch1.Elapsed}\nIterative: {reuslt2}, Time: {stopwatch2.Elapsed}");

Console.ReadLine();


static int FibonacciRecursive(int n)
{
    if (n < 3)
        return 1;
    else
        return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
}

static int FibonacciIterative(int N)
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

static int Partition(int[] arr, int low, int high)
{
    int temp;
    int pivot = arr[high];

    // index of smaller element 
    int i = (low - 1);
    for (int j = low; j <= high - 1; j++)
    {

        // If current element is 
        // smaller than or 
        // equal to pivot 
        if (arr[j] <= pivot)
        {
            i++;

            // swap arr[i] and arr[j] 
            temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }

    // swap arr[i+1] and arr[high] 
    // (or pivot) 
    temp = arr[i + 1];
    arr[i + 1] = arr[high];
    arr[high] = temp;

    return i + 1;
}

/* The main function that implements 
QuickSort() arr[] --> Array to be  
sorted, 
low --> Starting index, 
high --> Ending index */
static void QuickSortRecursive(int[] arr, int low, int high)
{
    if (low < high)
    {
        /* pi is partitioning index,  
        arr[pi] is now at right place */
        int pi = Partition(arr, low, high);

        // Recursively sort elements 
        // before partition and after 
        // partition 
        QuickSortRecursive(arr, low, pi - 1);
        QuickSortRecursive(arr, pi + 1, high);
    }
}

static void QuickSortIterative(int[] arr,
                                   int l, int h)
{
    // Create an auxiliary stack 
    int[] stack = new int[h - l + 1];

    // initialize top of stack 
    int top = -1;

    // push initial values of l and h to 
    // stack 
    stack[++top] = l;
    stack[++top] = h;

    // Keep popping from stack while 
    // is not empty 
    while (top >= 0)
    {
        // Pop h and l 
        h = stack[top--];
        l = stack[top--];

        // Set pivot element at its 
        // correct position in 
        // sorted array 
        int p = Partition(arr, l, h);

        // If there are elements on 
        // left side of pivot, then 
        // push left side to stack 
        if (p - 1 > l)
        {
            stack[++top] = l;
            stack[++top] = p - 1;
        }

        // If there are elements on 
        // right side of pivot, then 
        // push right side to stack 
        if (p + 1 < h)
        {
            stack[++top] = p + 1;
            stack[++top] = h;
        }
    }
}