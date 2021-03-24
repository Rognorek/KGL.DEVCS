/* 
 * Дан размер квадратной матрицы (двумерного массива) и сама матрица.
 * Вывести, симметрична ли матрица относительно главной диагонали?
 * Пример: 2 0 1 1 0 То да 
 */

/* O(n^2) */

using System;

namespace KGL.DEVCS.PROBLEM04
{
    class Problem04
    {
        static void Main()
        {
            int sizeArrBuff;
            int[,] arrBuff;

            do
            {
                //Console.Clear();
                Console.Write("Введите размер квадратной матрицы:");
                if (int.TryParse(Console.ReadLine(), out sizeArrBuff))
                {
                    if (sizeArrBuff >= 2)
                    {
                        arrBuff = new int[sizeArrBuff, sizeArrBuff];

                        for (int i = 0; i < sizeArrBuff; i++)
                        {
                            for (int j = 0; j < sizeArrBuff; j++)
                            {
                                bool isCorrectNumber;

                                do
                                {
                                    Console.Write("[{0}]\\[{1}]]Введите элемент массива:", i + 1, j + 1);
                                    isCorrectNumber = int.TryParse(Console.ReadLine(), out arrBuff[i, j]);
                                    if (!isCorrectNumber)
                                        PrintWarningMessageForElement();

                                } while (!isCorrectNumber);
                            }
                        }

                        IsMainDiagMirrowed(arrBuff, sizeArrBuff);
                    }

                    else if (sizeArrBuff == 1)
                    {
                        PrintResult("Да");
                    }

                    else if (sizeArrBuff <= 0)
                    {
                        PrintWarningMessage();
                    }

                }
                else
                {
                    PrintWarningMessage();
                }

            } while (true);
        }

        private static void IsMainDiagMirrowed(int[,] arr, int sizearr)
        {
            for (int i = 0; i < sizearr; i++)
            {
                for (int j = 0; j < sizearr; j++)
                {
                    if (i == j)
                        continue;
                    if (arr[i, j] != arr[j, i])
                    {
                        PrintResult("Нет");
                        return;
                    }
                }
            }
            PrintResult("Да");
        }
        private static void PrintWarningMessage()
        {
            Console.WriteLine("Неверный ввод, ожидается число в диапазоне 1...{0}." +
                                "\n Для выхода их программы нажмите CTRL+C", int.MaxValue.ToString());
        }

        private static void PrintWarningMessageForElement()
        {
            Console.WriteLine("Неверный ввод, ожидается число." +
                                "\n Для выхода их программы нажмите CTRL+C");
        }


        private static void PrintResult(string result)
        {
            Console.Clear();
            Console.WriteLine("{0}", result);
            Console.WriteLine("Для продолжения нажмите любую клавишу");
            Console.ReadKey();
        }

    }
}
