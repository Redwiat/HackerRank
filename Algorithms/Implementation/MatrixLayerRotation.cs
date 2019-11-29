using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

  // Complete the matrixRotation function below.
  static void matrixRotation(int[][] matrix, int lines, int cols, int r)
  {
    int numberOfMatrixes = Math.Min(lines, cols) / 2;
    var level_pos_XY = new Dictionary<int, Dictionary<int, Tuple<int, int>>>();

    //get inner matrixes
    var list = new List<List<int>>();
    for (int level = 0; level < numberOfMatrixes; level++)
    {
      level_pos_XY.Add(level, new Dictionary<int, Tuple<int, int>>());
      list.Add(GetList(matrix, level, lines, cols, level_pos_XY.Last().Value));
    }

    //rotate
    foreach (var item in list)
    {
      int rot = r % item.Count;
      for (int i = 0; i < rot; i++)
      {
        item.Add(item[0]);
        item.RemoveAt(0);
      }
    }

    //get final matrix
    int[][] finalMatrix = new int[lines][];
    for (int i = 0; i < lines; i++)
      finalMatrix[i] = new int[cols];
    foreach (var dic in level_pos_XY)
    {
      int level = dic.Key;
      var posXYs = dic.Value;

      foreach (var posXY in posXYs)
      {
        int posInList = posXY.Key;
        int x = posXY.Value.Item1;
        int y = posXY.Value.Item2;

        finalMatrix[x][y] = list[level][posInList];
      }
    }

    for (int i = 0; i < lines; i++)
    {
      for (int j = 0; j < cols; j++)
        Console.Write(finalMatrix[i][j] + " ");

      Console.WriteLine(string.Empty);
    }
  }

  private static List<int> GetList(int[][] matrix, int level, int lines, int cols, Dictionary<int, Tuple<int, int>> pos_XY)
  {
    var ret = new List<int>();

    int x = 0;
    int y = 0;

    //top
    for (int j = level; j < cols - level; j++)
    {
      x = level;
      y = j;
      pos_XY.Add(ret.Count, new Tuple<int, int>(x, y));
      ret.Add(matrix[x][y]);
    }

    //right
    for (int i = level + 1; i < lines - level - 1; i++)
    {
      x = i;
      y = cols - level - 1;
      pos_XY.Add(ret.Count, new Tuple<int, int>(x, y));
      ret.Add(matrix[x][y]);
    }

    //bottom
    for (int j = cols - level - 1; j > level - 1; j--)
    {
      x = lines - level - 1;
      y = j;
      pos_XY.Add(ret.Count, new Tuple<int, int>(x, y));
      ret.Add(matrix[x][y]);
    }

    //left
    for (int i = lines - level - 2; i > level; i--)
    {
      x = i;
      y = level;
      pos_XY.Add(ret.Count, new Tuple<int, int>(x, y));
      ret.Add(matrix[x][y]);
    }

    return ret;

  }

  //Matrix Layer Rotation
  //https://www.hackerrank.com/challenges/matrix-rotation-algo
  static void Main(string[] args)
  {
    string[] mnr = Console.ReadLine().Split(' ');

    int m = Convert.ToInt32(mnr[0]);

    int n = Convert.ToInt32(mnr[1]);

    int r = Convert.ToInt32(mnr[2]);

    int[][] matrix = new int[m][];

    for (int i = 0; i < m; i++)
    {
      matrix[i] = Array.ConvertAll(Console.ReadLine().Split(' '), matrixTemp => Convert.ToInt32(matrixTemp));
    }

    matrixRotation(matrix, m, n, r);
  }
}
