using Euler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace EulerTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void Problem1()
        {
            // Problem 1 example
            int maxNumber = 10;
            int[] factors = new int[] { 3, 5 };
            Assert.AreEqual(EulerHelperFunctions.GetMultiples(maxNumber, factors).Sum(), 23);

            // Problem 1 solution
            maxNumber = 1000;
            Assert.AreEqual(EulerHelperFunctions.GetMultiples(maxNumber, factors).Sum(), 233168);
        }

        [TestMethod]
        public void Problem2()
        {
            // Problem 2 solution
            long maxValue = 4000000;
            long maxIndex = 100;
            bool stop = false;
            Dictionary<long, BigInteger> fibonacci = new Dictionary<long, BigInteger>();

            while (!stop)
            {
                fibonacci = FibonacciHelper.ConstructFibonacciSequenceUptoIndex(maxIndex);
                stop = fibonacci.Values.Max() >= maxValue;
                maxIndex += maxIndex;
            }

            Assert.AreEqual(fibonacci.Values.Where(x => x < maxValue && x % 2 == 0).Aggregate(BigInteger.Add), 4613732);
        }

        [TestMethod]
        public void Problem3()
        {
            // Problem 3 solution
            long number = 600851475143;
            List<long> factors = EulerHelperFunctions.GetAllFactors(number);
            List<long> primes = EulerHelperFunctions.GetPrimeNumbers(factors);
            Assert.AreEqual(primes.Max(), 6857);
        }

        [TestMethod]
        public void Problem4()
        {
            // Problem 4 solution
            long minNumber = 100;
            long maxNumber = 999;
            long largestPalindrome = 0;

            for (long i = minNumber; i <= maxNumber; i++)
            {
                for (long j = minNumber; j < maxNumber; j++)
                {
                    largestPalindrome =
                        (i * j > largestPalindrome && EulerHelperFunctions.IsPalindrome((i * j).ToString()))
                            ? i * j
                            : largestPalindrome;
                }
            }

            Assert.AreEqual(largestPalindrome, 906609);
        }

        [TestMethod]
        public void Problem5()
        {
            // Problem 5 solution

            long number = 1;
            long[] factors = new long[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            while (!EulerHelperFunctions.IsMultipleOfAllFactor(number, factors))
            {
                number++;
            }

            Assert.AreEqual(number, 232792560);

        }

        [TestMethod]
        public void Problem6()
        {
            // Problem 6 example
            long sumOfSquares = EulerHelperFunctions.SumOfSquares(10);
            long squareOfSums = EulerHelperFunctions.SquareOfSums(10);
            Assert.AreEqual(squareOfSums - sumOfSquares, 2640);

            // Problem 6 solution
            sumOfSquares = EulerHelperFunctions.SumOfSquares(100);
            squareOfSums = EulerHelperFunctions.SquareOfSums(100);
            Assert.AreEqual(squareOfSums - sumOfSquares, 25164150);
        }

        [TestMethod]
        public void Problem7()
        {
            // Problem 7 solution 

            long number = 2;
            long counter = 1;
            long prime = number;

            while (counter <= 10001)
            {
                if (EulerHelperFunctions.IsPrime(number))
                {
                    counter++;
                    prime = number;
                }

                number++;
            }

            Assert.AreEqual(prime, 104743);
        }

        [TestMethod]
        public void Problem8()
        {
            // Problem 8 solution

            string thousandDigitNumber =
                "73167176531330624919225119674426574742355349194934" +
                "96983520312774506326239578318016984801869478851843" +
                "85861560789112949495459501737958331952853208805511" +
                "12540698747158523863050715693290963295227443043557" +
                "66896648950445244523161731856403098711121722383113" +
                "62229893423380308135336276614282806444486645238749" +
                "30358907296290491560440772390713810515859307960866" +
                "70172427121883998797908792274921901699720888093776" +
                "65727333001053367881220235421809751254540594752243" +
                "52584907711670556013604839586446706324415722155397" +
                "53697817977846174064955149290862569321978468622482" +
                "83972241375657056057490261407972968652414535100474" +
                "82166370484403199890008895243450658541227588666881" +
                "16427171479924442928230863465674813919123162824586" +
                "17866458359124566529476545682848912883142607690042" +
                "24219022671055626321111109370544217506941658960408" +
                "07198403850962455444362981230987879927244284909188" +
                "84580156166097919133875499200524063689912560717606" +
                "05886116467109405077541002256983155200055935729725" +
                "71636269561882670428252483600823257530420752963450";

            int lengthOfNumber = 13;
            long sum = 0;

            while (thousandDigitNumber.Length > 13)
            {
                string extractedNumber = thousandDigitNumber.Substring(0, lengthOfNumber);
                long currentSum = EulerHelperFunctions.ProductIndividualDigitsInString(extractedNumber);
                sum = currentSum > sum ? currentSum : sum;

                thousandDigitNumber = thousandDigitNumber.Remove(0, 1);
            }

            Assert.AreEqual(sum, 23514624000);
        }

        [TestMethod]
        public void Problem9()
        {
            // Problem 9 solution

            int cMax = 998;
            int product = 0;

            for (int a = 1; a <= cMax - 2; a++)
            {
                for (int b = a + 1; b <= cMax - 1; b++)
                {
                    for (int c = b + 1; c <= cMax; c++)
                    {
                        if (EulerHelperFunctions.IsPythagoreanTriplet((long)a, (long)b, (long)c) && a + b + c == 1000)
                        {
                            product = a * b * c;
                            return;
                        }
                    }
                }
            }

            Assert.AreEqual(product, 31875000);
        }


        [TestMethod]
        public void Problem10()
        {
            // Problem 10 solution 

            List<long> numbersList = EulerHelperFunctions.CreateListOfNumbers(2000000);
            List<long> primes = EulerHelperFunctions.GetPrimeNumbers(numbersList);
            Assert.AreEqual(primes.Sum(), 142913828922);
        }

        [TestMethod]
        public void Problem12()
        {
            // Problem 12 solution

            long n = 1;
            long nthTriangularNumber = 1;
            List<long> factors = EulerHelperFunctions.GetAllFactors(nthTriangularNumber);

            while (factors.Count <= 500)
            {
                n++;
                nthTriangularNumber += n;
                factors = EulerHelperFunctions.GetAllFactors(nthTriangularNumber);
            }

            Assert.AreEqual(nthTriangularNumber, 76576500);
        }

        [TestMethod]
        public void Problem13()
        {
            string filePath = @"C:\Users\wushan\Desktop\projectEuler\Data\Problem13.txt";
            string[] lines = File.ReadAllLines(filePath);
            BigInteger sum = 0;

            foreach (string line in lines)
            {
                sum += BigInteger.Parse(line);
            }

            Assert.AreEqual(sum.ToString().Substring(0, 10), "5537376230");
        }

        [TestMethod]
        public void Problem14()
        {
            // Problem 14 solution

            long startNumberForLongestSequence = 0;
            long maxLength = 1;

            for (long i = 1; i <= 1000000; i++)
            {
                long newLength = EulerHelperFunctions.GenerateCollatzSequence(i).Count();

                if (newLength > maxLength)
                {
                    maxLength = newLength;
                    startNumberForLongestSequence = i;
                }
            }

            Assert.AreEqual(startNumberForLongestSequence, 837799);
        }

        [TestMethod]
        public void Problem16()
        {
            string powerAsString = ((BigInteger)Math.Pow(2, 1000)).ToString();
            Assert.AreEqual(EulerHelperFunctions.SumIndividualDigitsInString(powerAsString), 1366);
        }

        [TestMethod]
        public void Problem19()
        {
            // Problem 19 solution 

            DateTime startDate = new DateTime(1901, 1, 1);
            DateTime endDate = new DateTime(2000, 12, 31);

            int numberOfFirstSundays = 0;
            DateTime date = startDate;

            while (date < endDate)
            {
                if (date.DayOfWeek == DayOfWeek.Sunday)
                {
                    numberOfFirstSundays++;
                }

                date = date.AddMonths(1);
            }

            Assert.AreEqual(numberOfFirstSundays, 171);
        }


        [TestMethod]
        public void Problem25()
        {
            long maxIndex = 1000;
            bool stop = false;
            Dictionary<long, BigInteger> fibonacci = new Dictionary<long, BigInteger>();

            while (!stop)
            {
                fibonacci = FibonacciHelper.ConstructFibonacciSequenceUptoIndex(maxIndex);
                stop = fibonacci.Values.Max().ToString().Length >= 1000;
                maxIndex += maxIndex;
            }

            Assert.AreEqual(fibonacci.First(x => x.Value.ToString().Length == 1000).Key, 4782);
        }


        //[TestMethod]
        //public void Problem8()
        //{ }





    }
}
