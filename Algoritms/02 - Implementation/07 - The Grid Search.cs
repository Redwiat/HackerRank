using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
class Solution {
    private static bool VerifyMatrix(int[,] bigMatrix, int[,] smallMatrix)
    {
        bool breakme;
        for (int i = 0; i < bigMatrix.GetLength(0)-smallMatrix.GetLength(0)+1; i++)     // for each line
        {
            for (int j = 0; j < bigMatrix.GetLength(1)-smallMatrix.GetLength(1)+1; j++) // for each col
            {
                breakme=false;
                for (int a = 0; a < smallMatrix.GetLength(0); a++)     // for each line
                {
                    for (int b = 0; b < smallMatrix.GetLength(1); b++) // for each col
                    {
                        //Console.WriteLine("bigMatrix={0} | smallMatrix={1}",bigMatrix[i+a,j+b],smallMatrix[a, b]);
                        if (bigMatrix[i+a,j+b] != smallMatrix[a, b])
                        {breakme=true;break;}
                    }
                    if(breakme)
                        break;
                    //Console.WriteLine("a={0} | smallMatrix.GetLength(0)-1={1} | C={2} ",a,smallMatrix.GetLength(0)-1,55);
                    if (a == (smallMatrix.GetLength(0) - 1))
                        return true;

                }
            }
        }

        return false;
    }
    private static bool EvaluateMatrix()
    {
        //get BIG matrix
        string[] SizeG = Console.ReadLine().Split(' ');
        int R = Int32.Parse(SizeG[0]); //Get R
        int C = Int32.Parse(SizeG[1]); //Get C
        int[,] MatrixG = new int[R, C];
        for (int i = 0; i < R; i++)
        {
            //Console.WriteLine("i={0} | R={1} | C={2} ",i,R,C);
            var row = Console.ReadLine().ToCharArray();
            for (int j = 0; j < C; j++)
            {
                MatrixG[i, j] = Int32.Parse(row[j].ToString());
            }
        }

        //Get SMALL matrix
        string[] SizeP = Console.ReadLine().Split(' ');

        int r = Int32.Parse(SizeP[0]); //Get R
        int c = Int32.Parse(SizeP[1]); //Get C
        int[,] MatrixP = new int[r, c];
        for (int i = 0; i < r; i++)
        {
            var row = Console.ReadLine().ToCharArray();
            for (int j = 0; j < c; j++)
            {
                MatrixP[i, j] = Int32.Parse(row[j].ToString());
            }
        }

        //verify if SMALL inside BIG
        return VerifyMatrix(MatrixG, MatrixP);
    }

    static void Main(String[] args)
    {
        int T = Int32.Parse(Console.ReadLine()); //Number of evaluations
        for (int i = 0; i < T; i++)
        {

            Console.WriteLine(EvaluateMatrix() ? "YES" : "NO");
        }
    }
}