using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;

namespace ConsoleApp22
{
    class Program
    {
        static double Сheck(bool mod = true, double inf = 1000)//проверка ввода числа ?????
        {
            double to = 0;
            bool flag = true;
            IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };

            while (flag)
            {
                try
                {
                    string from = Console.ReadLine();
                    to = Double.Parse(from.Replace(',', '.'), CultureInfo.InvariantCulture);
                    flag = false;
                    if (to < 0 && mod)
                    {
                        flag = true;
                    }
                }
                catch (Exception e)

                {

                    Console.WriteLine("ошибка ввода. введите число (цифру)");
                }
                if (to > inf)
                {
                    flag = true;
                    Console.WriteLine("число больше заданного диапазона");
                }

            }
            return to;

        }
        static void PrintMatrix(double[,] M)
        {
            int n = (int)Math.Sqrt(M.Length);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{M[i, j]}\t");
                }
                Console.WriteLine('\n');
            }
        }
        static double Max(double[,] M)//5 400
        {
            double min = M[0, 0];
            int n = (int)Math.Sqrt(M.Length);
            for (int i = 0; i < n; i++)
            {
                if (i < n * 0.5)
                    for (int j = i; j < n - i; j++)
                    {
                        if (min < M[i, j])
                        {
                            min = M[i, j];
                        }
                    }
                else
                    for (int j = n - i - 1; j < i + 1; j++)
                    {
                        if (min < M[i, j])
                        {
                            min = M[i, j];
                        }
                    }
            }
            return min;
        }
        static double[,] testMin(int n)//заполняет
        {
            Random rand = new Random();

            double[,] M = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int g = 0; g < n; g++)
                {

                    M[i, g] = rand.Next(-20, 50);
                }
            }
            return M;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 5");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Дана действительная квадратная матрица порядка n. Необходимо найти наибольшее значение ");
            Console.WriteLine("из заштрихованной области матрицы");
            Console.ResetColor();
            Console.WriteLine("введите размерность матрицы");
            int n = (int)Сheck();
            double[,] N = testMin(n);//заполнененная матрица
            PrintMatrix(N);
            Console.WriteLine("максимальный элемент матрицы в указанном диапазоне =");
            Console.WriteLine(Max(N));
            Console.ReadKey();
        }
    }
}
