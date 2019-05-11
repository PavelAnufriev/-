using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;

namespace _6_zadacha
{
    class Program
    {
        static void Sequence(double a1, double a2, double a3, int N, double E,
int i = 0, bool flag = true)
        {
            if (flag)
            {
                if (Math.Abs(a2 - a1) > E && i <= N)
                    Console.Write($"{a1}[1] {a2}[2]");
                i += 2;
            }
            double a4 = a3 + 2 * a2 * a1;
            i++;
            if (i <= N)
            {
                if (Math.Abs(a4 - a3) > E)
                    Console.Write($" {a4}[{i + 1}] ");
                else
                    Console.Write($" {a4} ");
                Sequence(a2, a3, a4, N, E, i, false);
            }
        }

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
            Console.WriteLine("Задание 6");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ввести a1, a2, a3, N, E. Построить последовательность чисел a(k)= a(k-1) * 2 a(k-2) * a(k-3)");
            Console.WriteLine("Найти первые ее N элементов такие что |a(k) - a(k-1)| > E. Напечатать последовательность.");
            Console.ResetColor();
            double
                a1 = Сheck(false),
                a2 = Сheck(false),
                a3 = Сheck(false),
                E = Сheck();
            int n = (int)Сheck();
            Sequence(a1, a2, a3, n, E);
            Console.ReadKey();
        }
    }
}
