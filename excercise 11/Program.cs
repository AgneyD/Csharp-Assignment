using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace excercise_11
{
    public static class Program
    {

        //IsOdd Extention function
        public static bool IsOdd(this int value)
        {
            return value % 2 != 0;
        }

        //IsEven Extention function
        public static bool IsEven(this int value)
        {
            return value % 2 == 0;
        }

        //IsPrime Extention function
        public static bool IsPrime(this int number)
            {
                if ((number % 2) == 0)
                {
                    return number == 2;
                }
                int sqrt = (int)Math.Sqrt(number);
                for (int t = 3; t <= sqrt; t = t + 2)
                {
                    if (number % t == 0)
                    {
                        return false;
                    }
                }
                return number != 1;
            }

        //IsDivisibleBy Extention function
        public static bool IsDivisibleBy(this int number, int dividingNumber)
        {
            return number % dividingNumber == 0;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number: ");

            int num = Convert.ToInt32(Console.ReadLine());

            bool isOdd = num.IsOdd();
            Console.WriteLine("The number is odd : {0}", isOdd);

            bool isEven = num.IsEven();
            Console.WriteLine("The number is even : {0}", isEven);

            bool isPrime = num.IsPrime();
            Console.WriteLine("The number is Prime : {0}", isPrime);

            Console.WriteLine("Enter the number you want to check whether previous number is divisible by it or not: ");
            int dividingNum = Convert.ToInt32(Console.ReadLine());
            bool isDivisibleBy = num.IsDivisibleBy(dividingNum);
            Console.WriteLine("The number is divisible by {0} : {1}", dividingNum, isDivisibleBy);
        }
    }
}
