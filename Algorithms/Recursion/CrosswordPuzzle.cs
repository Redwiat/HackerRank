using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
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

//Crossword Puzzle
//https://www.hackerrank.com/challenges/crossword-puzzle/problem


class Solution
{

  private static int _numberOfAttemps;
  private static List<string> _words;
  private static string[] _crosswordOriginal;
  private static int _minimumSizeOfWord = int.MaxValue;

  private static readonly Random Rnd = new Random();

  class UnknownWord
  {
    public int row;
    public int col;
    public int lenght;
    public List<string> possibleWords = new List<string>();
  }

  private static string[] InvertedCrossword(string[] crossword)
  {
    try
    {
      var invertedCrosswordMatrix = new string[10, 10];
      for (var rowi = 0; rowi < crossword.Length; rowi++)
      {
        var row = crossword[rowi];
        for (int coli = 0; coli < row.Length; coli++)
        {
          invertedCrosswordMatrix[coli, rowi] = row[9 - coli].ToString();
        }
      }

      var invertedCrossword = new string[10];
      for (int i = 0; i < invertedCrossword.Length; i++)
      {
        var line = string.Empty;
        for (int j = 0; j < invertedCrossword.Length; j++)
        {
          line = line + invertedCrosswordMatrix[i, j];
        }
        invertedCrossword[i] = line;
      }

      return invertedCrossword;
    }
    catch
    {
      return new string[10];
    }
  }

  private static List<UnknownWord> GetHorizontal(string[] crossword, bool horizontal)
  {
    var list = new List<UnknownWord>();
    for (var index = 0; index < crossword.Length; index++)
    {
      var row = crossword[index];
      var horizontalWordLenght = 0;
      var firstcol = -1;
      for (int i = 0; i < row.Length; i++)
      {
        if (row[i] == '-')
        {
          if (firstcol == -1)
            firstcol = i;

          horizontalWordLenght++;
        }
        else
        {
          if (horizontalWordLenght < _minimumSizeOfWord)
          {
            horizontalWordLenght = 0;
            firstcol = -1;
          }
          else
            break;
        }
      }

      if (horizontalWordLenght >= _minimumSizeOfWord)
      {
        var urow = index;
        var ucol = firstcol;
        if (!horizontal)
        {
          urow = firstcol;
          ucol = 9 - index;
        }
        var uword = new UnknownWord() { row = urow, col = ucol, lenght = horizontalWordLenght };
        foreach (var word in _words)
        {
          if (word.Length == uword.lenght)
          {
            uword.possibleWords.Add(word);
          }
        }

        list.Add(uword);
      }
    }

    return list;
  }

  private static string[] FuzzyAttempt(string[] crossword, List<UnknownWord> horizontalUnknownWords, List<UnknownWord> verticalUnknownWords, List<string> allWords)
  {
    var crosswordClone = (string[])crossword.Clone();
    var words = new List<string>();
    words.AddRange(allWords);

    TryInsert(crosswordClone, horizontalUnknownWords, words, true);
    TryInsert(crosswordClone, verticalUnknownWords, words, false);

    if (words.Count == 0 && Verify(crosswordClone))
      return crosswordClone;

    if (_numberOfAttemps++ > 100)
      return null; //cannot be solved

    //start with original
    return FuzzyAttempt(_crosswordOriginal, horizontalUnknownWords, verticalUnknownWords, _words);
  }

  private static void TryInsert(string[] crosswordClone, List<UnknownWord> unknownWords, List<string> words, bool horizontal)
  {
    foreach (var word in unknownWords)
    {
      var pw = GetRandom(word.possibleWords, words);
      if (words.Contains(pw))
      {
        if (InsertWord(crosswordClone, pw, word, horizontal))
          words.Remove(pw);
      }
    }
  }

  private static bool InsertWord(string[] crossword, string wordToInsert, UnknownWord uw, bool horizontalWord)
  {
    if (horizontalWord)
    {
      for (int i = 0; i < crossword.Length; i++)
      {
        var row = crossword[i];
        if (i == uw.row && row.Contains('-'))
        {
          row = row.Remove(uw.col, uw.lenght);
          crossword[i] = row.Insert(uw.col, wordToInsert);
          return true;
        }
      }
    }
    else
    {
      for (int i = 0; i < wordToInsert.Length; i++)
      {
        for (int j = 0; j < crossword.Length; j++)
        {
          if (j >= uw.row + i)
          {
            var row = crossword[j];
            row = row.Remove(uw.col, 1);
            crossword[j] = row.Insert(uw.col, wordToInsert.Substring(i, 1));
            break;
          }
        }
      }

      return true;
    }

    return false;
  }

  private static string GetRandom(List<string> possibleWords, List<string> contained = null)
  {
    if (possibleWords.Count > 0)
    {
      if (contained == null)
        return possibleWords.ElementAt(Rnd.Next(0, possibleWords.Count));

      var words = possibleWords.Where(contained.Contains).ToList();
      if (words.Count > 0)
        return words.ElementAt(Rnd.Next(0, words.Count));
    }

    return null;
  }

  private static bool Verify(string[] solvedCrossword)
  {
    if (solvedCrossword.Any(line => line.Length != 10))
      return false;

    var checkedWord = 0;
    var invSolvedCrosssword = InvertedCrossword(solvedCrossword);
    foreach (var word in _words)
    {
      checkedWord += solvedCrossword.Count(row => row.Contains(word));
      checkedWord += invSolvedCrosssword.Count(col => col?.Contains(word) == true);
    }

    return checkedWord == _words.Count;
  }

  // Complete the crosswordPuzzle function below.
  static string[] crosswordPuzzle(string[] crossword, string words)
  {
    _words = words.Split(';').ToList();
    _crosswordOriginal = (string[])crossword.Clone();
    foreach (var word in _words)
      if (word.Length < _minimumSizeOfWord)
        _minimumSizeOfWord = word.Length;

    var horizontalUnknownWords = GetHorizontal(crossword, true);
    var verticalUnknownWords = GetHorizontal(InvertedCrossword(crossword), false);

    return FuzzyAttempt(crossword, horizontalUnknownWords, verticalUnknownWords, _words);
  }


  static void Main(string[] args)
  {
    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    string[] crossword = new string[10];

    for (int i = 0; i < 10; i++)
    {
      string crosswordItem = Console.ReadLine();
      crossword[i] = crosswordItem;
    }

    string words = Console.ReadLine();

    string[] result = crosswordPuzzle(crossword, words);

    textWriter.WriteLine(string.Join("\n", result));

    textWriter.Flush();
    textWriter.Close();
  }
}
