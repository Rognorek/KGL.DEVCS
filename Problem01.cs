/*
Вывести название месяца по введенному номеру 
*/
using System;
using System.Globalization;

namespace KG.DEVCS.PB01
{
    class GetMonthByID
    {
        public const int MONTHSCOUNT = 12;

        static void Main(string[] args)
        {
            int i = 0;

            do
            {
                Console.WriteLine("Введите номер месяца от 1 до 12:");
                int.TryParse(Console.ReadLine(), out i);
                Console.Clear();

                if (i >= 1 && i <= MONTHSCOUNT)

                {
                    Console.Write("Для системы: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(CultureInfo.CurrentCulture.DisplayName);
                    Console.ResetColor();
                    Console.WriteLine(".");

                    Console.Write("Номеру месяца ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("{0} ", i);
                    Console.ResetColor();
                    Console.Write("соответствует название: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(CultureInfo.CurrentCulture.DateTimeFormat.MonthNames[i - 1]);
                    Console.ResetColor();
                    Console.WriteLine(".");
                }
                else
                {
                    Console.WriteLine("Неверные введеные данные. Ожидается число от 1 до 12.");
                }
                Console.Write("Press any key to continue or CTLR+C for exit.");
                Console.ReadKey();
                Console.Clear();
            } while (true);
        }
    }
}
