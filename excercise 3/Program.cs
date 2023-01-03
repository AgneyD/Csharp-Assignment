using System;

namespace excercise_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1, num2, i, j, primeCheck;//integer declarations
            do
            {
                Console.WriteLine("Please enter numbers between 2 and 1000");//input instruction
                num1 = Convert.ToInt32(Console.ReadLine());//first number input
                num2 = Convert.ToInt32(Console.ReadLine());//second number input
                if (num1 > num2) {                         //first condition check for first number smaller than second number
                    Console.WriteLine("First number should be smaller than second number");//instruction
                }
                else if (num1 < 2 || num2 > 1000)//second condition check for range
                {
                    Console.WriteLine("Numbers should be in range of 2 to 1000");//instruction
                }            
                
            } while (num1 > num2 || num1<2 || num2>1000);//loop termination condition

            Console.WriteLine("Prime numbers between {0} and {1}", num1, num2);

            //prime number finder
            for (i = num1; i <= num2; i++)//interating over each number in the range
            {
                primeCheck = 1;
                for (j = 2; j <= i/2; j++)//checking if number is prime or not
                {
                    if (i % j == 0)
                    {
                        primeCheck = 0;
                        break;
                    }
                }
                if (primeCheck == 1)// if primeCheck=1 then prime otherwise non prime
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
