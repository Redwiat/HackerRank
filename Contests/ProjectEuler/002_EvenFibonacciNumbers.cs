using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

//Project Euler #2: Even Fibonacci numbers
//https://www.hackerrank.com/contests/projecteuler/challenges/euler002/problem
class Solution
{

  //static SortedDictionary<long, long> Total = new SortedDictionary<long, long>();
  private static SortedDictionary<long, long> Fibonacci = new SortedDictionary<long, long>() { { 0, 1 }, { 1, 2 }, { 2, 5 }, { 3, 8 } };
  private static SortedDictionary<long, long> FibonacciEven = new SortedDictionary<long, long>() { { 0, 2 }, { 1, 8 } };

  private static long SumEvenFibonacciUntil(long n)
  {
    if (Fibonacci.LastOrDefault().Value < n)
      throw new Exception("Should have used this method you need all even first!");

    long sum = 0;
    foreach (var evenFib in FibonacciEven)
    {
      if (evenFib.Value > n)
        return sum;
      sum = sum + evenFib.Value;
    }

    return sum;
  }
  static long GetSumOfFibonacciUntil(long n)
  {
    if (Fibonacci.LastOrDefault().Value >= n)
      return SumEvenFibonacciUntil(n);

    var count = Fibonacci.Count;
    var totalDic = Fibonacci.LastOrDefault();
    long init = totalDic.Key;
    long last = totalDic.Value;
    for (long i = init; i <= n; i++)
    {
      var previous = Fibonacci[count - 2];
      var current = Fibonacci[count - 1];
      var fib = previous + current;

      Fibonacci.Add(count, fib);
      if (fib % 2 == 0)
        FibonacciEven.Add(FibonacciEven.Count, fib);

      count++;
      if (fib > n)
        break;
    }

    return SumEvenFibonacciUntil(n);
  }


  static void Main(String[] args)
  {
    int t = Convert.ToInt32(Console.ReadLine());
    for (int a0 = 0; a0 < t; a0++)
    {
      long n = Convert.ToInt64(Console.ReadLine());
      Console.WriteLine(GetSumOfFibonacciUntil(n));
    }
  }
}