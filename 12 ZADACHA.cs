using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
namespace ConsoleApp25
{
    class Program
    {
        class Sort //12 500
        {
            public int[] M;
            public int
                comparisonRange,
                comparisonHoar,
                reversionRange,
                reversionHoar;
            public Sort()
            {
                comparisonRange =
                comparisonHoar =
                reversionRange =
                reversionHoar =
                0;
            }

            void Range(int[] arr, int range, int length)
            {
                ArrayList[] lists = new ArrayList[range];
                for (int i = 0; i < range; ++i)
                    lists[i] = new ArrayList();

                for (int step = 0; step < length; ++step)
                {
                    //распределение по спискам
                    for (int i = 0; i < arr.Length; ++i)
                    {
                        int temp = (arr[i] % (int)Math.Pow(range, step + 1)) /
                        (int)Math.Pow(range, step);
                        lists[temp].Add(arr[i]);
                        reversionRange++;
                    }
                    //сборка
                    int k = 0;
                    for (int i = 0; i < range; ++i)
                    {
                        for (int j = 0; j < lists[i].Count; ++j)
                        {
                            arr[k++] = (int)lists[i][j];
                            reversionRange++;
                        }
                    }
                    for (int i = 0; i < range; ++i)
                        lists[i].Clear();
                }
            }
            void Hoar(int[] a, int first, int last)
            {

                int i = first, j = last;
                int tmp, x = a[(first + last) / 2];

                do
                {
                    while (a[i] < x)//считаем каждое  сравнение
                    {
                        i++;
                        comparisonHoar++;
                    }
                    while (a[j] > x)
                    {
                        j--;
                        comparisonHoar++;
                    }

                    if (i <= j)
                    {
                        if (i < j)
                        {
                            reversionHoar++;//количество перестановок при каждой инверсии
                            tmp = a[i];
                            a[i] = a[j];
                            a[j] = tmp;
                        }
                        i++;
                        j--;
                    }
                } while (i <= j);

                if (i < last)
                    Hoar(a, i, last);
                if (first < j)
                    Hoar(a, first, j);
            }
            void testRand(int n, int min, int max)
            {
                M = new int[n];
                Random rand = new Random();
                for (int i = 0; i < n; i++)
                    M[i] = rand.Next(min, max);
            }
            void testIncrease(int n)
            {
                for (int i = 0; i < n; i++)
                    M[i] = i;
            }
            void testDescending(int n)
            {
                int count = n;
                for (int i = 0; i < n; i++)
                {
                    M[i] = count;
                    count--;
                }
            }
            public void test(int n)
            {
                comparisonRange =
               comparisonHoar =
               reversionRange =
               reversionHoar =
               0;

                testRand(n, 0, 100);
                Hoar(M, 0, M.Length - 1);
                Range(M, 3, 10);
                Console.WriteLine($"тест рандомными числами    быстрая сортировка | поразрядная сортировка");
                Console.WriteLine($"количество перестановок :{reversionHoar} {reversionRange}");
                Console.WriteLine($"количество сравнений:{comparisonHoar} {comparisonRange}");

                comparisonRange =
               comparisonHoar =
               reversionRange =
               reversionHoar =
               0;

                testIncrease(n);
                Hoar(M, 0, M.Length - 1);
                Range(M, 3, 10);
                Console.WriteLine($"тест возрастающей последовательности быстрая сортировка | поразрядная сортировка");
                Console.WriteLine($"количество перестановок :{reversionHoar} {reversionRange}");
                Console.WriteLine($"количество сравнений:{comparisonHoar} {comparisonRange}");

                comparisonRange =
               comparisonHoar =
               reversionRange =
               reversionHoar =
               0;

                testDescending(n);
                Hoar(M, 0, M.Length - 1);
                Range(M, 3, 10);
                Console.WriteLine($"тест возрастающей последовательности быстрая сортировка | поразрядная сортировка");
                Console.WriteLine($"количество перестановок:{reversionHoar} {reversionRange}");
                Console.WriteLine($"количество сравнений:{comparisonHoar} {comparisonRange}");
            }
        };
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
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 12");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("выполнить сравнение двух методов сортировки (поразрядная сортировка, быстрая сортировка)");
            Console.WriteLine("необходимо реализовать счетчик количества сравнений и пересылок (т.е. перемещений элементов)");
            Console.ResetColor();
            Console.WriteLine("введите количество элементов в массиве, который необходимо отсортировать");
            Sort S = new Sort();
            S.test((int)Сheck());
            Console.ReadKey();
        }
    }
}
