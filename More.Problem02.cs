using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KG.DEVCS.MORE.PR02
{
    internal static class Program
    {
        private static List<string> MY_DATA = new();
        private static void MyHandler(object sender, ConsoleCancelEventArgs args)
        {
            string buff = "";
            Console.WriteLine("Save and exit.");
            foreach (string item in MY_DATA)
            {
                buff += item.ToString();
            }
            Environment.Exit(SaveToHtml(buff));
        }
        private static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //Console.WriteLine("CP = {0}", Console.OutputEncoding.CodePage);
            Console.Title = "Press Ctrl+C to exit...";

            string result = "";
            string console_buff = "";
            string welcome = "Введите число: ";
            uint usernumber = 0;
            int x, y;

            Console.CancelKeyPress += new ConsoleCancelEventHandler(MyHandler);
            do
            {
                do
                {
                    Console.Write(welcome);
                    x = Console.GetCursorPosition().Left;
                    y = Console.GetCursorPosition().Top;
                    console_buff = Console.ReadLine();
                } while (!uint.TryParse(console_buff, out usernumber));

                if (usernumber != 0)
                {
                    ClearUserStaff(x, y, console_buff.Length);
                    result = ArabicNumberToRome(usernumber.ToString());
                    Console.WriteLine($"{usernumber} = {result}");
                    MY_DATA.Add($"<div>{usernumber} = {result}</div>");
                }
                else
                {
                    ClearUserStaff(x, y, console_buff.Length);
                    result = "";
                    Console.WriteLine($"{usernumber} - недопустимый ввод.");
                }
            } while (true);
        }
        private static string ArabicNumberToRome(string str_number)
        {
            char symbol = '\u0305';

            Dictionary<int, string> minors = new()
            {
                { 0, "V" },         //     5
                { 1, "L" },         //    50
                { 2, "D" },         //   500
                { 3, "V" + symbol } //  5000
            };

            Dictionary<int, string> majors = new()
            {
                { 0, "I" },         //     1
                { 1, "X" },         //    10
                { 2, "C" },         //   100
                { 3, "M" },         //  1000                
            };

            string result = "";
            int digit = str_number.Length;

            ExpandDic(minors, symbol, digit + 1);
            ExpandDic(majors, symbol, digit + 1);

            str_number = new(str_number.Reverse().ToArray());
            for (int pos = 0; pos < digit; pos++)
            {
                int number = int.Parse(str_number[pos].ToString());
                switch (number)
                {
                    case 0:
                        continue;

                    case 1:
                        result = majors[pos] + result;
                        break;

                    case 2:
                        result = majors[pos] + majors[pos] + result;
                        break;

                    case 3:
                        result = majors[pos] + majors[pos] + majors[pos] + result;
                        break;

                    case 4:
                        result = majors[pos] + minors[pos] + result;
                        break;

                    case 5:
                        result = minors[pos] + result;
                        break;

                    case 6:
                        result = minors[pos] + majors[pos] + result;
                        break;

                    case 7:
                        result = minors[pos] + majors[pos] + majors[pos] + result;
                        break;

                    case 8:
                        result = minors[pos] + majors[pos] + majors[pos] + majors[pos] + result;
                        break;

                    case 9:
                        result = majors[pos] + majors[pos + 1] + result;
                        break;
                }
            }
            return result;
        }
        private static void ExpandDic(Dictionary<int, string> dic, char symbol, int max_digit)
        {
            int delta = max_digit - dic.Count;

            if (delta > 0)
            {
                for (int i = 0; i < delta; i++)
                {
                    dic.Add(dic.Last().Key + 1, dic[(dic.Last().Key - 2)] + symbol);
                }
            }
            else return;
        }
        private static void ClearUserStaff(int x, int y, int count)
        {
            try
            {
                Console.SetCursorPosition(x, y);
                Console.Write(new string(' ', count));
                Console.SetCursorPosition(x, y);
            }
            catch (Exception)
            {
                if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                {
                    Console.WindowHeight = 30;
                    Console.WindowWidth = 80;
                }
                Console.Clear();
            }
        }
        private static int SaveToHtml(string datastring)
        {
            string app_path = Environment.CurrentDirectory + "\\Out.html";

            string header = "<html><head><style>" +
                                            "div{color:black;" +
                                            "background:rgb(210,210,180);" +
                                            "font-family:Tahoma;" +
                                            "font-size:3em;" +
                                            "margin:0.5em;" +
                                            "padding:0.5em;}" +
                                        "</style></head>" +
                                        "<body style=\"background: rgb(210,180,150);\">";
            string footer = "</body></html>";
            
            try
            {
                if (File.Exists(app_path)) { File.Delete(app_path); }
                File.WriteAllText(app_path, header + datastring + footer, System.Text.Encoding.UTF8);
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return e.HResult;
            }
        }
    }
}