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

//Gemstones
//https://www.hackerrank.com/challenges/gem-stones/problem
class Solution
{

  // Complete the gemstones function below.
  static int gemstones(string[] arr)
  {
    var dic = new Dictionary<char, int>();
    foreach (var word in arr)
    {
      var list = new List<char>();
      foreach (var letter in word)
      {
        if (!dic.ContainsKey(letter))
          dic.Add(letter, 0);

        if (!list.Contains(letter))
        {
          list.Add(letter);
          dic[letter]++;
        }
      }
    }

    return dic.Count(item => item.Value == arr.Length);
  }


  static void Main(string[] args)
  {
    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    int n = Convert.ToInt32(Console.ReadLine());

    string[] arr = new string[n];

    for (int i = 0; i < n; i++)
    {
      string arrItem = Console.ReadLine();
      arr[i] = arrItem;
    }

    int result = gemstones(arr);

    textWriter.WriteLine(result);

    textWriter.Flush();
    textWriter.Close();
  }
}