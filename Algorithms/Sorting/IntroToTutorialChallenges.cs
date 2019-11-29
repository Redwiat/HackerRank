using System;
using System.Collections.Generic;
using System.IO;
class Solution {

  //01 - Intro to Tutorial Challenges
  //https://www.hackerrank.com/challenges/tutorial-intro
  static void Main(String[] args) {
	int val = int.Parse(Console.ReadLine());
	int size = int.Parse(Console.ReadLine());
       
	String[] StringArray = Console.ReadLine().Split(' ');
    for(int i=0;i<size;i++)
        if(StringArray[i]==val.ToString())
            Console.WriteLine(i);
        
    }
}