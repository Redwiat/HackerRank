using System.CodeDom.Compiler;
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

//Alternating Characters
//https://www.hackerrank.com/challenges/alternating-characters/problem
class Solution
{

  // Complete the alternatingCharacters function below.
  static int alternatingCharacters(string s)
  {
    int deleteCount = 0;
    var charArray = s.ToCharArray();
    char lastChar = s[0];
    for (int i = 1; i < charArray.Length; i++)
    {
      if (charArray[i] == lastChar)
        deleteCount++;
      lastChar = charArray[i];
    }

    return deleteCount;
  }

  static void Main(string[] args)
  {
    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    int q = Convert.ToInt32(Console.ReadLine());

    for (int qItr = 0; qItr < q; qItr++)
    {
      string s = Console.ReadLine();

      int result = alternatingCharacters(s);

      textWriter.WriteLine(result);
    }

    textWriter.Flush();
    textWriter.Close();
  }
}