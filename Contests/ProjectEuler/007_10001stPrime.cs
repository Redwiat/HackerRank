using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

//Project Euler #7: 10001st prime
//https://www.hackerrank.com/contests/projecteuler/challenges/euler007/problem
class Solution
{

  static Dictionary<long, bool> IsPrimeDic = new Dictionary<long, bool>() { { 0, false }, { 1, false }, { 2, true }, { 3, true }, { 4, false }, { 5, true }, { 6, false }, { 7, true }, { 8, false }, { 9, false }, { 10, false }, { 11, true } };
  static readonly List<int> Primes = new List<int>() { 2, 3, 5, 7, 11 };
  static bool IsPrime(int n)
  {
    if (!IsPrimeDic.ContainsKey(n))
    {
      if (n % 2 == 0 || n % 3 == 0 || n % 5 == 0)
      {
        IsPrimeDic.Add(n, false);
        return false;
      }

      //Faster (don't look for even numbers)
      var count = 3;
      while ((count * count) <= n)
      {
        if (n % count == 0)
        {
          IsPrimeDic.Add(n, false);
          return false;
        }

        count += 2;
      }

      Primes.Add(n);
      IsPrimeDic.Add(n, true);
      return true;
    }

    return IsPrimeDic[n];
  }

  static int GetNextPrime(int n)
  {
    var startPoint = Primes.LastOrDefault();
    var i = Primes.Count;
    while (true)
    {
      if (i == n)
        return Primes.LastOrDefault();

      startPoint++;
      if (IsPrime(startPoint))
        i++;
    }
  }

  static int GetPrimeAtPosition(int n)
  {
    if (Primes.Count >= n) //Optimized way for sequential invocations
      return Primes.ElementAt(n - 1);

    return GetNextPrime(n);
  }

  static void Main(String[] args)
  {
    int t = Convert.ToInt32(Console.ReadLine());

    //var sw2 = System.Diagnostics.Stopwatch.StartNew();
    for (int a0 = 0; a0 < t; a0++)
    {
      int n = Convert.ToInt32(Console.ReadLine());

      //var sw = System.Diagnostics.Stopwatch.StartNew();
      Console.WriteLine(GetPrimeAtPosition(n));
      //Console.WriteLine($"GetPrimeAtPosition for '{n}' took: " + sw.ElapsedMilliseconds / 1000.0 + "s");
    }
    //Console.WriteLine($"Everything  took: " + sw2.ElapsedMilliseconds / 1000.0 + "s");
  }

}