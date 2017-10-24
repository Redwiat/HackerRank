using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        //DateTime sTime, eTime;
        int T = Int32.Parse(Console.ReadLine()); //Get T
        //sTime = DateTime.Now;
        
        while(T>0){
            int N = Int32.Parse(Console.ReadLine()); //Get number
            
            System.Text.StringBuilder str1= new System.Text.StringBuilder();
            System.Text.StringBuilder str2= new System.Text.StringBuilder();
            int count_3=0;
            int count_5=0;
            
            while(N>0)
            {
               int aux=N;
               if (aux<3){ //se <3 sai porque não dá
                   N=-1;
               }
               else if (aux%3==0){ // se modulo por 5 entao
                   N-=3*(aux/3);
                   count_5+=(aux/3); 
               }
               else if(aux>=3){
                   N-=5; 
                   count_3+=1;
               }
               else{//error
                   N=-1;
               }
            }
			//0.014327 
            str1.Append(new string('3', 5*count_3));
            str2.Append(new string('5', 3*count_5));
            str2.Append(str1);
                        
            if(N==0)
               Console.WriteLine(str2);
            else
               Console.WriteLine("-1");   
            
            T--;
        }
        
        //eTime = DateTime.Now;
        //Console.WriteLine("String Builder took=" + (eTime - sTime).TotalSeconds + " seconds.");
    }
}