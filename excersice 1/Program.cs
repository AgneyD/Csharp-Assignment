using System;

namespace excersice_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //integer
            Console.WriteLine("First integer: ");
            int first = int.Parse(Console.ReadLine());//this method converts string to equivalent numerical integer and gives ArgumentNullException if passed null value
            Console.WriteLine("First Integer is " + first);
            
            Console.WriteLine("Second integer: ");
            int second = Convert.ToInt32(Console.ReadLine());//this method converts string to 32-bit signed integer and gives 0 if passed null value
            Console.WriteLine("Second Integer is " + second);

            Console.WriteLine("Enter input for tryparse method");
            bool intcheck;
            int third;
            string newStr = Console.ReadLine();
            intcheck = int.TryParse(newStr, out third);//this method provides true if string can be converted to integer otherwise false
            Console.WriteLine("Given input is Integer: " + intcheck);

            //float
            Console.WriteLine("Enter input for singleparse method");
            float fourth = Single.Parse(Console.ReadLine());//converts string representation to single-precision floating-point equivalent
            Console.WriteLine("Given input as float: " + fourth);
            
            Console.WriteLine("Enter input for floatparse method");
            float fifth = float.Parse(Console.ReadLine());
            Console.WriteLine("Given input as float: " + fifth);

            Console.WriteLine("Enter input for converttosingle method");
            float sixth = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Given input as float: " + sixth);

            //boolean
            Console.WriteLine("Enter input for converttobool method");
            float seventh = Single.Parse(Console.ReadLine());
            bool boolNum = Convert.ToBoolean(seventh);
            Console.WriteLine("Given input as boolean: " + boolNum);
        }
    }
}
