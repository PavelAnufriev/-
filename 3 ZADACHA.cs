using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;

namespace _3_ZADACHA
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
        static double Area(double x, double y)//3 250
        {
            if (y >= -x &&
                y >= x &&
                Math.Sqrt(x * x + y * y) <= 1)
            {
                //Если пара чисел принадлежит D
                Console.WriteLine("принадлежит");
                return Math.Sqrt(x * x - 1);
            }

            else
            {
                Console.WriteLine("не принадлежит");
                return x + y;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 3");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("введите координаты Х и У. программа автоматически вычислит, входит ли данная точка в заштрихованную область ");
            Console.WriteLine("и определит в какое из двух (данных в условии) выражений необходимо подставить значения х и у, чтобы решить его.");
            Console.ResetColor();
            Console.WriteLine("введите х (если число вещественное. то через запятую)");
            double x = Сheck(false);
            Console.WriteLine("введите у");
            double y = Сheck(false);
            Console.WriteLine("значение выражения");
            Console.WriteLine(Area(x, y));
        }
    }
}
