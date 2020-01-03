using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

//Leonardo's Prime Factors
//https://www.hackerrank.com/challenges/leonardo-and-prime/problem
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

      var count = 2;
      while (count <= n)
      {
        if (count != n && count != 1 && (n % count == 0))
        {
          IsPrimeDic.Add(n, false);
          return false;
        }
        count++;
      }

      Primes.Add(n);
      IsPrimeDic.Add(n, true);
      return true;
    }

    return IsPrimeDic[n];
  }

  static int primeCount(long n)
  {
    var count = 0;
    BigInteger res = new BigInteger(1);
    if (Primes.Count > 0) //Optimized way for sequential invocations
    {
      foreach (var prime in Primes)
      {
        if (res * prime > n)
          return count;

        count++;
        res = res * prime;
      }
    }

    count = 0;
    res = 1;
    for (var i = 1; i <= n; i++)
    {
      if (IsPrime(i))
      {
        if (res * i > n)
          return count;

        count++;
        res = res * i;
      }
    }

    return count;
  }

  static void Main(string[] args)
  {
    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    int q = Convert.ToInt32(Console.ReadLine());

    for (int qItr = 0; qItr < q; qItr++)
    {
      long n = Convert.ToInt64(Console.ReadLine());

      int result = primeCount(n);

      textWriter.WriteLine(result);
    }

    textWriter.Flush();
    textWriter.Close();
  }
}