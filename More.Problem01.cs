/* В каждую крайнюю клетку квадратной доски поставилили по шашке.
 * Могло ли оказаться, что выставлено ровно N шашек?
 * Пример: если кол-во шашек 4, то доска размером 2 Х 2. 20 - 6 Х 6 соответственно.
 */

using System;

namespace KG.DEVCS.MORE.PR01
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                int inputCount = 0;               

                Console.Write("Введите количество шашек:");
                int.TryParse(Console.ReadLine(), out inputCount);

                if (inputCount <= 0)
                {
                    Console.WriteLine("Введите вещественное число в диапазоне 1...{0}", int.MaxValue.ToString());
                }
                else if (inputCount % 4 == 0 || inputCount == 1)
                {
                    Program.FormatOut(true, inputCount);
                }
                else
                {
                    Program.FormatOut(false, inputCount);
                }

                Console.Write("Press any key to continue or CTLR+C for exit.");
                Console.ReadKey();
                Console.Clear();

            } while (true);
        }

        private static void FormatOut(bool isSolve, int iCount)
        {
            Console.Clear();
            Console.Write("Для шашек в количестве ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0} - ", iCount);
            Console.ResetColor();
            Console.Write("доска ");
            Console.ForegroundColor = ConsoleColor.Yellow;

            if (isSolve)
            {
                Console.WriteLine("имеется");
            }
            else
            {
                Console.WriteLine("не имеется.");
            }

            Console.ResetColor();

        }
    }
}
