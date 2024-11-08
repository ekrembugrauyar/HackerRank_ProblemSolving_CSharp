namespace StrongPassword;

//https://www.hackerrank.com/challenges/strong-password/problem?isFullScreen=true

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
     * Complete the 'minimumNumber' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. STRING password
     */

    public static int minimumNumber(int n, string password)
    {
        bool hasUpper = false, hasLower = false;
        bool hasNum = false, hasSpecial = false;
        string special_characters = "!@#$%^&*()-+";
        int required = 4;
        foreach (char c in password)
        {
            if (!hasUpper && char.IsUpper(c)) hasUpper = true;
            if (!hasLower && char.IsLower(c)) hasLower = true;
            if (!hasNum && char.IsNumber(c)) hasNum = true;
            if (!hasSpecial && special_characters.Contains(c)) hasSpecial = true;
            if (hasSpecial && hasNum && hasLower && hasUpper) break;
        }
        if (hasUpper) required--;
        if (hasLower) required--;
        if (hasSpecial) required--;
        if (hasNum) required--;

        if (n >= 6) return required;
        else return Math.Max(required, 6 - n);
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        string password = Console.ReadLine();

        int answer = Result.minimumNumber(n, password);

        textWriter.WriteLine(answer);

        textWriter.Flush();
        textWriter.Close();
    }
}
