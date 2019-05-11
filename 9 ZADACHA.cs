using System;
using System.Collections.Generic;


public class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        List list = new List();
        bool isInt;
        bool stop = false;

        Console.WriteLine("Задание 9");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Напишите метод создания циклического списка,");
        Console.WriteLine("в информационные поля элементов которого последовательно заносятся номера с 1 до N");
        Console.ResetColor();
        Console.WriteLine("Введите элементы для заполнения списка по одному.");
        Console.WriteLine("Чтобы прекратить ввод введите не число.");
        do
        {
            Console.Write("Число: ");
            int data;
            isInt = ParseInputToInt(out data);
            if (isInt)
            {
                list.Add(data);
            }                
        } while (isInt == true);
        Console.WriteLine("Ввод окончен.");

        do
        {
            Console.WriteLine();
            Console.WriteLine("Список элементов:");
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            Console.WriteLine("Чтобы найти элемент, введите 'Найти'.");
            Console.WriteLine("Чтобы удалить элемент, введите 'Удалить'.");
            //Console.WriteLine("Чтобы добавить элементы, введите 'Добавить'");
            Console.WriteLine("Введите произвольный текст для выхода.");
            Console.Write("Команда: ");
            string str = Console.ReadLine();
            if (str == "Удалить")
            {
                Console.WriteLine("Выбрано Удаление. Напишите число для удаления.");
                Console.Write("Число: ");
                int data;
                isInt = ParseInputToInt(out data);
                if (isInt)
                {
                    list.Remove(data);
                }
            }
            else if (str == "Найти")
            {
                Console.WriteLine("Выбран Поиск. Напишите число для поиска.");
                Console.Write("Число: ");
                int data;
                isInt = ParseInputToInt(out data);
                if (isInt)
                {
                    if (list.Contains(data))
                    {
                        Console.WriteLine($"Число {data} присутствует в списке.");
                    }
                    else
                    {
                        Console.WriteLine($"Числа {data} нет в списке.");
                    }
                    
                }
            }
            //else if (str == "Добавить")
            //{
            //    Console.WriteLine("Выбрано добавление.");
            //}
            else
            {
                //Console.WriteLine("Stop is true!");
                stop = true;
            }
        } while (!stop);

        Console.WriteLine("Нажмите любую клавишу для выхода.");
        Console.ReadKey(true);
    }

    private static bool ParseInputToInt(out int data)
    {
        string input = Console.ReadLine();

        return Int32.TryParse(input, out data);
    }


}


