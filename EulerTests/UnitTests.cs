using Euler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

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
            List<long> fibonacci = EulerHelperFunctions.CreateFibonacciSequence(maxValue);
            Assert.AreEqual(EulerHelperFunctions.SumEvenNumbers(fibonacci), 4613732);
        }

        [TestMethod]
        public void Problem3()
        {
            // Problem 3 solution
        }


    }
}
