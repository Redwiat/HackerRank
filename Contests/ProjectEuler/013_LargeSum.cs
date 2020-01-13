using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

//Project Euler #13: Large sum

//https://www.hackerrank.com/contests/projecteuler/challenges/euler013/problem
class Solution
{
  static void Main(String[] args)
  {
    int t = Convert.ToInt32(Console.ReadLine());

    BigInteger total = 0;
    for (int a0 = 0; a0 < t; a0++)
      total += BigInteger.Parse(Console.ReadLine());

    Console.WriteLine(total.ToString().Substring(0, 10));
  }
}

