using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
namespace ConsoleApp21
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
        static double Sum(double E)//4 250
        {
            int i = 1; //счётчик элементов
            double s = 0; //сумма
            while (Math.Pow(i * (i + 1), -1) > E)// До тех пор пока текущий член прогрессии превосходит Е
            {
                s += Math.Pow(i * (i + 1), -1);
                i++;
            }
            return s;
        }
        static void Main(string[] args)
        {
            
            Console.WriteLine("Задание 4");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Вычислить бесконечную сумму с заданной точностью");
            Console.WriteLine("если епсилон будет больше i-ого члена, то алгоритм завершает работу, тк в заданиий указано рассчитать сумму с точностью до епсилона");
            Console.WriteLine("(0 < Е < 0,5)");
            Console.ResetColor();
            Console.WriteLine("Укажите необходимую точность (введите Е)");
            double x = Сheck();
            Console.Write("сумма = ");
            Console.WriteLine(Sum(x));
            Console.ReadKey();
        }
    }
}
