using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
  static long[] solve(List<long> list)
  {
    long min = Int64.MaxValue, max = Int64.MinValue;

    for (int i = 0; i < 5; i++)
    {
      long sum = 0;
      for (int j = 0; j < 5; j++)
      {
        if (j == i)
          continue;
        sum += list[j];
      }
      min = Math.Min(min, sum);
      max = Math.Max(max, sum);
    }

    return new long[] { min, max };
  }

  static void Main(String[] args)
  {
    string[] tokens_a0 = Console.ReadLine().Split(' ');
    List<long> list = new List<long>()
    {
      Convert.ToInt64(tokens_a0[0]),
      Convert.ToInt64(tokens_a0[1]),
      Convert.ToInt64(tokens_a0[2]),
      Convert.ToInt64(tokens_a0[3]),
      Convert.ToInt64(tokens_a0[4])
    };

    long[] result = solve(list);
    Console.WriteLine(String.Join(" ", result));
  }
}