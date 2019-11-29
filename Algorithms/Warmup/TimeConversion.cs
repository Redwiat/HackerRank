using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
       
       string[] nums = Console.ReadLine().Split(':');
       int hours = Int32.Parse(nums[0]);
       string am_pm_format =nums[2].Substring(2,2);
        string hour=string.Empty;
       if(am_pm_format=="PM")
       {
           hours += 12;
           hour=hours.ToString();
           if(hours==24)
               hour="12";
       }
        else{
           if(hours<10)
               hour="0"+hours.ToString();
           if(hours==12)
               hour="00";
        }
        
       Console.WriteLine(hour+":"+nums[1]+":"+nums[2].Substring(0,2));
    
    }
}