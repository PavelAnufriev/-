using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Program
    {
        static int Boats(double D, List<double> M)//1 500
        {
            if (D >= 15000 && M.Count >= 15000 && !(D > 0 )&& !(M.Count > 0))
            {
                return 0;

            }
            for (int i = 0; i < M.Count; i++)
            {
                if (M[i] > D)
                {
                    return 0;
                }
            }

            int minIndex = 0, count = 0;
            while (M.Count > 0)
            {
                double min = -1;
                for (int i = 1; i < M.Count; i++)
                {
                    double d = D - M[0] - M[i];//Разница между грузоподъёмностью и суммарной массой пассажиров
                    if (d >= 0 &&
                        (d < min || min == -1))
                    {
                        min = d;
                        minIndex = i;
                    }
                }
                if (min == -1)
                {
                    M.Remove(M[0]);
                    count++;
                }
                else
                {
                    M.Remove(M[minIndex]);
                    M.Remove(M[0]);
                    count++;
                }
            }
            return count;
        }

        static string[] Read(string adress)
        {
            using (StreamReader streamReader = new StreamReader(adress, Encoding.Default))
            {
                return streamReader.ReadToEnd().
                    Split(new Char[] { ' ', ',', '.', ':', ';', '?', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        static void Write(string adress, int text)
        {
            using (StreamWriter sw = new StreamWriter(adress, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(text);
            }
        }
        static void Main(string[] args)
        {
            IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
            string
                input = @"INPUT.txt",
                output = @"OUTPUT.txt";


            try
            {
                string[] data = Read(input);

                int n = int.Parse(data[0]);
                double D = double.Parse(data[1], formatter);
                List<double> M = new List<double>();
                for (int i = 0; i < n; i++)
                    M.Add(double.Parse(data[i + 2], formatter));
                Write(output, Boats(D, M));
            }
            catch (Exception e)
            {
                Console.WriteLine("Исключение");
            }

        }
    }
}
