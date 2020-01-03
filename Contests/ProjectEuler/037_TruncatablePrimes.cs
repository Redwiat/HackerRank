using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

//Project Euler #37: Truncatable primes
//https://www.hackerrank.com/contests/projecteuler/challenges/euler037/problem
class Solution
{


  static readonly SortedDictionary<int, int> TruncatablePrimes = new SortedDictionary<int, int>();
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

  private static bool IsTruncatablePrime(int i)
  {
    if (!IsPrime(i))
      return false;

    if (i < 11)
      return false;

    string numberAsStringRight = i.ToString();
    string numberAsStringLeft = numberAsStringRight;

    while (numberAsStringLeft.Length > 1)
    {
      numberAsStringLeft = numberAsStringLeft.Remove(0, 1);
      if (!IsPrime(int.Parse(numberAsStringLeft)))
        return false;

      numberAsStringRight = numberAsStringRight.Remove(numberAsStringRight.Length - 1, 1);
      if (!IsPrime(int.Parse(numberAsStringRight)))
        return false;
    }

    return true;
  }


  static void GetOrAddToTruncatablePrimesDic(int n)
  {

    var last = TruncatablePrimes.LastOrDefault();
    if (!last.Equals(default(KeyValuePair<int, int>)) && last.Value > n)
      return;

    var startValue = TruncatablePrimes.Count > 0 ? last.Value : 0;
    for (int i = startValue; i < n; i++)
    {
      if (IsTruncatablePrime(i))
      {
        TruncatablePrimes.Add(i, i);
      }
    }
  }

  static int SumOfTruncatablePrimesOf(int n)
  {
    if (n < 11)
      return 0;

    GetOrAddToTruncatablePrimesDic(n);
    var ret = 0;
    foreach (var truncatablePrime in TruncatablePrimes)
    {
      if (truncatablePrime.Key < n)
        ret = ret + truncatablePrime.Value;
      if (truncatablePrime.Key > n)
        break;
    }

    return ret;
  }
  static void Main(String[] args)
  {
    int n = Convert.ToInt32(Console.ReadLine());

    //var sw2 = System.Diagnostics.Stopwatch.StartNew();
    Console.WriteLine(SumOfTruncatablePrimesOf(n));
    //Console.WriteLine($"Everything  took: " + sw2.ElapsedMilliseconds / 1000.0 + "s");
  }
}