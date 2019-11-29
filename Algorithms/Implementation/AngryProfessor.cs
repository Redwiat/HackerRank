using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        
       int T = Int32.Parse(Console.ReadLine());
       
       while(T>0){
           
           string[] N_K = Console.ReadLine().Split(' ');
           int K = Int32.Parse(N_K[1]); //Get K
           //Console.WriteLine("K="+K.ToString());
           
           string[] arrivalTimes = Console.ReadLine().Split(' ');
           int onTime=0;
           foreach(string ai in arrivalTimes)
           {
               if(Int32.Parse(ai)<=0)
                   onTime++;
           }
           //Console.WriteLine("onTime="+onTime.ToString());
           if(onTime>=K)
               Console.WriteLine("NO");
           else
               Console.WriteLine("YES");
               
           T--;
       }
        
    }
}