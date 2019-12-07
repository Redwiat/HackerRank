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

//Project Euler #96: Su Doku
//https://www.hackerrank.com/contests/projecteuler/challenges/euler096/problem

public static class Extensions
{

  #region Arrays

  public static int[] GetColumn(this int[,] matrix, int columnNumber)
  {
    return Enumerable.Range(0, matrix.GetLength(0))
      .Select(x => matrix[x, columnNumber])
      .ToArray();
  }

  public static int[] GetRow(this int[,] matrix, int rowNumber)
  {
    return Enumerable.Range(0, matrix.GetLength(1))
      .Select(x => matrix[rowNumber, x])
      .ToArray();
  }

  public static int[,] GetNeighbors(this int[,] matrix, int initNeighborRowNumber, int initNeighborColNumber)
  {
    var neighbors = new int[3, 3];

    for (int i = 0; i < 3; i++)
    {
      for (int j = 0; j < 3; j++)
      {
        neighbors[i, j] = matrix[initNeighborRowNumber + i, initNeighborColNumber + j];
      }
    }

    return neighbors;
  }

  public static string[] SplitBySize(this string str, int chunkSize)
  {
    return Enumerable.Range(0, str.Length / chunkSize)
      .Select(i => str.Substring(i * chunkSize, chunkSize)).ToArray();
  }

  public static int[,] FilledArray(this string[] splitSolve)
  {
    var filled = new int[9, 9];
    for (int i = 0; i < 9; i++)
    {
      for (int j = 0; j < 9; j++)
      {
        filled[i, j] = int.Parse(splitSolve[i][j].ToString());
      }
    }
    return filled;
  }


  private static readonly int[] PossibleValues = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
  public static int[] GetMissing(this int[] array)
  {
    var missing = new List<int>();

    foreach (var item in PossibleValues)
    {
      if (!array.Contains(item))
        missing.Add(item);
    }

    return missing.ToArray();
  }

  public static int[] GetMissing(this int[,] array)
  {
    return GetMissing(array.Flat());
  }

  public static int[] Flat(this int[,] array) => array.Cast<int>().ToArray();

  #endregion

  #region Debug

#if DEBUG
  public static string ToString2(this int[,] source, int pad = 10)
  {
    var result = "";
    for (int i = source.GetLowerBound(0); i <= source.GetUpperBound(0); i++)
    {
      for (int j = source.GetLowerBound(1); j <= source.GetUpperBound(1); j++)
        result += source.GetValue(i, j).ToString().PadLeft(pad);
      result += "\n";
    }
    return result;
  }
#endif

  #endregion

}

class Solution
{

  private static bool NoneOfTheOthersCanFitHere(int[,] array, List<int> others, int rowNumber, int colNumber)
  {
    foreach (var other in others)
    {
      var row = array.GetRow(rowNumber);

      if (!row.Contains(other))
        return false;

      var col = array.GetColumn(colNumber);
      if (!col.Contains(other))
        return false;
    }

    return true;
  }

  private static bool CanFitInAnotherPlaceIn(int[,] array, int missingValue, List<string> missingZerosPositions, int rowNumberOriginal, int colNumberOriginal, int initNeighborRowNumber, int initNeighborColNumber, bool lookingInNeighbors = false)
  {
    var ret = false;
    foreach (var item in missingZerosPositions)
    {
      var location = item.Split(',').ToArray();
      var rowNumber = int.Parse(location[0]) + initNeighborRowNumber;
      var colNumber = int.Parse(location[1]) + initNeighborColNumber;

      var row = array.GetRow(rowNumber);
      var col = array.GetColumn(colNumber);

      var initNeighborRowNumber2 = GetInitNumberForNeighbor(rowNumber);
      var initNeighborColNumber2 = GetInitNumberForNeighbor(colNumber);
      var neighbors = array.GetNeighbors(initNeighborRowNumber2, initNeighborColNumber2);

      if (lookingInNeighbors)
      {
        if ((colNumber != colNumberOriginal || rowNumber != rowNumberOriginal)
            && !row.Contains(missingValue)
            && !col.Contains(missingValue))
          return true;

      }
      else
      {
        if (rowNumber != rowNumberOriginal && !row.Contains(missingValue) && !neighbors.Flat().Contains(missingValue))
          return true;

        if (colNumber != colNumberOriginal && !col.Contains(missingValue) && !neighbors.Flat().Contains(missingValue))
          return true;

      }
    }

    return false;
  }

