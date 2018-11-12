using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    class Program
    {
        static void Main(string[] args)
        {
            // No deployable code
            // Run unit tests to check problem solutions

            // For each set of numbers 1, 12, 123, 124, ... , 9 
            // Get all the permutatiosn and add them to a list

            // Problem 41

            //string numberToPerm = "1";
            //List<string> permutations = new List<string>();
            //for (int i = 1; i < 9; i++)
            //{
            //    int j = i + 1;
            //    numberToPerm += j;
            //    EulerHelperFunctions.GetPermutations(numberToPerm.ToCharArray(), numberToPerm.Length, permutations);
            //}

            //List<long> permutationsAsNumber = permutations.ConvertAll(x => Int64.Parse(x));

            //long y = permutationsAsNumber.Max();

            //foreach (long number in permutationsAsNumber.OrderByDescending(x => x))
            //{
            //    Console.WriteLine(number);

            //    if (EulerHelperFunctions.IsPrime(number))
            //    {
            //        Console.WriteLine("\nFound it!");
            //        Console.WriteLine(number);
            //        return;
            //    }
            //}

            // Problen 24 
            //string numberToPerm = "0123456789";
            //List<string> permutations = new List<string>();
            //EulerHelperFunctions.GetPermutations(numberToPerm.ToCharArray(), numberToPerm.Length, permutations);
            //List<string> newList = permutations.OrderBy(x => x).ToList(); 

            //string str = "abcd";
            //List<string> permutations = new List<string>();
            //EulerHelperFunctions.GetPermutations(str.ToCharArray(), str.Length, permutations);
            //int y = permutations.Distinct().Count();
        }

        enum NumberToWordLength
        {
            one = 3,
            two = 3, 
            three = 5, 
            four = 4,
            five = 4, 
            six = 3, 
            seven = 5, 
            eight = 5, 
            nine = 4, 
            ten = 3, 
            hundred = 100, 
            thousand = 1000
        }
    }
}

