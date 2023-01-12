using System;
using System.Threading;

namespace Lab1PP
{
    internal class Program
    {
        public static int N;
        public static int[] a;
        public static int n;
        public static int[] returns;


        static int ThreadFunc(int param)
        {
            int i, nt, beg, h, end;
            int multiplication = 1;
            nt = param;
            h = N / n;
            beg = h * nt; 
            end = beg + h;
            if (nt == n - 1)
                end = N;
            for (i = beg; i < end; i++)
                multiplication *= a[i];
            return multiplication;

        }

        public static int СheckInput()
        {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result) || !(result > 0))
            {
                Console.Write("Ошибка. Количество потоков = ");
            }
            return result;
        }

        static void Main(string[] args)
        {
            Random random = new Random();

            Console.Write("Количество потоков = ");
            n = СheckInput();

            N = random.Next(3, 10);
            a = new int[N];

            int i;

            for (i = 0; i < a.Length; i++)
            {
                a[i] = random.Next(2,9);
            }

            for (i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }

            Console.WriteLine();

            Thread[] thread = new Thread[n];

            returns = new int[n];
            int rez = 1;

            for (i = 0; i < thread.Length; i++)
            {
                int tmp = i;
                returns[tmp] = 0;
                thread[i] = new Thread(() => {
                    returns[tmp] = ThreadFunc(tmp);
                });
                thread[i].Start();
            }

            for (i = 0; i < thread.Length; i++)
            {
                thread[i].Join();
                rez *= returns[i];
            }

            Console.WriteLine($"Произведение чисел = " + rez);
            Console.ReadLine();
        }
    }
}
