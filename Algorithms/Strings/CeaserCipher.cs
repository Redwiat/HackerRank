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

//Caesar Cipher
//https://www.hackerrank.com/challenges/caesar-cipher-1/problem?isFullScreen=true
class Solution
{

  public static string Shift(string s, int count)
  {
    count = count % s.Length;
    return s.Remove(0, count) + s.Substring(0, count);
  }

  // Complete the caesarCipher function below.
  static string caesarCipher(string s, int k)
  {
    var lowerCase = "abcdefghijklmnopqrstuvwxyz";
    var lowerCaseShift = Shift(lowerCase, k);
    var upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    var upperCaseShift = Shift(upperCase, k);

    var res = new StringBuilder();
    foreach (var schar in s)
    {
      if (upperCase.Contains(schar))
      {
        res.Append(upperCaseShift.ElementAt(upperCase.IndexOf(schar)));
      }
      else if (lowerCase.Contains(schar))
      {
        res.Append(lowerCaseShift.ElementAt(lowerCase.IndexOf(schar)));
      }
      else
      {
        res.Append(schar);
      }
    }

    return res.ToString();
  }

  static void Main(string[] args)
  {
    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    int n = Convert.ToInt32(Console.ReadLine());

    string s = Console.ReadLine();

    int k = Convert.ToInt32(Console.ReadLine());

    string result = caesarCipher(s, k);

    textWriter.WriteLine(result);

    textWriter.Flush();
    textWriter.Close();
  }
}