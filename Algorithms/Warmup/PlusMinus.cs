using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
       float sumNegatives=0;float sumZeros=0; float sumPositives=0;    
       int numtot = Int32.Parse(Console.ReadLine());
       
       string[] nums = Console.ReadLine().Split(' ');
       foreach (string num in nums)
       {
          if(Int32.Parse(num)<0)
              sumNegatives++;
          else if(Int32.Parse(num)==0)
              sumZeros++;
          else
              sumPositives++;
        }
       float tot=sumNegatives+sumZeros+sumPositives;
        
       Console.WriteLine((sumPositives/tot).ToString());
       Console.WriteLine((sumNegatives/tot).ToString());
       Console.WriteLine((sumZeros/tot).ToString());
    }
}