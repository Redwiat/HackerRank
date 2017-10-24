using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        
       string[] actualDate = Console.ReadLine().Split(' ');
       string[] returnDate = Console.ReadLine().Split(' ');
       int fine=0;
       
       if(Int32.Parse(actualDate[2])>Int32.Parse(returnDate[2]))
          fine=10000;
       else if(Int32.Parse(actualDate[1])>Int32.Parse(returnDate[1]) && Int32.Parse(actualDate[2])==Int32.Parse(returnDate[2]))
           fine=500*(Int32.Parse(actualDate[1])-Int32.Parse(returnDate[1]));
       else if(Int32.Parse(actualDate[0])>Int32.Parse(returnDate[0]) && Int32.Parse(actualDate[1])==Int32.Parse(returnDate[1]) && Int32.Parse(actualDate[2])==Int32.Parse(returnDate[2]))
           fine=15*(Int32.Parse(actualDate[0])-Int32.Parse(returnDate[0]));
       else
           fine=0;
       
       Console.WriteLine((fine).ToString());
           
    }
}