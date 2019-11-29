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

  // Complete the superReducedString function below.
  static string superReducedString(string s)
  {
    var res = s;
    for (int i = 0; i < s.Length - 1; i++)
    {
      var currentChar = s[i];
      var previousChar = s[i + 1];

      if (currentChar == previousChar)
      {
        res = res.Remove(i, 2); 
        break;
      }
    }

    if (Verify(res))
      return res;

    return superReducedString(res);
  }

  private static bool Verify(string s)
  {
    for (int i = 0; i < s.Length - 1; i++)
    {
      var currentChar = s[i];
      var previousChar = s[i + 1];

      if (currentChar == previousChar)
      {
        return false;
      }
    }

    return true;
  }

  //Super Reduced String
  //https://www.hackerrank.com/challenges/reduced-string/problem
  static void Main(string[] args)
  {
    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    string s = Console.ReadLine();

    string result = superReducedString(s);

    textWriter.WriteLine(string.IsNullOrEmpty(result) ? "Empty String" : result);

    textWriter.Flush();
    textWriter.Close();
  }
}