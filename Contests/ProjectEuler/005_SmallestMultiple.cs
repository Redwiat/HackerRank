using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

//Project Euler #5: Smallest multiple
//https://www.hackerrank.com/contests/projecteuler/challenges/euler005/problem
class Solution
{

  private static bool IsDivisibleUntilN(int number, int n)
  {
    for (int i = 1; i <= n; i++)
    {
      if (number % i != 0)
        return false;
    }

    return true;
  }

  private static int SmallestMultiple(int n)
  {
    var i = 1;

    while (i < int.MaxValue)
    {
      if (IsDivisibleUntilN(i, n))
        return i;

      i++;
    }

    throw new Exception("404 - NotFound");
  }

  static void Main(String[] args)
  {
    int t = Convert.ToInt32(Console.ReadLine());
    for (int a0 = 0; a0 < t; a0++)
    {
      Console.WriteLine(SmallestMultiple(Convert.ToInt32(Console.ReadLine())));
    }
  }

}