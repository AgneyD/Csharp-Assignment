using System;

namespace excercise_2
{
    class Program
    {
        static void Main(string[] args)
        {
            object objOne = "sampleobj";
            object objTwo = objOne;
            object objThree = "sample2";

            Console.WriteLine(objOne == objTwo);//==comapres on the basis of refrence and do this during compile time and works with null values
            Console.WriteLine(objOne == objThree);
            Console.WriteLine(objThree == objTwo);
            Console.WriteLine(objOne.Equals(objTwo));//object.Equals() comapres on the basis of value and do this during run time and it doesn't works with null values
            Console.WriteLine(objOne.Equals(objThree));
            Console.WriteLine(objThree.Equals(objTwo));
            Console.WriteLine(object.ReferenceEquals(objOne, objTwo));// this method compares refrences and determine if 2 objects are in the same memory location
            Console.WriteLine(object.ReferenceEquals(objOne, objThree));
            Console.WriteLine(object.ReferenceEquals(objTwo, objThree));
        }
    }
}
