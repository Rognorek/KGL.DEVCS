using System;
using System.Collections.Generic;

namespace KGL.DEVCS.MORE.PR05
{
    class Program
    {
        static void Main()
        {
            do
            {
                Console.Clear();
                Proc();
                Console.WriteLine("Repeat?");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
        static void Proc()
        {
            int usernumber, counter = 1;
            List<int> userlist = new();

            do
            {
                Console.WriteLine("Введите {0} элемент последовательности: ", counter);
                if (int.TryParse(Console.ReadLine(), out usernumber))
                {
                    userlist.Add(usernumber);
                    counter += 1;
                    if (usernumber < 0) break;
                }
            } while (true);

            Console.Clear();
            Console.WriteLine("Для списка: ");
            foreach (int item in userlist)
            {
                Console.Write(item + " ");
            }

            counter = 0;
            if (userlist.Count > 2)
            {
                for (int i = 1; i < userlist.Count - 1; i++)
                {
                    if (userlist[i - 1] < userlist[i] && userlist[i + 1] < userlist[i]) counter++;
                }
            }
            Console.WriteLine("Ответ: {0}", counter);
        }
    }
}
