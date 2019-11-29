using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void printArray(List<int>  ar, int size) {
        for(int i=0;i<size;i++){
         Console.Write(ar[i]+" ");
        }
        Console.WriteLine("");
    }
    
    static List<int>  sortArray(List<int> ar, int size, int pos) { 
        int valor=ar[pos]; 
        
        ar.RemoveAt(pos);
        
        for(int i=0; i<size; i++){
            if(valor < ar[i]){
                ar.Insert(i,valor);
                break;
            }
        }
        
        return ar;
    }
    
    static void insertionSort(List<int> ar,int size) {
        
        for(int i=1; i<size; i++){
            if(ar[i] < ar[i-1]) 
                ar = sortArray(ar, size, i); 
            
            printArray(ar,size);
        }
    }

  //Insertion Sort - Part 2
  //https://www.hackerrank.com/challenges/insertionsort2
  static void Main(String[] args) {

        int _ar_size;
        List<int> listint = new List<int>();
        
        _ar_size = Convert.ToInt32(Console.ReadLine());
        int [] _ar =new int [_ar_size];
        String elements = Console.ReadLine();
        String[] split_elements = elements.Split(' ');
        for(int _ar_i=0; _ar_i < _ar_size; _ar_i++) {
            _ar[_ar_i] = Convert.ToInt32(split_elements[_ar_i]); 
            listint.Add(_ar[_ar_i]);
        }

        insertionSort(listint,_ar_size);
     }
}
