using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void GetSymmetric() {
      string[] data = Console.ReadLine().Split(' ');
      int Px = Int32.Parse(data[0]);
      int Py = Int32.Parse(data[1]);
      int Qx = Int32.Parse(data[2]);
      int Qy = Int32.Parse(data[3]);
        
      int x=2*Qx-Px;
      int y=2*Qy-Py;
      Console.WriteLine(x+" "+y);
    }
    static void Main(String[] args) {
        int T = int.Parse(Console.ReadLine());
        if(T>15 || T<1)
            Console.WriteLine("Error");
        
        for(int i=0; i < T; i++) {
            GetSymmetric();
        }  
    }
}
