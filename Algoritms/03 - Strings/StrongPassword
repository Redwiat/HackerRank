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

    // Complete the minimumNumber function below.
    static int minimumNumber(int n, string password) {
      // Return the minimum number of characters to make the password strong
      var numbers = "0123456789".ToCharArray();
      var lower_case = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
      var upper_case = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
      var special_characters = "!@#$%^&*()-+".ToCharArray();
      var passwordArray = password.ToCharArray();

      var ret = 0;
      if (!passwordArray.Any(x => numbers.Contains(x)))
        ret++;
      if (!passwordArray.Any(x => lower_case.Contains(x)))
        ret++;
      if (!passwordArray.Any(x => upper_case.Contains(x)))
        ret++;
      if (!passwordArray.Any(x => special_characters.Contains(x)))
        ret++;

      var left = ret + password.Length;
      if (left < 6)
      {
        ret = ret+ (6 - left);
      }
      return ret;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        string password = Console.ReadLine();

        int answer = minimumNumber(n, password);

        textWriter.WriteLine(answer);

        textWriter.Flush();
        textWriter.Close();
    }
}
