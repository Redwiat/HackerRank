using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        
        int sum=0;     
        Console.ReadLine();
       
       string[] nums = Console.ReadLine().Split(' ');
       foreach (string num in nums)
       {
          sum += Int32.Parse(num) ;
        }
        Console.WriteLine(sum);
    }
}