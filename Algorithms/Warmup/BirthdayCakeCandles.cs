using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{

  static void Main(String[] args)
  {
    int n = Convert.ToInt32(Console.ReadLine());
    string[] height_temp = Console.ReadLine().Split(' ');
    int[] height = Array.ConvertAll(height_temp, Int32.Parse);
    int result = 0;
    int max = Int32.MinValue;
    foreach (var item in height)
      max = Math.Max(max, item);

    foreach (var item in height)
    {
      if (item == max)
        result++;
    }

    Console.WriteLine(String.Join(" ", result));
  }
}
