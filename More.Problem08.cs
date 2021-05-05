using System;

namespace Program
{
    public static class Program
    {
        public static void Main()
        {
            do
            {
                uint usernumber;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Введите целое положительное число n, которое задаст матрицу размером 2n+1: ");
                } while (!uint.TryParse(Console.ReadLine(), out usernumber));

                Matrix.SquareCoil test = new(usernumber);
                Console.WriteLine(test.ToString());

                Console.WriteLine("Esc - Exit. Anykey to repeat.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}

namespace Matrix
{
    public class SquareCoil
    {
        public uint Size { get; }
        public uint[,] Matrix { get; }

        private uint StartIndex { get; }

        public SquareCoil(uint size)
        {
            Size = size * 2 + 1;
            StartIndex = size;
            Matrix = new uint[Size, Size];
            Fill();
        }
        private enum NavCCW { Up, Left, Down, Right }
        private void Fill()
        {
            NavCCW cur = NavCCW.Up;
            uint number = 0, x = 0, y = 0, iteractionsize = 1;

            x = y = StartIndex;
            Matrix[x, y] = number++;

            do
            {
                switch (cur)
                {
                    case NavCCW.Up:
                        for (int i = 0; i < iteractionsize; i++)
                        {
                            if (number == (Size * Size)) break;
                            x--;
                            Matrix[x, y] = number++;
                        }

                        goto default;

                    case NavCCW.Left:
                        for (int i = 0; i < iteractionsize; i++)
                        {
                            y--;
                            Matrix[x, y] = number++;
                        }

                        iteractionsize++;
                        goto default;

                    case NavCCW.Down:
                        for (int i = 0; i < iteractionsize; i++)
                        {
                            x++;
                            Matrix[x, y] = number++;
                        }

                        goto default;

                    case NavCCW.Right:
                        for (int i = 0; i < iteractionsize; i++)
                        {
                            y++;
                            Matrix[x, y] = number++;
                        }

                        iteractionsize++;
                        goto default;

                    default:

                        if (cur == NavCCW.Right)
                        {
                            cur = NavCCW.Up;
                        }
                        else
                        {
                            cur += 1;
                        }

                        break;
                }
            } while (number < (Size * Size) - 1);
        }
        public override string ToString()
        {
            if (Size == 1) return Matrix[0, 0].ToString();

            int maxlen = 1 + (Size * Size).ToString().Length;
            uint pos = 0;
            string buff = "";

            foreach (uint item in Matrix)
            {
                if (pos % (Size - 1) == 0 && pos != 0)
                {
                    buff += item.ToString().PadLeft(maxlen) + "\n";
                    pos = 0;
                }
                else
                {
                    buff += item.ToString().PadLeft(maxlen);
                    pos++;
                }
            }

            return buff;
        }
    }
}
