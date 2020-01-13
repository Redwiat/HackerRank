using System;
using System.Numerics;

//Project Euler #16: Power digit sum
//https://www.hackerrank.com/contests/projecteuler/challenges/euler016/problem
class Solution
{

  static int GetPowerDigitSum(int n)
  {
    BigInteger val = 1;
    for (int i = 0; i < n; i++)
      val = val * 2;

    var res = 0;
    string valString = val.ToString();
    for (int i = 0; i < valString.Length; i++)
      res += int.Parse(valString[i].ToString());

    return res;
  }

  static void Main(String[] args)
  {
    long t = Convert.ToInt32(Console.ReadLine());
    for (long a0 = 0; a0 < t; a0++)
      Console.WriteLine(GetPowerDigitSum(Convert.ToInt32(Console.ReadLine())));
  }
}