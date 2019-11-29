using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void printArray(int[] ar, int size) {
        for(int i=0;i<size;i++){
         Console.Write(ar[i]+" ");
        }
        Console.WriteLine("");
    }
    static void insertionSort(int[] ar, int size) {
        int tempV = ar[size-1];
        ar[size-1]= ar[size-2];
        bool min=true;
        for(int i=1;i<size;i++){
            if(ar[size-i-1]>=tempV)
                ar[size-i] = ar[size-i-1];
            else
            {
                min=false;
                ar[size-i] = tempV; 
                printArray(ar,size);
                break;
            }
            printArray(ar,size);
        }
        if(min){
            ar[0]=tempV;
            printArray(ar,size);            
        }
    }

  //Insertion Sort - Part 1
  //https://www.hackerrank.com/challenges/insertionsort1
  static void Main(String[] args) {
           
           int _ar_size;
           _ar_size = Convert.ToInt32(Console.ReadLine());
           int [] _ar =new int [_ar_size];
           String elements = Console.ReadLine();
           String[] split_elements = elements.Split(' ');
           for(int _ar_i=0; _ar_i < _ar_size; _ar_i++) {
                  _ar[_ar_i] = Convert.ToInt32(split_elements[_ar_i]); 
           }

           insertionSort(_ar,_ar_size);
    }
}