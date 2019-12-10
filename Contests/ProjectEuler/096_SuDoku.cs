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


  public static readonly int[] PossibleValues = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
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
    var initNeighborRowNumber = GetInitNumberForNeighbor(rowNumber);
    var initNeighborColNumber = GetInitNumberForNeighbor(colNumber);
    foreach (var other in others)
    {
      var row = array.GetRow(rowNumber);
      if (!row.Contains(other))
        return false;

      var col = array.GetColumn(colNumber);
      if (!col.Contains(other))
        return false;

      //_helperDictionary[rowNumber][colNumber].Remove(other);
    }

    return true;
  }

  private static List<int> Intersect(List<List<int>> list)
  {
    var ret = new List<int>();
    if (list.Count > 0)
    {
      ret.AddRange(list.First());
      foreach (var item in list)
      {
        ret = ret.Intersect(item).ToList();
      }
    }

    return ret;
  }

  private static bool CanFitInAnotherPlaceIn(int[,] array, int missingValue, List<string> missingZerosPositions,
    int rowNumberOriginal, int colNumberOriginal, int initNeighborRowNumber, int initNeighborColNumber,
    bool lookingInNeighbors = false)
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

  private static List<string> GetMissingZerosPositions(int[,] neighbors, int initNeighborRowNumber,
    int initNeighborColNumber)
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
    if (original >= 3) initNumber = 3;
    if (original >= 6) initNumber = 6;

    return initNumber;
  }

  private static int GetValueTo(int[,] array, int rowNumber, int colNumber)
  {
    var row = array.GetRow(rowNumber);

    var values = _helperDictionary[rowNumber][colNumber];
    if (values.Count == 1)
      return values.First();

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
    var missingValues = missingInNei.Intersect(missingInCol).Intersect(missingInRow).ToList();
    if (missingValues.Count == 1)
      return missingValues.FirstOrDefault();

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

  #region Dictionary

  private static List<List<int>> GetRow(Dictionary<int, Dictionary<int, List<int>>> helperDictionary, int dim)
  {
    return GetDim(helperDictionary, dim, true);
  }

  private static List<List<int>> GetCol(Dictionary<int, Dictionary<int, List<int>>> helperDictionary, int dim)
  {
    return GetDim(helperDictionary, dim, false);
  }
  private static List<List<int>> GetAllRow(Dictionary<int, Dictionary<int, List<int>>> helperDictionary, int dim)
  {
    return GetDim(helperDictionary, dim, true, true);
  }

  private static List<List<int>> GetAllCol(Dictionary<int, Dictionary<int, List<int>>> helperDictionary, int dim)
  {
    return GetDim(helperDictionary, dim, false, true);
  }

  private static List<List<int>> GetDim(Dictionary<int, Dictionary<int, List<int>>> helperDictionary, int dim,
    bool byRow, bool includeEmpty = false)
  {
    var ret = new List<List<int>>();
    for (var i = 0; i < 9; i++)
    {
      if (byRow)
      {
        var list = _helperDictionary[dim][i];
        if (includeEmpty || list.Count > 0)
          ret.Add(list);
      }
      else
      {
        var list = _helperDictionary[i][dim];
        if (includeEmpty || list.Count > 0)
          ret.Add(list);
      }
    }

    return ret;
  }

  private static void UpdateDictionary(int[,] array, int count)
  {
    for (var i = 0; i < 9; i++)
    {
      for (var j = 0; j < 9; j++)
      {
        var number = array[i, j];
        var list = _helperDictionary[i][j];
        if (number != 0 && list.Count != 0)
        {
          //clear this cell
          _helperDictionary[i][j].Clear();

          //Remove number from all cells in this row:
          for (int k = 0; k < 9; k++)
            _helperDictionary[i][k].Remove(number);

          //Remove number from all cells in this col:
          for (int k = 0; k < 9; k++)
            _helperDictionary[k][j].Remove(number);
        }
      }
    }

    //Intersect Rows/Cols to try eliminate possibilities
    for (var i = 0; i < 9; i = i + 3)
    {
      for (var j = 0; j < 9; j = j + 3)
      {
        var initNeighborRowNumber = GetInitNumberForNeighbor(i);
        var initNeighborColNumber = GetInitNumberForNeighbor(j);

        var neighbors = array.GetNeighbors(initNeighborRowNumber, initNeighborColNumber);
        var missingInNei = neighbors.GetMissing();

        var rowsUnions = new Dictionary<int, List<int>>();
        var colsUnions = new Dictionary<int, List<int>>();
        for (int k = 0; k < 3; k++)
        {
          //for each row:
          var valuesMissingThisInThisNeighborRow =
            GetMissingInNeighborByRow(_helperDictionary, initNeighborRowNumber + k, initNeighborColNumber);

          var valuesMissingThisInThisNeighborCol =
            GetMissingInNeighborByCol(_helperDictionary, initNeighborRowNumber, initNeighborColNumber + k);

          var unionRows = new List<int>();
          foreach (var item in valuesMissingThisInThisNeighborRow)
          {
            unionRows.AddRange(item);
          }

          rowsUnions.Add(k, new List<int>(unionRows.Distinct().Intersect(missingInNei)));

          var unionCols = new List<int>();
          foreach (var item in valuesMissingThisInThisNeighborCol)
          {
            unionCols.AddRange(item);
          }

          colsUnions.Add(k, new List<int>(unionCols.Distinct().Intersect(missingInNei)));

        }

        #region Rows

        if (rowsUnions.Count > 0)
        {

          foreach (var item in rowsUnions)
          {

            var correctedRow = initNeighborRowNumber + item.Key;

            #region MyRegion

            var thisValuesMustBeInThisRow = new List<int>(item.Value);
            foreach (var item2 in rowsUnions)
            {
              if (item.Key != item2.Key)
              {
                thisValuesMustBeInThisRow = thisValuesMustBeInThisRow.FindAll(x => !item2.Value.Contains(x));
              }
            }

            //must be needed in this row
            thisValuesMustBeInThisRow = thisValuesMustBeInThisRow.Intersect(item.Value.ToList()).ToList();

            //Remove this values from HelperDic in other neighbors
            if (thisValuesMustBeInThisRow.Count > 0)
            {
              for (var k = 0; k < 9; k++) //Each col
              {
                if ((k < initNeighborColNumber || k > initNeighborColNumber + 2)
                    && array[correctedRow, k] == 0
                    && _helperDictionary[correctedRow][k].Count > 0)
                {
                  foreach (var toRemove in thisValuesMustBeInThisRow)
                  {
                    if (_helperDictionary[correctedRow][k].Contains(toRemove))
                    {
#if DEBUG
                      if (_helperDictionarySolution[correctedRow][k] == toRemove)
                      {
                        //shouldnt be removed
                      }
#endif
                      var cellAdreesRow = correctedRow.ToString() + " - " + k + " - Not=> " + toRemove;
                      _helperDictionary[correctedRow][k].Remove(toRemove);
                    }
                  }
                }
              }
            }

            #endregion

            #region MyRegion

            //test with cells in other neighbours but from this row
            var list = new List<List<int>>();
            for (int k = 0; k < 9; k++)
            {
              if (k < initNeighborColNumber || k > initNeighborColNumber + 2)
                if (_helperDictionary[correctedRow][k].Count > 0)
                  list.Add(_helperDictionary[correctedRow][k]);
            }

            var getRow = array.GetRow(correctedRow);
            var valuesMissingInOtherCols = new List<int>();
            foreach (var possiblevalue in Extensions.PossibleValues)
            {
              if (getRow.Contains(possiblevalue))
                continue;

              var has = false;
              foreach (var valuesThatMightBeInAnotherCol in list)
              {
                if (valuesThatMightBeInAnotherCol.Contains(possiblevalue))
                {
                  has = true;
                  break;
                }

                ;
              }

              if (has)
                continue;

              valuesMissingInOtherCols.Add(possiblevalue);

            }

            valuesMissingInOtherCols = valuesMissingInOtherCols.Intersect(item.Value.ToList()).ToList();

            //remove from columns in my neibours
            for (var k = initNeighborColNumber; k < initNeighborColNumber + 3; k++)
            {
              for (int l = initNeighborRowNumber; l < +initNeighborRowNumber + 3; l++)
              {
                {

                  if (l != correctedRow
                      && array[l, k] == 0
                      && _helperDictionary[l][k].Count > 0)
                  {
                    foreach (var toRemove in valuesMissingInOtherCols)
                    {
                      if (_helperDictionary[l][k].Contains(toRemove))
                      {
#if DEBUG
                        if (_helperDictionarySolution[l][k] == toRemove)
                        {
                          //shouldnt be removed
                        }
#endif
                        var x = l + " - " + k.ToString() + " - Not=> " + toRemove;
                        _helperDictionary[l][k].Remove(toRemove);
                      }
                    }
                  }
                }
              }
            }

            #endregion

          }

        }

        #endregion

        #region Cols

        if (colsUnions.Count > 0)
        {
          foreach (var item in colsUnions)
          {

            var correctedCol = initNeighborColNumber + item.Key;

            #region MyRegion

            //Test with columns of neig
            var thisValuesMustBeInThisCol = new List<int>(item.Value);
            foreach (var item2 in colsUnions)
            {
              if (item.Key != item2.Key)
              {
                thisValuesMustBeInThisCol = thisValuesMustBeInThisCol.FindAll(x => !item2.Value.Contains(x));
              }
            }

            //must be needed in this col
            thisValuesMustBeInThisCol = thisValuesMustBeInThisCol.Intersect(item.Value.ToList()).ToList();

            if (thisValuesMustBeInThisCol.Count > 0)
            {
              //Remove this values from rows in other neighbors in my colum
              for (var k = 0; k < 9; k++)
              {
                if ((k < initNeighborRowNumber || k > initNeighborRowNumber + 2)
                    && array[k, correctedCol] == 0
                    && _helperDictionary[k][correctedCol].Count > 0)
                {
                  foreach (var toRemove in thisValuesMustBeInThisCol)
                  {
                    if (_helperDictionary[k][correctedCol].Contains(toRemove))
                    {
#if DEBUG
                      if (_helperDictionarySolution[k][correctedCol] == toRemove)
                      {
                        //shouldnt be removed
                      }
#endif

                      var x = k + " - " + correctedCol.ToString() + " - Not=> " + toRemove;
                      _helperDictionary[k][correctedCol].Remove(toRemove);
                    }
                  }
                }
              }

            }


            #endregion

            #region MyRegion

            //test with cells in other neighbours but from this col
            var list = new List<List<int>>();
            for (int k = 0; k < 9; k++)
            {
              if (k < initNeighborRowNumber || k > initNeighborRowNumber + 2)
                if (_helperDictionary[k][correctedCol].Count > 0)
                  list.Add(_helperDictionary[k][correctedCol]);
            }

            var getcolumn = array.GetColumn(correctedCol);
            var valuesMissingInOtherRows = new List<int>();
            foreach (var possiblevalue in Extensions.PossibleValues)
            {
              if (getcolumn.Contains(possiblevalue))
                continue;

              var has = false;
              foreach (var valuesThatMightBeInAnotherRow in list)
              {
                if (valuesThatMightBeInAnotherRow.Contains(possiblevalue))
                {
                  has = true;
                  break;
                }

                ;
              }

              if (has)
                continue;

              valuesMissingInOtherRows.Add(possiblevalue);

            }

            valuesMissingInOtherRows = valuesMissingInOtherRows.Intersect(item.Value.ToList()).ToList();

            //remove from columns in my neibours
            for (var k = initNeighborColNumber; k < initNeighborColNumber + 3; k++)
            {
              for (int l = initNeighborRowNumber; l < +initNeighborRowNumber + 3; l++)
              {

                if (k != correctedCol
                    && array[l, k] == 0
                    && _helperDictionary[l][k].Count > 0)
                {
                  foreach (var toRemove in valuesMissingInOtherRows)
                  {
                    if (_helperDictionary[l][k].Contains(toRemove))
                    {
#if DEBUG
                      if (_helperDictionarySolution[l][k] == toRemove)
                      {
                        //shouldnt be removed
                      }
#endif
                      var x = l + " - " + k.ToString() + " - Not=> " + toRemove;
                      _helperDictionary[l][k].Remove(toRemove);
                    }
                  }
                }
              }
            }

            #endregion

          }

        }

        #endregion

      }
    }


    for (var i = 0; i < 9; i++)
    {

      var col = GetCol(_helperDictionary, i);
      var row = GetRow(_helperDictionary, i);

      #region  Naked Subset simple

      #region Cols

      var listToRemove = new List<List<int>>();
      foreach (var expr in col)
      {
        foreach (var expr2 in col)
        {
          if (expr.Count == 2 && expr != expr2 && expr2.SequenceEqual(expr))
          {
            listToRemove.Add(expr2);
            break;
          }
        }
      }

      listToRemove = listToRemove.Distinct().ToList();
      if (listToRemove.Count > 0)
      {
        for (var j = 0; j < 9; j++)
        {
          var list = _helperDictionary[j][i];
          foreach (var item in listToRemove)
          {
            if (list.Except(item).Any())
            {
              list.RemoveAll(x => item.Contains(x));
            }
          }
        }
      }


      #endregion

      #region Rows

      var listToRemove2 = new List<List<int>>();
      foreach (var expr in row)
      {
        foreach (var expr2 in row)
        {
          if (expr.Count == 2 && expr != expr2 && expr2.SequenceEqual(expr))
          {
            listToRemove2.Add(expr2);
            break;
          }
        }
      }
      listToRemove2 = listToRemove2.Distinct().ToList();
      if (listToRemove2.Count > 0)
      {
        for (var j = 0; j < 9; j++)
        {
          var list = _helperDictionary[i][j];
          foreach (var item in listToRemove2)
          {
            if (list.Except(item).Any())
            {
              list.RemoveAll(x => item.Contains(x));
            }

          }
        }
      }

      #endregion

      #endregion

      #region  Naked Subset hard

      if (count > 10)
      {
        #region Cols
        var countCol = new Dictionary<int, int>();
        foreach (var item in col)
        {
          foreach (var val in item)
          {
            if (!countCol.ContainsKey(val))
              countCol.Add(val, 0);
            countCol[val]++;
          }
        }
        var listCols = (from item in countCol where item.Value == 2 select item.Key).ToList();
        if (listCols.Count == 2)
        {
          for (var j = 0; j < 9; j++)
          {
            if (_helperDictionary[j][i].Intersect(listCols).Count() == listCols.Count())
            {
              _helperDictionary[j][i] = _helperDictionary[j][i].Intersect(listCols).ToList();
            }
          }
        }
        #endregion

        #region Rows
        var countRows = new Dictionary<int, int>();
        foreach (var item in col)
        {
          foreach (var val in item)
          {
            if (!countRows.ContainsKey(val))
              countRows.Add(val, 0);
            countRows[val]++;
          }
        }
        var listRows = (from item in countRows where item.Value == 2 select item.Key).ToList();
        if (listRows.Count == 2)
        {
          for (var j = 0; j < 9; j++)
          {
            if (_helperDictionary[i][j].Intersect(listRows).Count() == listRows.Count())
            {
              _helperDictionary[i][j] = _helperDictionary[i][j].Intersect(listRows).ToList();
            }
          }
        }
        #endregion


      }
      #endregion

    }

  }


  private static List<List<int>> GetMissingInNeighborByRow(Dictionary<int, Dictionary<int, List<int>>> helperDictionary,
      int row, int col)
  {
    return GetMissingInNeighborByDim(helperDictionary, row, col, true);
  }

  private static List<List<int>> GetMissingInNeighborByCol(Dictionary<int, Dictionary<int, List<int>>> helperDictionary,
    int row, int col)
  {
    return GetMissingInNeighborByDim(helperDictionary, row, col, false);
  }

  private static List<List<int>> GetMissingInNeighborByDim(Dictionary<int, Dictionary<int, List<int>>> helperDictionary,
    int row, int col, bool byRow)
  {
    var ret = new List<List<int>>();
    var dim = byRow ? col : row;
    for (var i = dim; i < dim + 3; i++)
    {
      if (byRow)
      {
        var list = _helperDictionary[row][i];
        if (list.Count > 0)
          ret.Add(list);
      }
      else
      {
        var list = _helperDictionary[i][col];
        if (list.Count > 0)
          ret.Add(list);
      }
    }

    return ret;
  }


  private static Dictionary<int, Dictionary<int, List<int>>> _helperDictionary;

  private static void FillDictionary(int[,] array)
  {
    _helperDictionary = new Dictionary<int, Dictionary<int, List<int>>>();
    for (var i = 0; i < 9; i++)
    {
      _helperDictionary.Add(i, new Dictionary<int, List<int>>());
      for (var j = 0; j < 9; j++)
      {
        _helperDictionary[i].Add(j, new List<int>(Extensions.PossibleValues));
      }
    }
  }

  #endregion

  private static bool Verify(int[,] array)
  {
    var totalSum = 0;
    for (var i = 0; i < 9; i++)
    {
      var sumCol = array.GetColumn(i).Sum();
      if (sumCol > 45)
        throw new Exception("Glitch in the matrix!");
      if (sumCol < 45)
        return false;

      var sumRow = array.GetRow(i).Sum();
      if (sumRow > 45)
        throw new Exception("Glitch in the matrix!");
      if (sumCol < 45)
        return false;

      totalSum = totalSum + sumCol + sumRow;
    }

    if (totalSum != (45 * 9 + 45 * 9))
    {
      throw new Exception("Glitch in the matrix!");
    }

    return true;
  }

#if DEBUG



  private static Dictionary<int, Dictionary<int, int>> _helperDictionarySolution;

  private static void LoadSolution(string sol)
  {
    _helperDictionarySolution = new Dictionary<int, Dictionary<int, int>>();
    for (int i = 0; i < 9; i++)
    {
      _helperDictionarySolution.Add(i, new Dictionary<int, int>());
      for (int j = 0; j < 9; j++)
      {
        _helperDictionarySolution[i].Add(j, int.Parse(sol[i * 9 + j].ToString()));
      }
    }
  }
#endif

  public static int[,] Solve(int[,] array)
  {
    var count = 0;
    var cloneArray = (int[,])array.Clone();
    FillDictionary(array);
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

      UpdateDictionary(array, count);
      count++;

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
