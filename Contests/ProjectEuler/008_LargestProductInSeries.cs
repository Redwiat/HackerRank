using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

//Project Euler #8: Largest product in a series
//https://www.hackerrank.com/contests/projecteuler/challenges/euler008/problem
class Solution
{
  static IEnumerable<string> SplitCount(string str, int chunkSize)
  {
    return Enumerable.Range(0, str.Length / chunkSize)
      .Select(i => str.Substring(i * chunkSize, chunkSize));
  }
  private static int GetProduct(string num)
  {
    var product = 1;
    var split = SplitCount(num, 1);
    foreach (var val in split)
      product = product * int.Parse(val);

    return product;
  }

  private static long LargestProductInSeries(int n, int k, string num)
  {
    var largest = 0;
    while (num.Length > k)
    {
      var largestTemp = GetProduct(num.Substring(num.Length - 1 - k, k));
      num = num.Substring(0, num.Length - 1);
      if (largestTemp > largest)
        largest = largestTemp;
    }

    return largest;
  }

  static void Main(String[] args)
  {
    int t = Convert.ToInt32(Console.ReadLine());
    for (int a0 = 0; a0 < t; a0++)
    {
      string[] tokens_n = Console.ReadLine().Split(' ');
      int n = Convert.ToInt32(tokens_n[0]);
      int k = Convert.ToInt32(tokens_n[1]);
      string num = Console.ReadLine();
      Console.WriteLine(LargestProductInSeries(n, k, num));
    }
  }

}