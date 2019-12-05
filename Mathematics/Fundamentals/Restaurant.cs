using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

//Restaurant
//https://www.hackerrank.com/challenges/best-divisor/problem
class Solution
{

  static int restaurant(int l, int b)
  {
    if (l == b)
      return 1;

    var pieces = l * b;
    for (var i = Math.Min(l, b); i >= 1; i--)
    {
      if (l % i == 0 && b % i == 0 && pieces % (i * i) == 0)
        return pieces / (i * i);
    }

    return pieces;
  }

  static void Main(string[] args)
  {
    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    int t = Convert.ToInt32(Console.ReadLine());

    for (int tItr = 0; tItr < t; tItr++)
    {
      string[] lb = Console.ReadLine().Split(' ');

      int l = Convert.ToInt32(lb[0]);

      int b = Convert.ToInt32(lb[1]);

      int result = restaurant(l, b);

      textWriter.WriteLine(result);
    }

    textWriter.Flush();
    textWriter.Close();
  }

}