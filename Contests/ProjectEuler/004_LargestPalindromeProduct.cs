using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

//Project Euler #4: Largest palindrome product
//https://www.hackerrank.com/contests/projecteuler/challenges/euler004/problem
class Solution
{

  private static bool IsPalindrome(int n)
  {
    string s = n.ToString();
    char[] arr = s.ToCharArray();
    Array.Reverse(arr);
    return s == new string(arr);
  }

  private static bool IsProductOf3Digits(int n)
  {
    for (int i = 100; i < 1000; i++)
    {
      for (int j = 100; j < 1000; j++)
      {
        if (i * j == n)
          return true;
        if (i * j > n)
          break;
      }
    }

    return false;
  }

  private static int GetLargestPalindromeProduct(int n)
  {
    int i = n > 999 * 999 ? 999 * 999 : n;
    while (i-- > 0)
    {
      if (IsPalindrome(i) && IsProductOf3Digits(i))
        return i;
    }

    throw new Exception("404 - NotFound");
  }


  static void Main(String[] args)
  {
    int t = Convert.ToInt32(Console.ReadLine());
    for (int a0 = 0; a0 < t; a0++)
    {
      Console.WriteLine(GetLargestPalindromeProduct(Convert.ToInt32(Console.ReadLine())));
    }
  }

}