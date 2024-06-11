using System.Diagnostics;
using AlgorithmsLibrary;

//Stopwatch stopwatch1 = new Stopwatch();
//stopwatch1.Start();
//int reuslt1 = FibonacciSolver.Recursion(50);
//stopwatch1.Stop();

//Stopwatch stopwatch2 = new Stopwatch();
//stopwatch2.Start();
//int reuslt2 = FibonacciSolver.Iteration(50);
//stopwatch2.Stop();

//Console.WriteLine($"Wyniki:\nRecursive: {reuslt1}, Time: {stopwatch1.Elapsed}\nIterative: {reuslt2}, Time: {stopwatch2.Elapsed}");

Stopwatch stopwatch3 = new Stopwatch();
var table1 = Utility.GetSortingData(10);
Utility.PrintData(table1);
stopwatch3.Start();
QuicksortSolver.Recursion(table1, 0, table1.Length - 1);
stopwatch3.Stop();
Console.WriteLine(stopwatch3.Elapsed);
Utility.PrintData(table1);


Stopwatch stopwatch4 = new Stopwatch();
var table2 = Utility.GetSortingData(10);
Utility.PrintData(table2);
stopwatch4.Start();
QuicksortSolver.Iteration(table2, 0, table2.Length - 1);
stopwatch4.Stop();
Console.WriteLine(stopwatch4.Elapsed);
Utility.PrintData(table2);

Console.ReadLine();

