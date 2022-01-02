using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Euler;

namespace Euler
{
    class Program
    {
        static void Main(string[] args)
        {
            // No deployable code
            // Run unit tests to check problem solutions
            var x = FibonacciHelper.ConstructFibonacciSequenceUptoIndex(10);
            for (int i = 0; i < x.Count(); i++)
            {
                Console.WriteLine(x[i + 1]);
            }
            // test
        }
    }
}