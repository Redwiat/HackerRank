using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static int PrincessePosition(int n, String [] grid){
        if(grid[0][0]=='p')
            return 1;
        else if(grid[n-1][0]=='p')
            return 2;
        else if(grid[0][n-1]=='p')
            return 3;
        else
            return 4;
    }
    static void GoLeftUp(int MyPos){
        int i;
        for (i=0; i<MyPos; i++)
            Console.WriteLine("LEFT");
        for (i=0; i<MyPos; i++)
            Console.WriteLine("UP");        
    }
    static void GoLeftDown(int MyPos){
        int i;
        for (i=0; i<MyPos; i++)
            Console.WriteLine("LEFT");
        for (i=0; i<MyPos; i++)
            Console.WriteLine("DOWN");        
    }
    static void GoRightUp(int MyPos){
        int i;
        for (i=0; i<MyPos; i++)
            Console.WriteLine("RIGHT");
        for (i=0; i<MyPos; i++)
            Console.WriteLine("UP");       
    }
    static void GoRightDown(int MyPos){
        int i;
        for (i=0; i<MyPos; i++)
            Console.WriteLine("RIGHT");
        for (i=0; i<MyPos; i++)
            Console.WriteLine("DOWN");        
    }
    static void displayPathtoPrincess(int n, String [] grid){
        int Ppos=PrincessePosition(n, grid); //1=L+U 2=L+D 3=R+U 4=R+D
        int Mpos= (int)Math.Round((decimal)((n-1)/2));
        //int x_Mpos= x_Mpos;
        switch (Ppos)
        {
            case 1: {GoLeftUp(Mpos); break;}
            case 2: {GoLeftDown(Mpos); break;}
            case 3: {GoRightUp(Mpos); break;}
            case 4: {GoRightDown(Mpos); break;}
        }        
      }
    static void Main(String[] args) {
            int m;

            m = int.Parse(Console.ReadLine());

            String[] grid  = new String[m];
            for(int i=0; i < m; i++) {
                grid[i] = Console.ReadLine(); 
            }

            displayPathtoPrincess(m,grid);
         }
}
