using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

//Project Euler #50: Consecutive prime sum
//https://www.hackerrank.com/contests/projecteuler/challenges/euler050/problem
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

      Primes.Add(n);
      IsPrimeDic.Add(n, true);
      return true;
    }
    return IsPrimeDic[n];
  }

  static long GetNextPrime(long n)
  {
    long startPoint = n;
    while (true)
    {
      startPoint++;
      if (IsPrime(startPoint))
        return startPoint;
    }
  }

  private static bool GetValue(long n, ref long nextprime, ref long sum, ref long numberOfPrimes, ref long sumT,
    ref long numberOfPrimesT)
  {
    while (true)
    {
      nextprime = GetNextPrime(nextprime);
      sum += nextprime;
      if (sum > n)
        break;

      numberOfPrimes++;
      if (IsPrime(sum))
      {
        sumT = sum;
        numberOfPrimesT = numberOfPrimes;
      }

    }

    return false;
  }

  private static Dictionary<long, long> MinTotal = new Dictionary<long, long>();
  static void PrintSum(long n)
  {
    long sum = 2;
    long numberOfPrimes = 1;
    long sumT = 2;
    long numberOfPrimesT = 1;

    long nextprime = 2;

    long sqrt = (int)Math.Ceiling(Math.Sqrt(n));
    long i = 0;
    while (i < sqrt)
    {
      if (IsPrime(i) && i <= 131)
      {
        nextprime = i;
        sum = i;
        sumT = sum;
        numberOfPrimes = 1;
        numberOfPrimesT = 1;
        GetValue(n, ref nextprime, ref sum, ref numberOfPrimes, ref sumT, ref numberOfPrimesT);
        if (MinTotal.ContainsKey(numberOfPrimesT))
        {
          if (MinTotal[numberOfPrimesT] > sumT)
          {
            MinTotal[numberOfPrimesT] = sumT;
          }
        }
        else
        {
          MinTotal.Add(numberOfPrimesT, sumT);
        }
      }

      i++;
    }

    var maxKey = MinTotal.Keys.Max();
    Console.WriteLine(MinTotal[maxKey] + " " + maxKey);
  }

  static void Main(String[] args)
  {
    int t = Convert.ToInt32(Console.ReadLine());

    //var sw2 = System.Diagnostics.Stopwatch.StartNew();
    for (int a0 = 0; a0 < t; a0++)
    {
      int n = Convert.ToInt32(Console.ReadLine());

      //var sw = System.Diagnostics.Stopwatch.StartNew();
      PrintSum(n);
      MinTotal.Clear();
      //Console.WriteLine($"GetPrimeAtPosition for '{n}' took: " + sw.ElapsedMilliseconds / 1000.0 + "s");
    }
    //Console.WriteLine($"Everything  took: " + sw2.ElapsedMilliseconds / 1000.0 + "s");

  }

}
