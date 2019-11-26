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

class Solution {

    
    static bool IsPangram(string s)
    {
      var lower_case = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
      var distinct = s.ToLowerInvariant().Distinct();
      return lower_case.Count(c => distinct.Contains(c)) == lower_case.Length;
    }

    // Complete the pangrams function below.
    static string pangrams(string s) {
        return IsPangram(s) ? "pangram" : "not pangram";
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = pangrams(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
