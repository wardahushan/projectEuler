using Xunit;
using Euler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace EulerTests
{
    public class UnitTests
    {
        [Fact]
        public void Problem1()
        {
            int maxNumber = 1000;
            int[] factors = new int[] { 3, 5 };
            Assert.Equal(233168, EulerHelperFunctions.GetMultiples(maxNumber, factors).Sum());
        }

        [Fact]
        public void Problem2()
        {
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

            Assert.Equal(4613732, fibonacci.Values.Where(x => x < maxValue && x % 2 == 0).Aggregate(BigInteger.Add));
        }

        [Fact]
        public void Problem3()
        {
            List<long> factors = EulerHelperFunctions.GetAllFactors(600851475143);
            List<long> primes = EulerHelperFunctions.GetPrimeNumbers(factors);
            Assert.Equal(6857, primes.Max());
        }

        [Fact]
        public void Problem4()
        {
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

            Assert.Equal(906609, largestPalindrome);
        }

        [Fact]
        public void Problem5()
        {
            long number = 1;
            long[] factors = new long[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            while (!EulerHelperFunctions.IsMultipleOfAllFactor(number, factors))
            {
                number++;
            }

            Assert.Equal(232792560, number);
        }

        [Fact]
        public void Problem6()
        {
            long sumOfSquares = EulerHelperFunctions.SumOfSquares(100);
            long squareOfSums = EulerHelperFunctions.SquareOfSums(100);
            Assert.Equal(25164150, squareOfSums - sumOfSquares);
        }

        [Fact]
        public void Problem7()
        {
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

            Assert.Equal(104743, prime);
        }

        [Fact]
        public void Problem8()
        {
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

            Assert.Equal(23514624000, sum);
        }

        [Fact]
        public void Problem9()
        {
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

            Assert.Equal(31875000, product);
        }


        [Fact]
        public void Problem10()
        {
            List<long> numbersList = EulerHelperFunctions.CreateListOfNumbers(2000000);
            List<long> primes = EulerHelperFunctions.GetPrimeNumbers(numbersList);
            Assert.Equal(142913828922, primes.Sum());
        }

        [Fact]
        public void Problem12()
        {
            long n = 1;
            long nthTriangularNumber = 1;
            List<long> factors = EulerHelperFunctions.GetAllFactors(nthTriangularNumber);

            while (factors.Count <= 500)
            {
                n++;
                nthTriangularNumber += n;
                factors = EulerHelperFunctions.GetAllFactors(nthTriangularNumber);
            }

            Assert.Equal(76576500, nthTriangularNumber);
        }

        [Fact]
        public void Problem13()
        {
            string filePath = @"C\Users\wardahushan\Documents\Programming\projectEuler\Data\Problem13.txt";
            string[] lines = File.ReadAllLines(filePath);
            BigInteger sum = 0;

            foreach (string line in lines)
            {
                sum += BigInteger.Parse(line);
            }

            Assert.Equal("5537376230", sum.ToString().Substring(0, 10));
        }

        [Fact]
        public void Problem14()
        {
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

            Assert.Equal(837799, startNumberForLongestSequence);
        }

        [Fact]
        public void Problem16()
        {
            string powerAsString = ((BigInteger)Math.Pow(2, 1000)).ToString();
            Assert.Equal(1366, EulerHelperFunctions.SumIndividualDigitsInString(powerAsString));
        }

        [Fact]
        public void Problem19()
        {
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

            Assert.Equal(171, numberOfFirstSundays);
        }

        [Fact]
        public void Problem20()
        {
            string factorialAsString = ((BigInteger)EulerHelperFunctions.Factorial(100)).ToString();
            Assert.Equal(648, EulerHelperFunctions.SumIndividualDigitsInString(factorialAsString));
        }

        [Fact]
        public void Problem21()
        {
            var sum = 0;
            for (int i = 1; i < 10000; i++)
            {
                if (EulerHelperFunctions.IsAmicable(i))
                {
                    sum = sum + i;
                }
            }

            Assert.Equal(31626, sum);
        }


        [Fact]
        public void Problem22()
        {
            Dictionary<char, long> dic = new Dictionary<char, long>();
            dic.Add('A', 1);
            dic.Add('B', 2);
            dic.Add('C', 3);
            dic.Add('D', 4);
            dic.Add('E', 5);
            dic.Add('F', 6);
            dic.Add('G', 7);
            dic.Add('H', 8);
            dic.Add('I', 9);
            dic.Add('J', 10);
            dic.Add('K', 11);
            dic.Add('L', 12);
            dic.Add('M', 13);
            dic.Add('N', 14);
            dic.Add('O', 15);
            dic.Add('P', 16);
            dic.Add('Q', 17);
            dic.Add('R', 18);
            dic.Add('S', 19);
            dic.Add('T', 20);
            dic.Add('U', 21);
            dic.Add('V', 22);
            dic.Add('W', 23);
            dic.Add('X', 24);
            dic.Add('Y', 25);
            dic.Add('Z', 26);

            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\qwu\Downloads\Work\names.txt");
            string line = file.ReadLine();

            List<string> names = line.Split(',').ToList();

            List<string> names_ordered = new List<string>();
            foreach (string name in names)
            {
                var name_trim = name.Trim('"');
                names_ordered.Add(name_trim);
            }

            names_ordered = names_ordered.OrderBy(x => x).ToList();
            double totalSum = 0;
            double count = 0;
            foreach (string name in names_ordered)
            {
                count = count + 1;
                double sum = 0;
                foreach (char character in name)
                {
                    sum = sum + dic[character];
                }

                totalSum = totalSum + sum * count;

                Assert.Equal(871198282, totalSum);
            }
        }

        [Fact]
        public void Problem24()
        {
            string numberToPerm = "0123456789";
            List<string> permutations = new List<string>();
            EulerHelperFunctions.GetPermutations(numberToPerm.ToCharArray(), numberToPerm.Length, permutations);

            Assert.Equal("2783915460", permutations.OrderBy(x => x).Skip(999999).First());
        }

        [Fact]
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

            Assert.Equal(4782, fibonacci.First(x => x.Value.ToString().Length == 1000).Key);
        }

        [Fact]
        public void Problem29()
        {
            double start = 2;
            double end = 100;
            List<double> myNumbers = new List<double>();

            for (double a = start; a <= end; a++)
            {
                for (double b = start; b <= end; b++)
                {
                    myNumbers.Add(Math.Pow(a, b));
                }
            }

            Assert.Equal(9183, myNumbers.Distinct().Count());
        }

        [Fact]
        public void Problem41()
        {
            string numberToPerm = "1";
            List<string> permutations = new List<string>();
            for (int i = 1; i < 9; i++)
            {
                int j = i + 1;
                numberToPerm += j;
                EulerHelperFunctions.GetPermutations(numberToPerm.ToCharArray(), numberToPerm.Length, permutations);
            }

            long largestPandigital = 0;
            foreach (long number in permutations.ConvertAll(x => Int64.Parse(x)).OrderByDescending(x => x))
            {
                if (EulerHelperFunctions.IsPrime(number))
                {
                    largestPandigital = number;
                    return;
                }
            }

            Assert.Equal(7652413, largestPandigital);
        }
    }
}
