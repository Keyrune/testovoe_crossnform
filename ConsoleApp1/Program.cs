using System;
using System.Diagnostics;
// using System.Threading;
using System.Collections.Generic;
// using System.Collections;
using System.Linq;
// using System.Text;
// using System.Threading.Tasks;


namespace ConsoleApp1
{
    class Program
    {


        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();


            Console.WriteLine("Введите путь к текстовому файлу:"); // C:\Users\Keyrune\Desktop\testtext.txt
            string adress1 = Console.ReadLine();
            string text = System.IO.File.ReadAllText(adress1, System.Text.Encoding.GetEncoding(1251));
            char[] a = text.ToCharArray();
            Dictionary<string, int> triplet = new Dictionary<string, int>();
            string str;

            // пройти весь текст и посчитать все триплеты с помощью словаря
            for (int i = 0; i < a.Length - 3; i++)
            {
                if (char.IsLetter(a[i]) & char.IsLetter(a[i + 1]) & char.IsLetter(a[i + 2]))
                {
                    str = Char.ToString(a[i]) + Char.ToString(a[i + 1]) + Char.ToString(a[i + 2]);

                    // если нет такого в словаре, создать со значением 0
                    // если есть увеличить на 1
                    if (!triplet.ContainsKey(str))
                    {
                        triplet.Add(str, 0);
                    }
                    else
                    {
                        triplet[str]++;
                    }
                };

            }


            // пройти весь словарь и вернуть 10 самых часто встречаемых триплетов
            var sortedDict = (from entry in triplet orderby entry.Value descending select entry).ToDictionary(pair => pair.Key, pair => pair.Value).Take(10);

            Console.WriteLine();
            Console.WriteLine("Всего найдено {0} не повторяющихся триплетов.", triplet.Count);
            foreach (var pair in sortedDict)
            {
                Console.WriteLine($"{pair.Key}  {pair.Value}");
            }
            Console.WriteLine();


            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00} часов, {1:00} минут, {2:00} секунд, {3:000} миллисекунд",
                        ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            Console.WriteLine("Время выполнения программы: " + elapsedTime);

            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для выхода из программы");
            Console.ReadKey();
        }
    }
}
