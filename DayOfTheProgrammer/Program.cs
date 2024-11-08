namespace DayOfTheProgrammer;

//https://www.hackerrank.com/challenges/day-of-the-programmer/

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

class Result
{

    /*
     * Complete the 'dayOfProgrammer' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts INTEGER year as parameter.
     */

    public static string dayOfProgrammer(int year)
    {
        DateTime dt = DateTime.ParseExact(year.ToString(), "yyyy", null);

        if (year > 1918)
        {
            dt = dt.AddDays(255);
        }
        else if (year == 1918)
        {
            dt = dt.AddDays(255 + 13);
        }
        else
        {
            if (year % 4 == 0 && (year % 100 == 0))
            {
                dt = dt.AddDays(254);
            }
            else
            {
                dt = dt.AddDays(255);
            }
        }
        return dt.ToString("dd.MM.yyyy");
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int year = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.dayOfProgrammer(year);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
