using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Euler
{
    public static class EulerHelperFunctions
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
        } // test

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

        public static long SumEvenNumbers(List<long> numbersToSum)
        {
            return numbersToSum.AsEnumerable().Where(x => x % 2 == 0).Sum();
        }

        public static long SumList(List<long> numbersToSum)
        {
            long sum = 0; 
            foreach (long number in numbersToSum)
            {
                sum = sum + number; 
            }

            return sum;
        }

        public static bool IsAmicable(long number)
        {
            var factors = GetAllFactors(number);
            factors.Remove(number);
            long sum = SumList(factors);

            factors = GetAllFactors(sum);
            factors.Remove(sum);
            long sum2 = SumList(factors);

            return (number == sum2 && sum != number);
        }

        public static bool IsAbundant(long number)
        {
            var factors = GetAllFactors(number);
            factors.Remove(number);
            long sum = SumList(factors);

            return (sum > number);
        }

        // TODO: make this more efficient?
        public static List<long> GetAllFactors(long number)
        {
            List<long> factors = new List<long>();
            long limit = (long)Math.Sqrt(number);

            for (long i = 1; i <= limit; i++)
            {
                if (number % i == 0)
                {
                    if (!factors.Contains(i))
                    {
                        factors.Add(i);
                    }

                    if (number % i != i && !factors.Contains(number / i))
                    {
                        factors.Add(number / i);
                    }
                }
            }

            return factors;
        }

        public static bool IsComposite(long number)
        {
            var factors = GetAllFactors(number); 
            if (factors.Count() >= 3)
                    return true;

            return false;
        }
        public static bool IsStrongHarshad(long number)
        {
            long sum = SumIndividualDigitsInString(number.ToString());
            long div = Math.DivRem(number, sum, out long rem);
            return rem == 0 && IsPrime(div); 
        }

        public static bool IsHarshad(long number)
        {
            long sum = SumIndividualDigitsInString(number.ToString());
            long div = Math.DivRem(number, sum, out long rem);
            return rem == 0;
        }

        public static bool StrongAndRightTruncHarshad(long number)
        {
            if (!IsStrongHarshad(number))
            {
                return false; 
            }

            string num_str = number.ToString();
            bool isTrue = true; 

            for (int i = 1; i < num_str.Length; i++)
            {
                string sub_str = num_str.Substring(0, i);
                isTrue = IsHarshad(long.Parse(sub_str));

                if (!isTrue)
                {
                    return false; 
                }
            }

            return true; 
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

        public static string ReverseString(string text)
        {
            char[] textAsArray = text.ToCharArray();
            Array.Reverse(textAsArray);
            string reversedString = new string(textAsArray);
            return reversedString;
        }

        public static BigInteger ReverseAndAdd(BigInteger number)
        {
            string n_rev = EulerHelperFunctions.ReverseString(number.ToString());
            var n2 = BigInteger.Parse(n_rev) + number;
            return n2;
        }

        public static bool IsLychrel(BigInteger number)
        {
            BigInteger n = number;
            for (int iter = 1; iter <= 50; iter++)
            {
                n = ReverseAndAdd(n);
                if (IsPalindrome(n.ToString()))
                    return false;
            }

            return true;
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

        public static long GetDigitSquare(long n)
        {
            string n_string = n.ToString();
            long digitSquare = 0;
            foreach (char digit in n_string)
            {
                var t = Int64.Parse(digit.ToString());
                digitSquare = digitSquare + (long)Math.Pow(t, 2);
            }

            return digitSquare; 
        }

        public static bool IsBouncy(long n)
        {
            string n_string = n.ToString();
            if (n_string.Length <= 2)
            {
                return false; 
            }

            long prevDiff = 0; 

            for (int i = 1; i < n_string.Length; i++)
            {
                long diff = long.Parse(n_string.Substring(i, 1)) - long.Parse(n_string.Substring(i - 1, 1));

                if ((diff > 0 && prevDiff < 0) || (diff < 0 && prevDiff > 0))
                {
                    return true; 
                }

                prevDiff = diff; 
            }
         
            return false;  
        }

        public static BigInteger GetSmallestNumberForDigitSum(BigInteger n)
        {
            BigInteger i = 1;
            BigInteger sum = 0;

            while (sum != n)
            {
                sum = SumIndividualDigitsInString(i.ToString());
                i = i + 1; 
            }

            return i - 1; 
        }

        public static long GetDigitFactorial(long n)
        {
            string n_string = n.ToString();
            long digitFactorial = 0;
            foreach (char digit in n_string)
            {
                var t = long.Parse(digit.ToString());
                digitFactorial = digitFactorial  + (long)Factorial(t);
            }

            return digitFactorial;
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
                sum += numberToAdd;
            }

            return sum;
        }

        public static List<long> GenerateCollatzSequence(long number)
        {
            List<long> collatz = new List<long>();
            collatz.Add(number);

            while (number > 1)
            {
                number = IsEven(number) ? number / 2 : 3 * number + 1;
                collatz.Add(number);
            }

            return collatz;
        }

        public static bool IsEven(long number)
        {
            return number % 2 == 0;
        }

        public static BigInteger Factorial(long n)
        {
            BigInteger factorial = 1;
            while (n > 0)
            {
                factorial = factorial * n;
                n--;
            }

            return factorial;
        }
        public static BigInteger Combination(long n, long r)
        {
            return Factorial(n) / (Factorial(r) * Factorial(n - r)); 
        }

        public static bool IsPandigital(long number)
        {
            string numberAsString = number.ToString();

            for (int i = 1; i <= numberAsString.Length; i++)
            {
                if (!numberAsString.Contains(i.ToString()))
                {
                    return false;
                }
            }

            return true;
        }

        public static List<string> GetPermutations(char[] charArray, long n, List<string> permutations)
        {
            if (n == 1)
            {
                permutations.Add(new string(charArray));
            }
            else
            {
                for (int i = 0; i < n - 1; i++)
                {
                    GetPermutations(charArray, n - 1, permutations);

                    if (IsEven(n))
                    {
                        charArray = SwapStringCharacters(charArray, i, n - 1);
                    }
                    else
                    {
                        charArray = SwapStringCharacters(charArray, 0, n - 1);
                    }
                }

                GetPermutations(charArray, n-1, permutations);
            }

            return permutations;
        }

        private static char[] SwapStringCharacters(char[] charArrayIn, long i, long j)
        {
            char temp = charArrayIn[i];
            charArrayIn[i] = charArrayIn[j];
            charArrayIn[j] = temp;
            return charArrayIn;
        }
    }
}