using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the integer:");

        //Use conversion functions to convert string to int
        int num = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("You Entered : " + num);
    }
}