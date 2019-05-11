using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;

namespace ConsoleApp23
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
        static int[,] testCycle(int v, int e)
        {
            Random rand = new Random();
            int[,] M = new int[e, v];
            for (int i = 0; i < e; i++)
            {
                for (int j = 0; j < v; j++)
                    M[i, j] = 0;

                bool flag = true;
                int j2, j1 = rand.Next(0, v);
                j2 = j1;

                while (j2 == j1)
                    j2 = rand.Next(0, v);
                M[i, j1] = M[i, j2] = 1;
            }

            int[,] result = new int[v, e];
            for (int i = 0; i < v; i++)
                for (int j = 0; j < e; j++)
                    result[i, j] = M[j, i];

            for (int i = 0; i < v; i++)
            {
                for (int j = 0; j < e; j++)
                {
                    Console.Write($" {result[i, j]}[{i},{j}] ");
                }
                Console.WriteLine();
            }
            return result;
        }
        static bool Cycle(int[,] M, int v/*i*/, int e/*j*/, int k,
           List<int> way, int I = 0, int J = -1)//8 900
        {
            way.Add(I);
            for (int j = 0; j < e; j++)
            {
                if (M[I, j] != 0 && J != j)
                {
                    for (int i = 0; i < v; i++)
                    {
                        if (M[i, j] != 0)
                            if (i != I && (!way.Contains(i)))
                            {
                                if (Cycle(M, v, e, k, way, i, j))
                                {
                                    return true;
                                }
                            }
                            else if (i != I && way.Contains(i))
                            {
                                if (way.Count - way.IndexOf(i) == k)
                                {
                                    return true;
                                }
                            }
                    }
                }
            }
            way.Remove(way[way.Count - 1]);
            return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 8");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Граф задан матрицей инцинденций");
            Console.WriteLine("Необходимо найти в нем какой либо просто цикл из К вершин");
            Console.ResetColor();
            Console.WriteLine("введите кол-во вершин, ребер и кол-во вершин в цикле поочередно");
            int v = (int)Сheck(),
                e = (int)Сheck(),
                k = (int)Сheck();
            var R = testCycle(v, e);
            bool flag = false;
            for (int i = 0; i < v; i++)
                if (Cycle(R, v, e, k, new List<int>(), i))
                    flag = true;
            if (flag)
            {
                Console.WriteLine($"граф содержит цикл из {k} вершин");
            }
            else
            {
                Console.WriteLine($"граф не содержит цикл из {k} вершин");
            }
            Console.ReadKey();
       
        }
    }
}
