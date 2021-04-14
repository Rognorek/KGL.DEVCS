using System;

namespace IPv4Check
{
    class IPv4Check
    {
        const int MAX_OCTETS = 4;
        const char DELIMETR_OCTET = '.';
        enum Answer : int
        {
            No = 0,
            Yes = 1
        }
        private static void Main()
        {
            do
            {
                Console.Clear();
                string userInputString = InputString();

                if (IsIPv4(userInputString))
                {
                    PrintResult(Answer.Yes);
                }
                else
                {
                    PrintResult(Answer.No);
                }
                Console.Write("Repeat?(Y/N)");
            } while (Console.ReadKey().Key == ConsoleKey.Y);
        }

        private static string InputString()
        {
            string consoleInput;

            do
            {
                Console.Write("Input IPv4 addres:");
                consoleInput = Console.ReadLine().Trim();
            } while (string.IsNullOrEmpty(consoleInput));

            return consoleInput;
        }
        private static void PrintResult(Answer answer)
        {
            Console.WriteLine("{0}", answer == Answer.No ? "No" : "Yes");
        }

        private static bool IsIPv4(string addres)
        {

            string[] groups = addres.Split(DELIMETR_OCTET);
            byte[] octets = new byte[MAX_OCTETS];

            if (addres.Length < 7 || addres.Length > 15)
            {
                return false;
            }

            if (groups.Length != MAX_OCTETS)
            {
                return false;
            }

            foreach (string item in groups)
            {
                if (item.Length == 0 || item.Length > 3 || item != item.Trim())
                {
                    return false;
                }
            }

            for (int i = 0; i < MAX_OCTETS; i++)
            {
                if (!byte.TryParse(groups[i], out octets[i]))
                {
                    return false;
                }
            }

            foreach (byte item in octets)
            {
                Console.Write("{0}.", item);
            }
            return true;
        }
    }
}
