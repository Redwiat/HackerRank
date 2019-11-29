using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
class Solution {
    private static string ExactlyDivided(int number)
    {
        int count=0;
        int[] separated = number.ToString().Select(o=> Convert.ToInt32(o)).ToArray();
        foreach(int numberTest in separated)
        {
            if(numberTest>48)
                if((number % (numberTest-48)==0))
                     count++;
        }
        return count.ToString();
    }
    
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int T = Int32.Parse(Console.ReadLine()); //Get number
        
        for(int i=0;i<T; i++){
              Console.WriteLine(ExactlyDivided(Int32.Parse(Console.ReadLine())));
        }
    }
}