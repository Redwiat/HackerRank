using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    private static int FindLowest(List<int> NumArray)
    {
        int minima=NumArray[0];
        int mindex=0;

        for(int i=0;i<NumArray.Count;i++)
        {
            if (NumArray[i]<minima)
                {minima=NumArray[i]; 
                 mindex=i;}
        }
        return minima;
    }
    private static string Cut(List<int> NumArray)
    {
        
        if(NumArray.Count==0)
            return "finshed";
        
        Console.WriteLine(NumArray.Count);
        int lowVal=FindLowest(NumArray);
        
        List<int> myArray2 = new List<int>();
        int count=0;
        foreach (int lowest in NumArray)
        {
           // Console.WriteLine("lowest={0}  -- lowval={1}",lowest,lowVal);
            if(lowest!=lowVal){
                count++;
                myArray2.Add(lowest);
            }
        }
        return Cut(myArray2);
    }
    
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int T = Int32.Parse(Console.ReadLine()); //Get number
        
        string[] arrayTree = Console.ReadLine().Split(' ');
        int[] myInts = Array.ConvertAll(arrayTree, int.Parse);
        
        List<int> myArray = new List<int>();
        myArray.AddRange(myInts);
        Cut(myArray);
    }
}