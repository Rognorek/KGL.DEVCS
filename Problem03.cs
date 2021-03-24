/* 
 * Дан размер массива и сам целочисленный упорядоченный по возрастанию массив.
 * Найти количество уникальных чисел в нем.
 * Пример: Дано 3; 2, 2, 2 - результат 1/ * 
 */

/* O(n) */

using System;
using System.Linq;

namespace KGL.DEVCS.PROBLEM03
{
    class Problem03
    {
        static void Main()
        {
            int sizeArrBuff;
            int[] arrBuff;

            do
            {
                //Console.Clear();
                Console.Write("Введите размер вектора:");
                if (int.TryParse(Console.ReadLine(), out sizeArrBuff))
                {
                    if (sizeArrBuff >= 2)
                    {
                        arrBuff = new int[sizeArrBuff];

                        for (int i = 0; i < sizeArrBuff; i++)
                        {
                            bool isCorrectNumber;

                            do
                            {
                                Console.Write("[{0}]\\[{1}]]Введите элемент массива:", i + 1, sizeArrBuff);
                                isCorrectNumber = int.TryParse(Console.ReadLine(), out arrBuff[i]);
                                if (!isCorrectNumber)
                                    PrintWarningMessageForElement();

                            } while (!isCorrectNumber);
                        }

                        PrintResult(CountOfUnicalValues(arrBuff));
                    }

                    else if (sizeArrBuff == 1)
                    {
                        PrintResult(sizeArrBuff);
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

        private static int CountOfUnicalValues(int[] inputArr)
        {
            inputArr = inputArr.Distinct().ToArray();
            return inputArr.Length;
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


        private static void PrintResult(int result)
        {
            Console.Clear();
            Console.WriteLine("Количество уникальных значений равно: {0}", result);
            Console.WriteLine("Для продолжения нажмите любую клавишу");
            Console.ReadKey();
        }

    }
}
