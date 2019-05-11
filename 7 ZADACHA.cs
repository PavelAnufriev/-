using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;

namespace _7_zadacha
{
    class Program
    {
        static string Hamming(string text, int degree = 4)//7 800
        {
            //degree - степень двойки, т е 2^degree == разряд
            for (int i = 0, j = 0; i < degree + 1; j += (int)Math.Pow(2, i), i++)
            {
                text = text.Insert(j, "0");
            }
            //Console.WriteLine(text);
            int n = text.Length;
            char[] buff = text.ToCharArray();
            for (int i = 0, N = 0; i < degree + 1; N += (int)Math.Pow(2, i), i++)
            {
                int sum = 0;
                for (int j = N; j < n; j += N + 1)
                {
                    for (int c = 0; c < N + 1; c++, j++)
                    {
                        if (j < n)
                        {
                            sum += int.Parse($"{ buff[j]}");
                        }
                        else
                            break;
                    }
                }
                buff[N] = char.Parse($"{sum % 2}");
                //Console.WriteLine(buff);
            }

            return new string(buff);
        }
        static string Hamming2(string text = "01000100001111010011111001001000", int degree = 4)
        {
            string result = "";
            char[] buff = new char[(int)Math.Pow(2, degree)];
            for (int i = 0; i < text.Length;)
            {
                for (int j = 0; j < buff.Length; j++, i++)
                {
                    if (i > text.Length - 1)
                        return "неверная степень";

                    buff[j] = text[i];
                }
                result += Hamming(new string(buff), degree);
            }

            return result;
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
            Console.WriteLine("Задание 7");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Задано содержимое информационных разрядов кодового слова кода Хэмминга");
            Console.WriteLine("Добавить контрольные разряды и заполнить их");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("пример ввода 01000100001111010011111001001000, 4");
            Console.ResetColor();
            Console.ResetColor();
            Console.WriteLine("введите число 0 и 1 не меньше 8 и более (обязательно кратно 8)");
            Console.WriteLine("а затем количество разрядов ()");
            string t = Hamming2(Console.ReadLine(), (int)Сheck()); 
            Console.WriteLine("введите количество контрольных разрядов");
            Console.WriteLine(t);
            Console.ReadKey();
        }
    }
}
