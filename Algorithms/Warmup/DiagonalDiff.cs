using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
       int sum1=0;int sum2=0; int num=0;    
       num = Int32.Parse(Console.ReadLine());
       
       for(int i=0;i<num;i++)
       {
           string[] nums = Console.ReadLine().Split(' ');
           sum1 += Int32.Parse(nums[i]) ;
           sum2 += Int32.Parse(nums[num-i-1]) ;
       }
       Console.WriteLine((Math.Abs(sum2-sum1)).ToString());
    }
}