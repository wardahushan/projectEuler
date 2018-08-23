using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Euler
{
    internal static class EulerHelperFunctions
    {
        public static List<int> GetMultiples(int maxNumber, int[] factors)
        {
            List<int> multiples = new List<int>();

            for (int i = 0; i < maxNumber; i++)
            {
                if (IsMultipleOfAnyFactor(i, factors))
                {
                    multiples.Add(i);
                }
            }

            return multiples;
        }

        private static bool IsMultipleOfAnyFactor(int i, int[] factors)
        {
            foreach (int factor in factors)
            {
                if (i % factor == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsMultipleOfAllFactor(long i, long[] factors)
        {
            foreach (long factor in factors)
            {
                if (i % factor != 0)
                {
                    return false;
                }
            }

            return true;
        }


        public static List<long> CreateFibonacciSequence(long maxNumber)
        {
            List<long> sequence = new List<long>();
            sequence.Add(1);
            sequence.Add(2);

            int index = 2;
            long nextNumber = sequence[index - 1] + sequence[index - 2];

            while (nextNumber <= maxNumber)
            {
                sequence.Add(nextNumber);
                index++;
                nextNumber = sequence[index - 1] + sequence[index - 2];
            }

            return sequence;
        }

        public static long SumEvenNumbers(List<long> fibonacci)
        {
            return fibonacci.AsEnumerable().Where(x => x % 2 == 0).Sum();
        }

        // TODO: make this more efficient?
        public static List<long> GetAllFactors(long number)
        {
            List<long> factors = new List<long>();
            long limit = (long)Math.Sqrt(number);

            for (long i = 2; i <= limit; i++)
            {
                if (number % i == 0)
                {
                    factors.Add(i);

                    if (number % i == i)
                    {
                        factors.Add(number / i);
                    }
                }
            }

            if (!factors.Contains(1))
            {
                factors.Add(1);
            }

            factors.Add(number);
            return factors;
        }

        public static List<long> GetPrimeNumbers(List<long> numbersList)
        {
            List<long> primes = new List<long>();

            foreach (long number in numbersList)
            {
                if (IsPrime(number))
                {
                    primes.Add(number);
                }

            }

            return primes;
        }

        public static bool IsPrime(long number)
        {
            return (number != 1 && GetAllFactors(number).Count == 2);
        }

        public static bool IsPalindrome(string text)
        {
            int halfwayPoint = text.Length / 2;
            string firstHalf = text.Substring(0, halfwayPoint);
            halfwayPoint += text.Length % 2 != 0 ? 1 : 0;
            string secondHalf = text.Substring(halfwayPoint);

            return firstHalf == ReverseString(secondHalf);
        }

        private static string ReverseString(string text)
        {
            char[] textAsArray = text.ToCharArray();
            Array.Reverse(textAsArray);
            string reversedString = new string(textAsArray);
            return reversedString;
        }

        public static long SumOfSquares(long maxNumber)
        {
            return maxNumber * (maxNumber + 1) * (2 * maxNumber + 1) / 6;
        }

        public static long SquareOfSums(long maxNumber)
        {
            long triangular = NthTriangularNumber(maxNumber);
            return triangular * triangular;
        }

        public static long NthTriangularNumber(long n)
        {
            return n * (n + 1) / 2;
        }

        public static List<long> CreateListOfNumbers(long Number)
        {
            List<long> listOfNumbers = new List<long>();

            for (long i = 1; i <= Number; i++)
            {
                listOfNumbers.Add(i);
            }

            return listOfNumbers;
        }

        public static bool IsPythagoreanTriplet(long a, long b, long c)
        {
            return (a * a + b * b) == c * c;
        }

        public static long ProductIndividualDigitsInString(string extractedNumber)
        {
            long product = 1;

            foreach (char number in extractedNumber)
            {
                product = product * Int64.Parse(number.ToString());
            }

            return product;
        }

        public static long SumIndividualDigitsInString(string extractedNumber)
        {
            long sum = 0;

            foreach (char number in extractedNumber)
            {
                bool addNumber = Int64.TryParse(number.ToString(), out long numberToAdd);
                sum += addNumber ? Int64.Parse(number.ToString()) : 0;
            }

            return sum;
        }

    }
}