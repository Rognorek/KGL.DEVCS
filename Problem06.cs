/*
 * Выберите 5 форматов файлов и сохраните (в коде) в коллекцию в виде короткого описания и полного названия
 *  (к примеру “.png” и “portable network graphics”).
 *  Обеспечьте добавление новых форматов,
 *  удаление по короткому описанию,
 *  вывод полного списка с обоими значениями,
 *
 *  вывод названия по короткому описанию. 
 *  В случае, если формата не существует, выдайте ошибку и перейдите к выбору действия.
 * 
 * Для этой задачи нужно создать консольное меню, которое будет выполнять действия по нажатию цифр,
 * привязанных к пунктам меню.
 */

using System;
using System.Collections.Generic;

namespace KGL.DEVCS.PROBLEM06
{
    class TerminalMenu
    {
        private static void PrintMenu()
        {
            Console.Clear();
            Console.Write("1 - Вывести список коллекции данных.\n" +
                          "2 - Добавить элемент в коллекцию данных.\n" +
                          "3 - Удалить элемент из коллекции данных.\n" +
                          "4 - Поиск элемента в коллекции данных.\n" +
                          "0 - Выход из программы.\n");

            Console.WriteLine("\n\nУправление меню ведется с помощью числового блока клавиатуры.");
        }

        private static void PressAnyKey()
        {
            Console.Write("\n\nPress any key to continue...");
            Console.ReadKey();
        }

        static void Main()
        {
            Console.Clear();
            Dictionary<string, string> myLittlePony = InitDefault();
            //Dictionary<string, string> myLittlePony = new(); //test 4 empty dic

            do
            {
                PrintMenu();
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1 or ConsoleKey.NumPad1:

                        ListAllItemsDictionary(myLittlePony);
                        goto default;

                    case ConsoleKey.D2 or ConsoleKey.NumPad2:
                        do
                        {
                            AddItemDictionary(myLittlePony);
                            Console.WriteLine("\n\nПовторить? Y for Yes, AnyKey for No");
                        } while (Console.ReadKey().Key == ConsoleKey.Y);

                        goto default;

                    case ConsoleKey.D3 or ConsoleKey.NumPad3:
                        do
                        {
                            DelItemDictionary(myLittlePony);
                            Console.WriteLine("\n\nПовторить? Y for Yes, AnyKey for No");
                        } while (Console.ReadKey().Key == ConsoleKey.Y);
                        goto default;

                    case ConsoleKey.D4 or ConsoleKey.NumPad4:
                        do
                        {
                            FindItemByKey(myLittlePony);
                            Console.WriteLine("\n\nПовторить? (Y for Yes, Anykey for No)");
                        } while (Console.ReadKey().Key == ConsoleKey.Y);

                        goto default;

                    case ConsoleKey.D0 or ConsoleKey.NumPad0:
                        return;

                    default:
                        PressAnyKey();
                        break;
                }

            } while (true);
        }

        private static Dictionary<string, string> InitDefault()
        {
            Dictionary<string, string> defaultDictionary = new Dictionary<string, string>();
            // согласно https://open-file.ru

            defaultDictionary.Add("txt", "Текстовый документ");
            defaultDictionary.Add("doc", "Документ Microsoft World");
            defaultDictionary.Add("docx", "Документ Microsoft Word Open XML");
            defaultDictionary.Add("bmp", "Точечный рисунок");
            defaultDictionary.Add("mp3", "Аудио-файл MP3");

            return defaultDictionary;
        }

        private static void AddItemDictionary(Dictionary<string, string> dic)
        {
            string dicKey, dicValue;
            Console.Clear();

            do
            {
                Console.Write("Введите тип:");
                dicKey = Console.ReadLine().Trim();
            } while (string.IsNullOrWhiteSpace(dicKey));

            do
            {
                Console.Write("Введите описание формата:");
                dicValue = Console.ReadLine().Trim();
            } while (string.IsNullOrWhiteSpace(dicValue));

            if (dic.ContainsKey(dicKey))
            {
                Console.Clear();
                Console.WriteLine("Список уже содержит {0} тип.\n" +
                                  "Элемент не будет добавлен в коллекцию данных.", dicKey);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Элемент добавлен в коллекцию данных.");
                dic.Add(dicKey, dicValue);
            }
        }

        private static void DelItemDictionary(Dictionary<string, string> dic)
        {

            string dicKey;
            Console.Clear();
            if (dic.Count != 0)
            {
                do
                {
                    Console.Write("ВОЗМОЖНЫЕ ВАРИАНТЫ: ");
                    foreach (var item in dic)
                    {
                        Console.Write("{0}, ", item.Key);
                    }

                    Console.Write("\n\nУкажите данные для удаления, ожидается значение тип формата файла:");
                    dicKey = Console.ReadLine().Trim();
                } while (string.IsNullOrWhiteSpace(dicKey));

                if (dic.ContainsKey(dicKey))
                {
                    Console.Clear();
                    Console.WriteLine("Элемент коллекции данных {0} - {1} удален из коллекции.", dicKey, dic[dicKey]);
                    dic.Remove(dicKey);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Данный элемент не найден в коллекции данных.");
                }
            }
            else
            {
                Console.WriteLine("Коллекция данных пуста, удаление невозможно.");
            }
        }

        private static void ListAllItemsDictionary(Dictionary<string, string> dic)
        {
            Console.Clear();

            if (dic.Count != 0)
            {

                Console.WriteLine("ТИП - ОПИСАНИЕ ФОРМАТА");
                foreach (var item in dic)
                {
                    // todo поставить счетчик строк и на каждую 20 делать паузу                
                    Console.WriteLine("{0} - {1}", item.Key, item.Value);
                }
            }
            else
            {
                Console.WriteLine("Коллекция данных пуста, печать невозможна.");
            }
        }

        private static void FindItemByKey(Dictionary<string, string> dic)
        {
            string dicKey;
            Console.Clear();

            if (dic.Count != 0)
            {
                do
                {
                    Console.Write("ВОЗМОЖНЫЕ ВАРИАНТЫ: ");
                    foreach (var item in dic)
                    {
                        Console.Write("{0}, ", item.Key);
                    }

                    Console.Write("\n\nУкажите данные для поиска, ожидается значение тип формата файла:");
                    dicKey = Console.ReadLine().Trim();
                } while (string.IsNullOrWhiteSpace(dicKey));

                if (dic.ContainsKey(dicKey))
                {
                    Console.Clear();
                    Console.WriteLine(dic[dicKey]);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Данный элемент не найден в коллекции данных.");
                }
            }
            else
            {
                Console.WriteLine("Коллекция данных пуста, поиск невозможен.");
            }
        }
    }
}
