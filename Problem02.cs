/*
Вводятся по очереди 10 символов (‘С’ или ‘c’ - север, ‘Ю’, ‘В’, ‘З’ аналогично).
Начиная с координат (0:0) двигаемся по 1 метру в указанную сторону.
Какое расстояние будет между начальной и конечной позицией?
(к примеру при С с С Ю ю з З в ю з ответом будет 2)
*/
using System;

namespace KG.DEVCS.PB02
{
    class Problem02
    {
        static void Main(string[] args)
        {
            int maxbuff = 10;
            string temp = "";

            const char North = 'С';
            const char South = 'Ю';
            const char East = 'В';
            const char West = 'З';

            do
            {
                int posx = 0, posy = 0;
                bool flag = true;

                Console.Clear();
                Console.WriteLine("Введите {0} символов маршрута, состоящие из букв:С,Ю,З,В.", maxbuff);
                Console.WriteLine("Регистр букв не имеет значения.");

                Console.Write("Например:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\'СсЮюЗзВвсЮ\'");
                Console.ResetColor();

                temp = Console.ReadLine().ToUpper();
                if (temp.Length == maxbuff)
                {
                    int cursor = 0;
                    foreach (char item in temp)
                    {
                        cursor++;
                        if (item == North || item == South || item == East || item == West)
                        {
                            switch (item)
                            {
                                case North:
                                    posy++; break;

                                case East:
                                    posx++; break;

                                case South:
                                    posy--; break;

                                case West:
                                    posx--; break;
                            }
                        }
                        else
                        {
                            flag = false;
                            Console.Write("Неверные данные в позиции: ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("{0}, {1}", cursor, item);
                            Console.ResetColor();
                        }

                    }
                }
                else
                {
                    flag = false;
                    Console.Clear();
                    Console.WriteLine("Неверные вводные данные. Ожидается {0} символов.", maxbuff);
                }
                if (flag)
                {
                    Console.Clear();
                    Console.Write("Для данных: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\'{0}\'", temp);
                    Console.ResetColor();
                    Console.Write("расстояние от начала координат составляет: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write((Math.Sqrt(posx * posx + posy * posy).ToString("F3")));
                    Console.WriteLine(" м.");
                    Console.ResetColor();
                }
                Console.WriteLine("Press any key to continue or CTRL+C to exit.");
                Console.ReadKey();
            } while (true);
        }
    }
}
