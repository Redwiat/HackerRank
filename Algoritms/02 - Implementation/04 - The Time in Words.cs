using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    static void Main(String[] args)
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        string[] mins = {"none","one minutes","two minutes","three minutes","four minutes",
                          "five minutes","six minutes","seven minutes","eight minutes",
                          "nine minutes","ten minutes","eleven minutes","twelve minutes",
                          "thirteen minutes","fourteen minutes","quarter","sixteen minutes",
                          "seventeen minutes","eighteen minutes","nineteen minutes",
                          "twenty minutes","twenty one minutes","twenty two minutes",
                          "twenty three minutes","twenty four minutes","twenty five minutes",
                          "twenty six minutes","twenty seven minutes","twenty eight minutes",
                          "twenty nine minutes","half"};
        string[] hours = {"none","one","two","three","four",
                          "five","six","seven","eight","nine",
                          "ten","eleven","twelve"};

        int time_hours = Int32.Parse(Console.ReadLine()); //Get hours
        int time_mins = Int32.Parse(Console.ReadLine()); //Get minutes
        //fazer na forma ? :
        if (time_mins == 0)
            Console.WriteLine(hours[time_hours] + " o' clock");
        else if (time_mins > 30)
            Console.WriteLine(mins[60 - time_mins] + " to " + hours[time_hours + 1]);
        else
            Console.WriteLine(mins[time_mins] + " past " + hours[time_hours]);
    }
}