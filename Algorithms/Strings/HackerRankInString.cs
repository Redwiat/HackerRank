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

//HackerRank in a String
//https://www.hackerrank.com/challenges/hackerrank-in-a-string/problem
class Solution
{

  // Complete the hackerrankInString function below.
  static string hackerrankInString(string s)
  {
    //initialize
    var hackerrank = "hackerrank";
    var list = hackerrank.Select(item => new Tuple<char, int>(item, -1)).ToList();

    var stringres = string.Empty;
    //run string
    var pos = 0;
    foreach (var item in s)
    {
      var lettertofind = hackerrank[pos];
      if (lettertofind == item)
      {
        var found = list.FirstOrDefault(tuple => tuple.Item1 == lettertofind && tuple.Item2 == -1);
        if (found != null)
        {
          stringres = stringres + found.Item1;
          list.Remove(found);
          pos++;
          if (pos == hackerrank.Length)
            break;
        }
      }
    }

    //Verify
    return stringres == hackerrank ? "YES" : "NO";
  }

  static void Main(string[] args)
  {
    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    int q = Convert.ToInt32(Console.ReadLine());

    for (int qItr = 0; qItr < q; qItr++)
    {
      string s = Console.ReadLine();

      string result = hackerrankInString(s);

      textWriter.WriteLine(result);
    }

    textWriter.Flush();
    textWriter.Close();
  }
}