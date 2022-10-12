using System;
using System.Collections.Generic;
using System.Linq;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> seq = new[] { 20, 9, 121, 40, 49, 50, 76, 74 };
            int sortFactor = 100; 
            var seq2 = Sort(seq, sortFactor, 200);
            foreach (var item in seq2)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Возвращает отсортированный по возрастанию поток чисел
        /// </summary>
        /// <param name="inputStream">Поток чисел от 0 до maxValue. Длина потока не превышает миллиарда чисел.</param>
        /// <param name="sortFactor">Фактор упорядоченности потока. Неотрицательное число. Если в потоке встретилось число x, то в нём больше не встретятся числа меньше, чем (x - sortFactor).</param>
        /// <param name="maxValue">Максимально возможное значение чисел в потоке. Неотрицательное число, не превышающее 2000.</param>
        /// <returns>Отсортированный по возрастанию поток чисел.</returns>
        static IEnumerable<int> Sort(IEnumerable<int> inputStream, int sortFactor, int maxValue)
        {
            int[] buffer = new int[maxValue + 1];
            int left = maxValue + 1;
            int incomingMin = 0;
            foreach (var item in inputStream)
            {
                buffer[item]++;
                left = Math.Min(left, item);
                if (item - sortFactor > incomingMin) // сброс буфера при обновлении
                {
                    incomingMin = item - sortFactor;
                    for (int i = left; i < incomingMin; ++i)
                    {
                        while (buffer[i]-- > 0)
                        {
                            yield return i; 
                        }
                    }
                    left = Math.Max(incomingMin, left);
                }
            }
            for (int i = incomingMin; i < buffer.Length; ++i) // сбросить оставшиеся значения
            {
                while (buffer[i]-- > 0)
                {
                    yield return i; 
                }
            }
        }

    }
}
