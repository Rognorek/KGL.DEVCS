/*
 * Сгенерировать список из 50 чисел со значениями от 0 до 25.
 * Реализовать функцию Min и Max с помощью OrderBy/OrderByDescending, First/Last.
 * Посчитать количество разных чисел используя Distinct и Count.
 * Найти элементы со значениями в пределах от 10 до 20 включительно и вывести их без повторения в порядке убывания. 
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace KGL.DEVCS.PROBLEM07
{
    class Problem07
    {
        const int MAX_SIZE = 100;
        const int MAX_RND = 100;
        const int SLICE_MIN = 31;
        const int SLICE_MAX = 58;

        static void Main()
        {
            List<int> randomNumbers = new(MAX_SIZE);

            Random RND = new();

            for (int i = 0; i < MAX_SIZE; i++)
            {
                randomNumbers.Add(RND.Next(MAX_RND));
            }
            Console.WriteLine("RANDOM LIST IS:");
            PrintList(randomNumbers);
            Console.WriteLine("FOR RANDOM LIST MIN={0:D2}, MAX={1:D2}\n", Min(randomNumbers), Max(randomNumbers));
            Console.WriteLine("FOR UNIC LIST COUNT={0:D2}\n", Unic(randomNumbers));
            Slice(randomNumbers);
        }

        static void PrintList(List<int> list)
        {
            int i = 0;
            foreach (int item in list)
            {
                if (i % 10 == 0 && i != 0) Console.WriteLine("");
                Console.Write("{0:D2} ", item);
                i++;
            }
            Console.WriteLine();
        }

        static int Min(List<int> list)
        {
            IEnumerable<int> temp = list.OrderBy(list => list);
            return temp.First();
        }

        static int Max(List<int> list)
        {
            IEnumerable<int> temp = list.OrderByDescending(list => list);
            return temp.First();
        }
        static int Unic(List<int> list)
        {
            IEnumerable<int> temp = list.OrderBy(list => list);
            Console.WriteLine("UNIC LIST FROM RANDOM LIST IS:");
            PrintList(temp.Distinct().ToList());
            return temp.Distinct().Count();
        }

        static void Slice(List<int> list)
        {
            List<int> outList = new();
            IEnumerable<int> temp = list.Where(list => list >= SLICE_MIN && list <= SLICE_MAX);
            Console.WriteLine("WHERE {0} <= UNIC RANDOM LIST <= {1}:", SLICE_MIN, SLICE_MAX);
            outList = temp.Distinct().ToList();
            outList.Sort();
            outList.Reverse();
            PrintList(outList);
        }
    }
}
