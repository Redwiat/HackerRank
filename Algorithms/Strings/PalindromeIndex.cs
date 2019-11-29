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

class Solution
{

  static int palindromeIndex(string s)
  {
    if (!Verify(s))
    {
      var len = s.Length;
      var max = len-1;
      var min = 0;
      while (min < len) //if (Verify(s.Remove(i, 1)))//Slow
      {
        if (s[min]!=s[max])
        { 
          if (Verify(s.Remove(min, 1)))
            return min;
          return max;
        }
        min++; max--;
      }
    }

    return -1;
  }

  private static bool Verify(string s)
  {
    char[] arr = s.ToCharArray();
    Array.Reverse(arr);
    return s == new string(arr);
  }
  static void Main(string[] args)
  {
    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    int q = Convert.ToInt32(Console.ReadLine());

    for (int qItr = 0; qItr < q; qItr++)
    {
      string s = Console.ReadLine();

      int result = palindromeIndex(s);

      textWriter.WriteLine(result);
    }

    textWriter.Flush();
    textWriter.Close();
  }
}
