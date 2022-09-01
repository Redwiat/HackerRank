//#define Test
//Project Euler #2: Even Fibonacci numbers
//https://www.hackerrank.com/contests/projecteuler/challenges/euler002/problem
public class Solution
{
    private static SortedDictionary<long, long> Fibonacci = new() { { 0, 1 }, { 1, 2 }, { 2, 5 }, { 3, 8 } };
    private static List<long> FibonacciEven = new() { 2, 8 };

    private static void AddValueToCache(long n, long returnValue)
    {
        if (!Fibonacci.ContainsKey(returnValue))
        {
            Fibonacci.Add(n, returnValue);
            if (returnValue % 2 == 0)
                FibonacciEven.Add(returnValue);
        }
    }

    private static long CalculateFib(long n)
    {
        if (Fibonacci.ContainsKey(n))
            return Fibonacci[n];

        if ((n == 0) || (n == 1))
            return n;

        var returnValue = CalculateFib(n - 1) + CalculateFib(n - 2);
        AddValueToCache(n, returnValue);

        return returnValue;
    }

    private static void CreateCache(double n)
    {
        while (Fibonacci.Last().Value < n)
            CalculateFib(Fibonacci.Last().Key + 1);
    }
    private static long GetSumOfEvenFibonacciNumbersUntil(long n)
    {
        CreateCache(n);

        long sum = 0;
        foreach (var evenFib in FibonacciEven)
        {
            if (evenFib > n)
                break;

            sum += evenFib;
        }

        return sum;
    }

    public static void Main(String[] args)
    {

#if Test
        Console.WriteLine(GetSumOfEvenFibonacciNumbersUntil(10));
        Console.WriteLine(GetSumOfEvenFibonacciNumbersUntil(100));
        Console.WriteLine(GetSumOfEvenFibonacciNumbersUntil((long)(4* (Math.Pow(10, 16)))));
        Console.ReadLine();
#else
        int t = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            long n = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine(GetSumOfEvenFibonacciNumbersUntil(n));
        }
#endif
    }
}
