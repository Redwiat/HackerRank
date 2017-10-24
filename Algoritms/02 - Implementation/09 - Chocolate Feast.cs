using System; 
using System.Collections.Generic; 
using System.IO;

class Solution {
  static int NumberOfCholocates()
  {
      string[] data = Console.ReadLine().Split(' ');
      double N = (double)Int32.Parse(data[0]);
      double C = (double)Int32.Parse(data[1]);
      int M = Int32.Parse(data[2]);
      
      int paidChoc = (int)Math.Floor(N/C);
      int freeChoc=paidChoc;
      
      int i=-1;
      while(freeChoc>0)
      {   
          i++;
          freeChoc = freeChoc-M+1;
      }
      return(paidChoc+i);
  }
  static void Main(String[] args) { 
    int T = int.Parse(Console.ReadLine());
    for(int i=0; i < T; i++) {
        Console.WriteLine(NumberOfCholocates());
    }                     
  }
}
