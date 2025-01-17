﻿namespace FormingAMagicSquare;
//https://www.hackerrank.com/challenges/magic-square-forming/

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
     * Complete the 'formingMagicSquare' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY s as parameter.
     */

    public static int formingMagicSquare(List<List<int>> s)
    {
        List<int> allNumbers = new List<int>();
        s.ForEach(x => x.ForEach(x => allNumbers.Add(x)));

        int[][] possibleSquares = new int[][]
        {
            new int[] { 8, 1, 6, 3, 5, 7, 4, 9, 2 },
            new int[] { 6, 1, 8, 7, 5, 3, 2, 9, 4 },
            new int[] { 4, 9, 2, 3, 5, 7, 8, 1, 6 },
            new int[] { 2, 9, 4, 7, 5, 3, 6, 1, 8 },
            new int[] { 8, 3, 4, 1, 5, 9, 6, 7, 2 },
            new int[] { 4, 3, 8, 9, 5, 1, 2, 7, 6 },
            new int[] { 6, 7, 2, 1, 5, 9, 8, 3, 4 },
            new int[] { 2, 7, 6, 9, 5, 1, 4, 3, 8 }
        };

        int minDif = int.MaxValue;

        foreach (var pS in possibleSquares)
        {
            int dif = 0;
            for (int i = 0; i < 9; i++)
            {
                dif += Math.Abs(allNumbers[i] - pS[i]);
            }
            minDif = Math.Min(dif, minDif);
        }

        return minDif;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        List<List<int>> s = new List<List<int>>();

        for (int i = 0; i < 3; i++)
        {
            s.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList());
        }

        int result = Result.formingMagicSquare(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
