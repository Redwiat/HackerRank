using System;

//Project Euler #14: Longest Collatz sequence
//https://www.hackerrank.com/contests/projecteuler/challenges/euler014/problem
class Solution
{

  static int MaxValue = 5000000;
  static int[] CollatzSequenceCache = new int[MaxValue + 1];
  static int[] MaxCache = new int[MaxValue + 1];

  static int GetCollatzSequenceFor(long n)
  {
    if (n == 1)
      return 1;

    var numberWithinArray = n < CollatzSequenceCache.Length;
    if (numberWithinArray && CollatzSequenceCache[n] != 0)
      return CollatzSequenceCache[n];

    long next = (n % 2 == 0) ? n / 2 : 3 * n + 1;
    int result = 1 + GetCollatzSequenceFor(next);
    if (numberWithinArray)
      CollatzSequenceCache[n] = result;

    return result;
  }

  static int GetLongestCollatzSequence(int n)
  {
    if (MaxCache[n] != 0)
      return MaxCache[n];

    int max = 0;
    int longest = 0;
    for (int i = 1; i <= n; i++)
    {
      int sequence = GetCollatzSequenceFor(i);
      if (sequence >= max)
      {
        max = sequence;
        longest = i;
      }

      MaxCache[i] = longest;
    }

    return longest;
  }

  static void Main(String[] args)
  {
    long t = Convert.ToInt32(Console.ReadLine());
    for (long a0 = 0; a0 < t; a0++)
      Console.WriteLine(GetLongestCollatzSequence(Convert.ToInt32(Console.ReadLine())));
  }

}

