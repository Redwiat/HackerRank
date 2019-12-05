using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

//Best Divisor
//https://www.hackerrank.com/challenges/best-divisor/problem
class Solution
{

  static int Decompose(int n)
  {
    return (n.ToString().Select(digit => int.Parse(digit.ToString()))).Sum();
  }

  static void Main(string[] args)
  {
    int n = Convert.ToInt32(Console.ReadLine());

    var decomposedN = Decompose(n);
    var max = decomposedN;
    var dic = new Dictionary<int, int>() { };

    for (var i = 1; i <= n; i++)
    {
      if (n % i == 0)
      {
        var numberDecomposed = Decompose(i);
        if (numberDecomposed >= max)
        {
          max = numberDecomposed;
          if (!dic.ContainsKey(numberDecomposed))
            dic.Add(max, i);
        }
      }
    }

    if (!dic.ContainsKey(decomposedN))
      dic.Add(decomposedN, n);

    Console.WriteLine(dic[dic.Keys.Max()]);
  }
}