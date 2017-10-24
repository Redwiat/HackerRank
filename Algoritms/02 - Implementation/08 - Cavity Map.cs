using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    
   private static bool CheckAdjacent(int size, int x, int y, int[,] Map)
   {
       if(x==0 || x==size-1 ||y==0 || y==size-1)
           return false;
       
       int max=Map[x,y];
       if ((max > Map[x-1,y])&&(max > Map[x+1,y])&&(max > Map[x,y-1])&&(max > Map[x,y+1]))
          return true;
       else
          return false;
   }
    
   private static void EvaluateMap(int size, int[,] Map)
   {
       for(int x=0; x<size;x++)
       {
          for (int y = 0; y < size; y++)
          {
              Console.Write(CheckAdjacent(size, x, y, Map) ? "X" : Map[x,y].ToString());
          }
          Console.WriteLine();
       }
   }
    
   private static void CheckMap(int size)
   {       
        int[,] Map = new int[size, size];
        for (int i = 0; i < size; i++)
        {
            var row = Console.ReadLine().ToCharArray();
            for (int j = 0; j < size; j++)
            {
                Map[i, j] = Int32.Parse(row[j].ToString());
            }
        }
       EvaluateMap(size, Map);
    }

    static void Main(String[] args)
    {
        int size = Int32.Parse(Console.ReadLine()); 
        CheckMap(size);
    }
}