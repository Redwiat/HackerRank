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

    // Complete the marsExploration function below.
    static int marsExploration(string s) {

    var ret = 0;
    var length = s.Length / 3;
    var stringcorrect = "SOS";
    for (int i = 0; i < length; i++)
      stringcorrect += "SOS";

    for (int i = 0; i < s.Length; i++)
    {
      if (stringcorrect[i]!=s[i])
        ret++;
    }

    return ret;

    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        int result = marsExploration(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
