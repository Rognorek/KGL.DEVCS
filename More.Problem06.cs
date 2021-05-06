using System;
using System.Collections.Generic;

namespace KGL.DEVCS.MORE.PR06
{
    class Program
    {
        public static void Main()
        {
            do
            {
                Console.Clear();
                Proc();
                Console.WriteLine("Repeat?");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
        private static void Proc()
        {
            //List<int> listmain = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, -1 };
            //List<int> listfind = new() { 5, 6, 7, 8, 1, 2, 3, 4, 9, -2 };

            List<int> listmain = new(), listfind = new();
            InputList(listmain);
            InputList(listfind);

            //if (listfind.Count == 1 && listmain.Contains(listfind[0])) { /*todo return one*/ } else { }
            //if (listmain.Count == 1 && listfind.Contains(listmain[0])) { /*todo retrun one*/ } else { }

            PrintList(listmain, "Список 1");
            PrintList(listfind, "Список 2");
            GenSlice(listmain, listfind);
        }
        private static bool CheckByValLists(List<int> listright, List<int> listleft)
        {            
            for (int i = 0; i < listright.Count; i++)
            {
                if (listright[i] != listleft[i]) { return false; }
            }
            return true;
        }
        private static void GenSlice(List<int> main, List<int> find)
        {
            int maxlen = main.Count <= find.Count ? main.Count : find.Count;
            for (; maxlen != 0; maxlen--)
            {
                for (int i = 0; i <= main.Count - maxlen; i++)
                {
                    List<int> tmain = main.GetRange(i, maxlen);
                    
                    //Console.BackgroundColor = ConsoleColor.DarkBlue;
                    //Console.ForegroundColor= ConsoleColor.Gray;
                    //PrintList(tmain, "tmain");
                    //Console.ResetColor();

                    for (int j = 0; j <= find.Count - maxlen; j++)
                    {
                        List<int> tfind = find.GetRange(j, maxlen);
                        
                        //Console.BackgroundColor = ConsoleColor.DarkGreen;
                        //Console.ForegroundColor = ConsoleColor.Gray;
                        //PrintList(tfind, "tfind");
                        //Console.ResetColor();

                        if (CheckByValLists(tmain, tfind)) { PrintList(tmain, "Совпадение"); return; }
                    }
                }
            }
            Console.WriteLine("Совпадений нет.");
        }
        private static void InputList(List<int> list)
        {
            int counter = 1;
            int number;
            Console.Clear();
            do
            {
                Console.WriteLine("Введите {0} элемент последовательности: ", counter);
                if (int.TryParse(Console.ReadLine(), out number))
                {
                    list.Add(number);
                    counter += 1;
                    if (number < 0) break;
                }
            } while (true);
        }
        private static void PrintList(List<int> list, string name)
        {
            Console.Write("{0}: ", name);
            foreach (int item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
