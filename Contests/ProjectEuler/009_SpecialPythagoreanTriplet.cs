using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

//Project Euler #9: Special Pythagorean triplet
//https://www.hackerrank.com/contests/projecteuler/challenges/euler009/problem?h_r=profile
class Solution
{

  private static readonly Dictionary<int, int> SpecialPythagoreanTripletDictionary = new Dictionary<int, int>();
  private static int SpecialPythagoreanTriplet(int n)
  {
    if (SpecialPythagoreanTripletDictionary.ContainsKey(n))
      return SpecialPythagoreanTripletDictionary[n];

    for (int b = 1; b < n; b++)
    {
      for (int a = 1; a < b; a++)
      {
        if (b + a >= n)
          return -1;

        int c = n - b - a;
        if (b * b + a * a == c * c)
        {
          var res = b * a * c;
          if (!SpecialPythagoreanTripletDictionary.ContainsKey(n))
            SpecialPythagoreanTripletDictionary.Add(n, res);
          return res;
        }
      }
    }

    if (!SpecialPythagoreanTripletDictionary.ContainsKey(n))
      SpecialPythagoreanTripletDictionary.Add(n, -1);
    return -1;
  }

  static void Main(String[] args)
  {
    int t = Convert.ToInt32(Console.ReadLine());
    for (int a0 = 0; a0 < t; a0++)
    {
      Console.WriteLine(SpecialPythagoreanTriplet(Convert.ToInt32(Console.ReadLine())));
    }
  }

}