using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static bool GetPrincessPosition(int size, String [] grid, out int px, out int py){
        px=-1;py=-1;  
        for(int row=0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
              if(grid[row][col]=='p'){
                  px=col;
                  py=row;
                  return true;
              }
            }
        }
        return false;
    }
    static void nextMove(int n, int mx, int my, String [] grid){
        int px,py;
        
        //invert
        int temp=mx;
         mx=my;
         my=temp;
        
        GetPrincessPosition(n,grid, out  px, out py);
        //Console.WriteLine("px={0} py={1}",px,py);
        //Console.WriteLine("mx={0} my={1}",mx,my);
        
        if(px>mx)
            Console.WriteLine("RIGHT");
        else if(px<mx)
            Console.WriteLine("LEFT");
        else if(py<my)
            Console.WriteLine("UP");  
        else
            Console.WriteLine("DOWN");  
    }
    
    static void Main(String[] args) {
            int n;

            n = int.Parse(Console.ReadLine());
            String pos;
            pos = Console.ReadLine();
            String[] position = pos.Split(' ');
            int [] int_pos = new int[2];
            int_pos[0] = Convert.ToInt32(position[0]);
            int_pos[1] = Convert.ToInt32(position[1]);
            String[] grid  = new String[n];
            for(int i=0; i < n; i++) {
                grid[i] = Console.ReadLine(); 
            }

            nextMove(n, int_pos[0], int_pos[1], grid);

         }
}