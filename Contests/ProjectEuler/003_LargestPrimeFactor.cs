//
//NOT FINISHED YET: 60/100
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Schema;

//Project Euler #3: Largest prime factor
//https://www.hackerrank.com/contests/projecteuler/challenges/euler003/problem
class Solution
{

  static Dictionary<long, bool> IsPrimeDic = new Dictionary<long, bool>() { { 0, false }, { 1, false }, { 2, true }, { 3, true }, { 4, false }, { 5, true } };
  static bool IsPrime(long n)
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

      IsPrimeDic.Add(n, true);
      return true;
    }

    return IsPrimeDic[n];
  }


  private static long GetLargestPrimeFactor(long n)
  {
    if (IsPrime(n))
      return n;

    while (n % 2 == 0)
      n = n / 2;

    long startPoint = n;
    while (startPoint > 0)
    {
      if (IsPrime(startPoint) && n % startPoint == 0)
        return startPoint;
      startPoint = startPoint - 2;
    }

    throw new Exception("404 - NotFound");
  }

  static void Main(String[] args)
  {
    int t = Convert.ToInt32(Console.ReadLine());
    for (int a0 = 0; a0 < t; a0++)
    {
      Console.WriteLine(GetLargestPrimeFactor(Convert.ToInt64(Console.ReadLine())));
    }
  }

}

