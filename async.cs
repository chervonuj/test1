using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class asyncSmth
    {
        static void Main(string[] args)
        {
          
            Console.WriteLine(backwardsPrime(1, 100));
            Console.WriteLine(backwardsPrime(109536, 109664));
          //  Console.WriteLine(Reverse(109537));
          //  Console.WriteLine(Reverse(9901));
            Console.ReadLine();
        }
        public static string backwardsPrime(long start, long end)
        {
            List<long> result = new List<long>();
            for (var i = start; i <= end;i++)
            {
                if ((IsPrime(i) && IsPrime(Reverse(i))) &&i!=Reverse(i) )
                {
                    result.Add(i);
                }
            }

            string res = "";
            for (int i = 0; i < result.Count; i++)
            {
                res += result[i];
                if (i != result.Count - 1)
                {
                    res += " ";
                }
            }

            return res;
            // your code
        }

        public static long Reverse(long number)
        {
            long res = 0;
            long i = 0;
            long tmp = number;
            while (tmp > 0)
            {
                tmp /= 10;
                i++;
            }
            while (number>=1)
            {
                res += (number % 10) * (long)Math.Pow(10, i);
                i--;
                number /= 10;
            }
            return res/10;
        }

        public static bool IsPrime(long number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (long)Math.Floor(Math.Sqrt(number));

            for (long i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

    }
}
