/* 
 * Дано время отведенное на исполнение очереди FIFO,
 * длина очереди и квант времени каждого элемента.
 * Сколько элементов не будут обработаны?
 * Если осталась хотя бы 1 свободная минута - берем задачу из очереди.
 * Пример: 60 10 5 5 10 15 15 9 15 5 8 20. Ответ: 3.
 */

using System;
using System.Collections.Generic;

namespace KGL.DEVCS.PROBLEM05
{

    class PostStationEmulator
    {

        public static void Main()
        {
            do
            {
                Console.Clear();
                Emulate();

                Console.WriteLine("Press \'Y\'-key - to repeat.");

                if (Console.ReadKey().Key != ConsoleKey.Y)
                {
                    break;
                }
            } while (true);
        }
        private static void Emulate()
        {
            int timeAllJob = InitPostStation();
            Queue<int> queueJobs = new Queue<int>();
            int countJobs = InitQueueSize();

            for (int i = 0; i < countJobs; i++)
            {
                queueJobs.Enqueue(InitJob(i + 1, countJobs));
            }

            while (queueJobs.Count >= 1)
            {
                timeAllJob -= queueJobs.Peek();
                queueJobs.Dequeue();
                if (timeAllJob <= 0)
                {
                    break;
                }
            }

            if (queueJobs.Count == 0)
            {
                Console.WriteLine("Все клиенты остались довольны. Очередь пуста.");
            }
            else
            {
                Console.WriteLine("{0} клиент(а)(ов) остались недовольны.", queueJobs.Count);
            }
        }

        private static int InitPostStation()
        {
            int number;
            Console.Clear();
            do
            {
                Console.Write("Принимаются значения от 1 до {0}." +
                            "\nВведите время работы почтового отделения в минутах: ", int.MaxValue);
                number = InputAboveZeroNumber();

            } while (number == 0);

            return number;
        }

        private static int InitQueueSize()
        {
            int number;
            Console.Clear();
            do
            {
                Console.Write("Принимаются значения от 1 до {0}." +
                            "\nВведите длину очереди: ", int.MaxValue);
                number = InputAboveZeroNumber();

            } while (number == 0);

            return number;
        }

        private static int InitJob(int position, int lenQueue)
        {
            int number;
            Console.Clear();
            do
            {
                Console.Write("Принимаются значения от 1 до {0}." +
                        "\nВведите время обслуживания клиента {1} из {2} в минутах: ", int.MaxValue, position, lenQueue);
                number = InputAboveZeroNumber();
            } while (number == 0);

            return number;
        }

        private static int InputAboveZeroNumber()
        {
            int number;
            if (int.TryParse(Console.ReadLine(), out number) && number > 0)
            {
                return number;
            }
            else
            {
                return 0;
            }
        }
    }
}
