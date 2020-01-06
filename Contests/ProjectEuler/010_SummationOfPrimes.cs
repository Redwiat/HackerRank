using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

//Project Euler #10: Summation of primes
//https://www.hackerrank.com/contests/projecteuler/challenges/euler010/problem
class Solution
{
  static SortedDictionary<int, long> Total = new SortedDictionary<int, long>();
  static Dictionary<int, bool> IsPrimeDic = new Dictionary<int, bool>() { { 0, false }, { 1, false }, { 2, true }, { 3, true }, { 4, false }, { 5, true }, { 6, false }, { 7, true }, { 8, false }, { 9, false }, { 10, false }, { 11, true } };
  //static readonly List<int> Primes = new List<int>() { 2, 3, 5, 7, 11 };
  static bool IsPrime(int n)
  {
    if (!IsPrimeDic.ContainsKey(n))
    {
      if (n % 2 == 0 || n % 3 == 0 || n % 5 == 0)
      {
        IsPrimeDic.Add(n, false);
        return false;
      }

      long count = 3;
      while ((count * count) <= n)
      {
        if (n % count == 0)
        {
          IsPrimeDic.Add(n, false);
          return false;
        }

        count += 2;
      }

      //Primes.Add(n);
      IsPrimeDic.Add(n, true);
      return true;
    }

    return IsPrimeDic[n];
  }

  static long GetSumOfPrimesUntil(int n)
  {
    if (Total.ContainsKey(n))
      return Total[n];

    long total = 0;
    int init = 0;
    foreach (var t in Total)
    {
      if (t.Key > n)
        break;

      init = t.Key + 1;
      total = t.Value;
    }

    for (int i = init; i <= n; i++)
    {
      if (IsPrime(i))
        total += i;

      if (!Total.ContainsKey(i))
        Total.Add(i, total);
    }

    return total;
  }

  static void Main(String[] args)
  {
    int t = Convert.ToInt32(Console.ReadLine());

    //var sw2 = System.Diagnostics.Stopwatch.StartNew();
    //GetSumOfPrimesUntil(1000000);
    for (int a0 = 0; a0 < t; a0++)
    {
      int n = Convert.ToInt32(Console.ReadLine());

      //var sw = System.Diagnostics.Stopwatch.StartNew();
      Console.WriteLine(GetSumOfPrimesUntil(n));
      //Console.WriteLine($" '{n}' took: " + sw.ElapsedMilliseconds / 1000.0 + "s");
    }
    //Console.WriteLine($"Everything  took: " + sw2.ElapsedMilliseconds / 1000.0 + "s");
  }

}
