using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

//Project Euler #1: Multiples of 3 and 5
//https://www.hackerrank.com/contests/projecteuler/challenges/euler001/problem
class Solution
{
  static BigInteger GetSum(int n)
  {
    BigInteger countDivisibleBy3 = (n - 1) / 3;
    BigInteger countDivisibleBy5 = (n - 1) / 5;
    BigInteger countDivisibleBy15 = (n - 1) / 15;

    BigInteger multiples3 = 3 * countDivisibleBy3 * (countDivisibleBy3 + 1) / 2;
    BigInteger multiples5 = 5 * countDivisibleBy5 * (countDivisibleBy5 + 1) / 2;
    BigInteger multiples15 = 15 * countDivisibleBy15 * (countDivisibleBy15 + 1) / 2;

    return multiples3 + multiples5 - multiples15;
  }

  static void Main(String[] args)
  {
    int t = Convert.ToInt32(Console.ReadLine());
    for (int a0 = 0; a0 < t; a0++)
    {
      int n = Convert.ToInt32(Console.ReadLine());
      Console.WriteLine(GetSum(n));
    }
  }
}