  private static List<string> GetMissingZerosPositions(int[,] neighbors, int initNeighborRowNumber, int initNeighborColNumber)
  {
    var ret = new List<string>();
    for (int i = 0; i < neighbors.GetLength(0); i++)
    {
      for (int j = 0; j < neighbors.GetLength(1); j++)
      {
        if (neighbors[i, j] == 0)
          ret.Add(i + "," + j);
      }
    }
    return ret;
  }

  private static List<string> GetMissingZerosPositions(int[] array, int rowNumber, int colNumber, bool fixRow)
  {
    var ret = new List<string>();
    for (var i = 0; i < array.Length; i++)
    {
      if (array[i] == 0)
      {
        if (fixRow)
          ret.Add(rowNumber + "," + i);
        else
          ret.Add(i + "," + colNumber);
      }
    }

    return ret;
  }

  private static int GetInitNumberForNeighbor(int original)
  {
    var initNumber = 0;
    var count = original - 2;
    if (count >= 1) initNumber = 3;
    if (count >= 4) initNumber = 6;

    return initNumber;
  }

  private static int GetValueTo(int[,] array, int rowNumber, int colNumber)
  {
    var row = array.GetRow(rowNumber);

    var missingInRow = row.GetMissing();
    if (missingInRow.Length == 1)
      return missingInRow[0];

    var col = array.GetColumn(colNumber);
    var missingInCol = col.GetMissing();
    if (missingInCol.Length == 1)
      return missingInCol[0];

    var initNeighborRowNumber = GetInitNumberForNeighbor(rowNumber);
    var initNeighborColNumber = GetInitNumberForNeighbor(colNumber);
    var neighbors = array.GetNeighbors(initNeighborRowNumber, initNeighborColNumber);
    var missingInNei = neighbors.GetMissing();
    if (missingInNei.Length == 1)
      return missingInNei[0];

    //rowNumber== 7 && colNumber==0
    var missingInAll = missingInNei.Intersect(missingInCol).Intersect(missingInRow);
    var missingValues = missingInAll.ToList();
    foreach (var missingValue in missingValues)
    {

      var missingZerosPositionsInNei =
        GetMissingZerosPositions(neighbors, initNeighborRowNumber, initNeighborColNumber);
      if (!CanFitInAnotherPlaceIn(array, missingValue, missingZerosPositionsInNei, rowNumber, colNumber,
        initNeighborRowNumber, initNeighborColNumber, true))
      {
        return missingValue;
      }

      var missingZerosPositionsInRow = GetMissingZerosPositions(row, rowNumber, colNumber, true);
      if (!CanFitInAnotherPlaceIn(array, missingValue, missingZerosPositionsInRow, rowNumber, colNumber, 0, 0))
      {
        return missingValue;
      }

      var missingZerosPositionsInCol = GetMissingZerosPositions(col, rowNumber, colNumber, false);
      if (!CanFitInAnotherPlaceIn(array, missingValue, missingZerosPositionsInCol, rowNumber, colNumber, 0, 0))
      {
        return missingValue;
      }

      var others = missingValues.Where(item => item != missingValue).ToList();
      if (NoneOfTheOthersCanFitHere(array, others, rowNumber, colNumber))
      {
        return missingValue;
      }

    }

    return -1;
  }

  private static bool Verify(int[,] array)
  {
    for (int i = 0; i < 9; i++)
    {
      if (array.GetColumn(i).Sum() != 45)
        return false;

      if (array.GetRow(i).Sum() != 45)
        return false;
    }
    return true;
  }

  public static int[,] Solve(int[,] array)
  {
    while (!Verify(array))
    {
      for (var i = 0; i < 9; i++)
      {
        for (var j = 0; j < 9; j++)
        {
          if (array[i, j] == 0)
          {
            var ijValue = GetValueTo(array, i, j);
            if (ijValue != -1)
              array[i, j] = ijValue;
          }
        }
      }
    }

    return array;
  }

  static void Main(string[] args)
  {
    var sudoku = new int[9, 9];

    for (int i = 0; i < 9; i++)
    {
      var line = Console.ReadLine();
      for (int j = 0; j < 9; j++)
      {
        if (line != null)
          sudoku[i, j] = int.Parse(line[j].ToString());
      }
    }

    Solve(sudoku);

    for (int i = 0; i < 9; i++)
    {
      var line = string.Empty;
      for (int j = 0; j < 9; j++)
      {
        line = line + sudoku[i, j];
      }
      Console.WriteLine(line);
    }

  }

}
