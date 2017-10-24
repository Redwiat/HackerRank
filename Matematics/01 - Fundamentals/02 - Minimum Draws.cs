using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void GetDraws(int Npairs) {
      int NumDraws = Npairs+1;
      Console.WriteLine(NumDraws);
    }
    static void Main(String[] args) {
        int T = int.Parse(Console.ReadLine());
        if(T>1000)
            Console.WriteLine("Error");
        
        for(int i=0; i < T; i++) {
            int N = int.Parse(Console.ReadLine());
            GetDraws(N);
        }  
    }
}