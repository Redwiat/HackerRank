using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    static bool FunnyString() {
        string Str=Console.ReadLine();//String
        char[] arr = Str.ToCharArray();
        Array.Reverse(arr);
        string rStr=new string(arr);//Reverse String
        bool result=true;
        for(int i=1;i<rStr.Length;i++)
        {
           if(Math.Abs((int)Str[i]-(int)Str[i-1])!=Math.Abs((int)rStr[i]-(int)rStr[i-1]))
               result=false;
        }
        return result;
    }
    static void Main(String[] args) {
        int T = Int32.Parse(Console.ReadLine()); //Get T
        
        while(T>0){
            if(FunnyString())
                Console.WriteLine("Funny");
            else
                Console.WriteLine("Not Funny");
            T--;
        }
    }
}
