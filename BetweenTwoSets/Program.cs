namespace BetweenTwoSets;
//https://www.hackerrank.com/challenges/between-two-sets
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
     * Complete the 'getTotalX' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY a
     *  2. INTEGER_ARRAY b
     */
    //GCD (Greatest Common Divisor)
    private static int gcd(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    // LCM (Least Common Multiple)
    private static int lcm(int a, int b)
    {
        return (a / gcd(a, b)) * b;
    }

    public static int getTotalX(List<int> a, List<int> b)
    {
        int lcmA = a.Aggregate(lcm);

        // Find the Greatest Common Divisor (GCD) of all the integers in array b
        int gcdB = b.Aggregate(gcd);

        // Find all the numbers that are multiples of lcmA and divisors of gcdB
        int count = 0;
        for (int i = lcmA; i <= gcdB; i += lcmA)
        {
            if (gcdB % i == 0)
            {
                count++;
            }
        }

        return count;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]);

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> brr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(brrTemp => Convert.ToInt32(brrTemp)).ToList();

        int total = Result.getTotalX(arr, brr);

        textWriter.WriteLine(total);

        textWriter.Flush();
        textWriter.Close();
    }
}
