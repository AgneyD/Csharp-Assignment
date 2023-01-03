using System;
using System.Collections.Generic;

namespace excercise_13
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[5] { 2, 3, 4, 5, 6 };
            Console.WriteLine(array.CustomAll(x => x > 1));
            Console.WriteLine(array.CustomAll(x => x > 1));
            Console.WriteLine(array.CustomAny(x => x < 0));
            Console.WriteLine(array.CustomMax(x => x * 2));
            Console.WriteLine(array.CustomMin(x => x - 1));
            Console.WriteLine(string.Join(", ", array.CustomWhere(x => x > 3)));
            Console.WriteLine(string.Join(", ", array.CustomSelect(x => x + 1)));
        }
    }


    public static class EnumerableExtensions
    {
        public static bool CustomAll<T>(this IEnumerable<T> enumerable, Func<T, bool> func)
        {
            if (enumerable is null)
                throw new ArgumentNullException(nameof(enumerable));


            foreach (var elem in enumerable)
            {
                if (!func(elem))
                    return false;
            }


            return true;
        }


        public static bool CustomAny<T>(this IEnumerable<T> enumerable, Func<T, bool> func)
        {
            if (enumerable is null)
                throw new ArgumentNullException(nameof(enumerable));


            foreach (var elem in enumerable)
            {
                if (func(elem))
                    return true;
            }


            return false;
        }


        public static TResult CustomMax<T, TResult>(this IEnumerable<T> enumerable, Func<T, TResult> func) where TResult : IComparable<TResult>
        {
            if (enumerable is null)
                throw new ArgumentNullException(nameof(enumerable));


            TResult max;


            using var enumerator = enumerable.GetEnumerator();
            if (enumerator.MoveNext())
            {
                max = func(enumerator.Current);
            }
            else throw new InvalidOperationException("Sequence contains no elements");


            while (enumerator.MoveNext())
            {
                var result = func(enumerator.Current);
                if (max is null || max.CompareTo(result) < 0)
                    max = result;
            }


            return max;
        }


        public static TResult CustomMin<T, TResult>(this IEnumerable<T> enumerable, Func<T, TResult> func) where TResult : IComparable<TResult>
        {
            if (enumerable is null)
                throw new ArgumentNullException(nameof(enumerable));


            TResult min;


            using var enumerator = enumerable.GetEnumerator();
            if (enumerator.MoveNext())
            {
                min = func(enumerator.Current);
            }
            else throw new InvalidOperationException("Sequence contains no elements");


            while (enumerator.MoveNext())
            {
                var result = func(enumerator.Current);
                if (min is null || min.CompareTo(result) > 0)
                    min = result;
            }


            return min;
        }


        public static IEnumerable<T> CustomWhere<T>(this IEnumerable<T> enumerable, Func<T, bool> func)
        {
            if (enumerable is null)
                throw new ArgumentNullException(nameof(enumerable));


            foreach (var elem in enumerable)
            {
                if (func(elem))
                    yield return elem;
            }
        }


        public static IEnumerable<TResult> CustomSelect<T, TResult>(this IEnumerable<T> enumerable, Func<T, TResult> func)
        {
            if (enumerable is null)
                throw new ArgumentNullException(nameof(enumerable));


            foreach (var elem in enumerable)
            {
                yield return func(elem);
            }
        }
    }
}
