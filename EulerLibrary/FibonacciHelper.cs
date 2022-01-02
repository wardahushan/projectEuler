using Euler;
using System.Collections.Generic;
using System.Numerics;

namespace Euler
{
    public static class FibonacciHelper
    {
        public static Dictionary<long, BigInteger> ConstructFibonacciSequenceUptoIndex(long n)
        {
            long k;
            Dictionary<long, BigInteger> fibonacci = new Dictionary<long, BigInteger>();

            for (long i = 1; i <= n; i++)
            {
                if (i == 1 || i == 2)
                {
                    fibonacci.Add(i, 1);
                }
                else if (EulerHelperFunctions.IsEven(i))
                {
                    k = i / 2;
                    fibonacci.Add(i, fibonacci[k] * (2 * fibonacci[k + 1] - fibonacci[k]));
                }
                else
                {
                    k = (i - 1) / 2;
                    fibonacci.Add(i, (fibonacci[k + 1] * fibonacci[k + 1]) + fibonacci[k] * fibonacci[k]);
                }
            }

            return fibonacci;
        }   //test 

    }
}
