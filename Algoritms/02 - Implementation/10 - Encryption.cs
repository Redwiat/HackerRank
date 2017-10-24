using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    private static string EncryptString(string stringToEncrypt)
    {   
       int strl =stringToEncrypt.Length;
       int rows = Convert.ToInt32(Math.Floor(Math.Sqrt(strl)));
       int cols = Convert.ToInt32(Math.Ceiling(Math.Sqrt(strl)));
       
       while((rows*cols) < strl)
       {
           if(cols>rows)
               rows++;
           else
               cols++;
       }
        
       string[] encriptingString= new string[rows];
       int ncols=cols;
       for(int i=0; i<rows;i++)
       {
           if(i*cols+cols>strl)
               ncols=strl-cols*i;
           
      encriptingString[i]=stringToEncrypt.Substring(i*cols,ncols);
       }
        
       for(int i=0;i<cols;i++)
       {
           for(int j=0;j<rows;j++)
           {
               try {
               Console.Write(encriptingString[j][i]);
                   }
               catch{}
           }
           Console.Write(" ");
       }
        return "finished";
    }
    
    static void Main(String[] args) {
        
        string stringToEncrypt = Console.ReadLine().Trim();
        
        EncryptString(stringToEncrypt);
    }
}