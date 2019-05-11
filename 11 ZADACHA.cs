using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;

namespace ConsoleApp24
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
        static string Encryption(string text, int[] sequence, bool mod)//11 800
        {
            /*mod==true - режим шифрования, иначе дешифровка 
             обязательное требование к последовательности перестановок - наличае всех чисел между максимальным и 0*/
            try
            {
                int
                                n = text.Length,//длина входного текста
                                k = sequence.Length,//длина массива перестановок
                                d; //d возмжное количество пробелов

                if (n > k)//в случае если длина текста больше длины последовательности
                    d = k - n % k;//сколько символов остается после деления на блоки по к. если остаток не равен 0, то массив дозаполняется пробелами
                else
                    d = k - n;// в случае если длина массива перестановок больше чем длина текста

                for (int i = 0; i < d; i++)//дозаполняем текст пробелами до того как он не станет нужной длины (кратной указанной длине)
                    text += " ";
                n = text.Length;

                int c = 0;
                char[] result = new char[n];//выделяем память под результирующий массив (зашированное сообщение)
                for (int i = 0; i < n; i++)//мы переносим элементы из исходного массива в заданные места результирующего
                {
                    if (i % k == 0)
                        c = i;
                    if (mod)
                        result[i] = text[sequence[i % k] + c];
                    else
                        result[sequence[i % k] + c] = text[i];
                }
                return new string(result); // возвращает зашифрованный массив (зашифр. сообщение)
            }
            catch (Exception e)
            {
                return "ошибка";
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 11");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Необходимо разработать алгоритм, способный зашифровать слово, а после расшифровать его.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("если в последней группе меньше 4-ёх элементов, то пустые элементы заполняются пробелами");
            Console.ResetColor();
            Console.ResetColor();
            Console.WriteLine("введите количество элементов слова, необходимого для расшифровки");
            int n = (int)Сheck();//длина последовательности перестановок

            int[] sequence = new int[n];
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("введите цифры обязательно начиная с нуля до n-1 в любой последовательности (пример: 1, 2, 4, 0, 3)");
            Console.ResetColor();
            for (int i = 0; i < n; i++)
                sequence[i] = (int)Сheck();
            Console.WriteLine("введите слово необходимое для шифрования");
            var T = Encryption(Console.ReadLine(), sequence, true);// Any text,3120,true
            Console.WriteLine("зашифрованное слово ");
            Console.WriteLine(T);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("расшифровка");
            Console.ResetColor();
            Console.WriteLine(Encryption(T, sequence, false));
            Console.ReadKey();
        }
    }
}
