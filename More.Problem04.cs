using KGL.DEVCS.MORE.PR04;
using System;

namespace Program
{
    class Program
    {
        static void Main()
        {
            uint dimN, dimM;

            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Введите N размерность матрицы MxN:");
                } while (!uint.TryParse(Console.ReadLine(), out dimM));

                do
                {
                    Console.Clear();
                    Console.WriteLine("Введите M размерность матрицы MxN:");
                } while (!uint.TryParse(Console.ReadLine(), out dimN));

                Console.Clear();

                Matrix test = new(dimM, dimN);
                test.Fill();
                Console.WriteLine(test.ToString());
                Console.WriteLine(test.RotateCW().ToString());

                Console.WriteLine("Repeat?");

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}

namespace KGL.DEVCS.MORE.PR04
{
    public class Matrix
    {
        public int[,] MxN { get; }
        public uint SizeM { get; }
        public uint SizeN { get; }
        public Matrix()
        {
            SizeM = SizeN = 1;
            MxN = new int[SizeM, SizeN];
        }
        public Matrix(uint n, uint m)
        {
            SizeM = m;
            SizeN = n;
            MxN = new int[SizeM, SizeN];
        }
        public void Fill()
        {
            int limiter = 1000;
            System.Random rnd = new();

            if (SizeM == 1 && SizeN == 1)
            {
                MxN[0, 0] = rnd.Next(limiter);
                return;
            }

            for (uint i = 0; i < SizeM; i++)
            {
                for (uint j = 0; j < SizeN; j++)
                {
                    MxN[i, j] = rnd.Next(limiter);
                }
            }
        }
        public Matrix RotateCW()
        {
            Matrix rotated = new(SizeM, SizeN);

            for (uint i = 0; i < SizeN; i++)
            {
                for (uint j = 0; j < SizeM; j++)
                {
                    rotated.MxN[i, j] = MxN[SizeM-j-1, i]; // this
                }
            }

            return rotated;
        }
        public override string ToString()
        {
            string buff = "";

            if (SizeM == 1 && SizeN == 1) return MxN[0, 0].ToString();

            for (uint i = 0; i < SizeM; i++)
            {
                for (uint j = 0; j < SizeN; j++)
                {
                    buff += MxN[i, j].ToString().PadLeft(4);
                }
                buff += "\n";
            }
            return buff;
        }
    }
}
