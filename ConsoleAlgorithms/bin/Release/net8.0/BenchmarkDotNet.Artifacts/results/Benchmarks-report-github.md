```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22621.3447/22H2/2022Update/SunValley2)
AMD Ryzen 7 PRO 5850U with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 8.0.300
  [Host]     : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2


```
| Method             | N  | Mean      | Error     | StdDev    |
|------------------- |--- |----------:|----------:|----------:|
| FibonacciRecursive | 10 | 95.120 ns | 1.9054 ns | 3.0222 ns |
| FibonacciIterative | 10 |  4.764 ns | 0.1313 ns | 0.3766 ns |
