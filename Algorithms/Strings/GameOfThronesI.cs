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

  // Complete the gameOfThrones function below.
  static bool gameOfThrones(string s)
  {

    var dic = new Dictionary<char, int>();
    foreach (var schar in s)
    {
      if (!dic.ContainsKey(schar))
        dic.Add(schar,0);
      dic[schar]++;
    }

    var count = 0;
    foreach (var letter in dic)
    {
      if (letter.Value%2!=0)
      {
        count++;
      }
    }

    return count < 2;

  }


  //Game of Thrones - I
  //https://www.hackerrank.com/challenges/game-of-thrones/problem
  static void Main(string[] args)
  {
    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    string s = Console.ReadLine();

    textWriter.WriteLine(gameOfThrones(s) ? "YES" : "NO");

    textWriter.Flush();
    textWriter.Close();
  }
}