using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    private static string CalculateHeight(int cycles)
    {
        int treeHeight=1;
        for(int i=0;i<cycles; i++)
        {
            if(i%2==0)
                treeHeight=treeHeight*2;
            else
                treeHeight++;
        }
        return treeHeight.ToString();
        
    }
    
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int T = Int32.Parse(Console.ReadLine()); //Get number
        
        for(int i=0;i<T; i++){
              Console.WriteLine(CalculateHeight(Int32.Parse(Console.ReadLine())));
        }
    }
}