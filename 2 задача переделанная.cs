using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace _2_task
{
    class Program
    {


        static double[,] Floyd(double[,] d)//2 300
        {
            int INF = 100000000, n = (int)Math.Sqrt(d.Length);
            if(!(1<=n&&n<=100))
                return null;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Math.Abs(d[i, j]) <= 100)
                        return null;
                }
            }
            for (int k = 0; k < n; ++k)
                for (int i = 0; i < n; ++i)
                    for (int j = 0; j < n; ++j)
                        if (d[i, k] < INF && d[k, j] < INF)
                            if (d[i, j] > d[i, k] + d[k, j])
                            {
                                d[i, j] = d[i, k] + d[k, j];
                            }
            return d;
        }

        static string[] Read(string adress)
        {
            using (StreamReader streamReader = new StreamReader(adress, Encoding.Default))
            {
                return streamReader.ReadToEnd().
                    Split(new Char[] { ' ', ',', '.', ':', ';', '?', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        static void Write(string adress, double[,] M)
        {
            int n = (int)Math.Sqrt(M.Length);
            using (StreamWriter sw = new StreamWriter(adress, false, System.Text.Encoding.Default))
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        sw.Write($"{M[i, j]} ");
                    }
                    sw.WriteLine();
                }
            }
        }
        static void Main(string[] args)
        {
            IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
            string
                input = @"INPUT.TXT",
                output = @"OUTPUT.TXT";


            try
            {
                string[] data = Read(input);
                int n = int.Parse(data[0]),
                    c = 1;
                double[,] M = new double[n, n];

                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                    {
                        M[i, j] = double.Parse(data[c], formatter);
                        c++;
                    }

                Write(output, Floyd(M));
            }
            catch (Exception)
            {
                Console.WriteLine("Исключение");
            }

        }

    }

}


