using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

//Project Euler #6: Sum square difference
//https://www.hackerrank.com/contests/projecteuler/challenges/euler006/problem
class Solution
{

  private static long GetSumOfSquare(int n)
  {
    long total = 0;
    for (long i = 1; i <= n; i++)
      total = total + i * i;
    return total;
  }

  private static long GetSquareOfSum(int n)
  {
    long total = 0;
    for (long i = 1; i <= n; i++)
      total = total + i;
    return total * total;
  }

  private static long SumSquareDifference(int n)
  {
    return GetSquareOfSum(n) - GetSumOfSquare(n);
  }

  static void Main(String[] args)
  {
    int t = Convert.ToInt32(Console.ReadLine());
    for (int a0 = 0; a0 < t; a0++)
    {
      Console.WriteLine(SumSquareDifference(Convert.ToInt32(Console.ReadLine())));
    }
  }

}