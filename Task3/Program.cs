using System;
using System.Collections.Generic;
using System.Linq; 

namespace Task3
{
    public static class IEnumerableExtension
    {
        /// <summary>
        /// <para> Отсчитать несколько элементов с конца </para>
        /// <example> new[] {1,2,3,4}.EnumerateFromTail(2) = (1, ), (2, ), (3, 1), (4, 0)</example>
        /// </summary> 
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="tailLength">Сколько элеметнов отсчитать с конца  (у последнего элемента tail = 0)</param>
        /// <returns></returns>
        public static IEnumerable<(T item, int? tail)> EnumerateFromTail<T>(this IEnumerable<T> enumerable, int? tailLength)
        {
            if (tailLength is null || tailLength < 0) tailLength = 0;
            int tailLengthNoNull = tailLength.Value; 
            var inputLength = enumerable.Count();
            tailLengthNoNull = Math.Min(tailLengthNoNull, inputLength); 

            int i = 1, j = tailLengthNoNull - 1, skipLength = inputLength - tailLengthNoNull; 

            foreach (var item in enumerable)
            {
                if (i <= skipLength) yield return (item, null); else yield return (item, j--); 
                ++i; 
            }
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            IEnumerable<int> seq = new[] { 1, 2, 3, 4 };
            //List<string> seq2 = new List<string>(new[] { "1", "2", "3", "4" });
            //Stack<int> seq3 = new Stack<int>(new[] { 1, 2, 3, 4 }); 
            var tailLength = 2; 
            foreach (var item in seq.EnumerateFromTail(tailLength))
            {
                Console.WriteLine(item);
            }

        }
    }
}
