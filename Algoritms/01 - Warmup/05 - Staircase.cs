using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
       
       int num = Int32.Parse(Console.ReadLine());
       int count=0;
       string mySharp= String.Empty;
       while(count<num)
       {
           mySharp= String.Empty;
           for(int i=num-count-1;i>0;i--)
           {
                mySharp=mySharp+" ";
           }
           for(int j=0;j<count+1;j++)
            mySharp=mySharp+"#";
           Console.WriteLine(mySharp);
           count++;
       }
    }
}