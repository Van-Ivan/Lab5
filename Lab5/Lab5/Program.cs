using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lab5
{
    internal class Program
    {
        static void Main()
        {
            //Задание 1
            string[] input = File.ReadAllLines(@"D:\github\Lab5\Text1.txt"); //чтение массива строк
            Regex regex1 = new Regex(@"^а$"); 
            Regex regex2 = new Regex(@"[а]{6}");
            Regex regex3 = new Regex(@"а\s[а]{2}\s");
            Regex regex4 = new Regex(@"[а\s[а]{2}\s^а$[а]{6}]");

            
            for (int i = 0; i < input.Length; ++i)
            {
                Console.Write(input[i]);
            
                if (regex1.IsMatch(input[i]) || regex2.IsMatch(input[i]) || regex3.IsMatch(input[i])) //если строка подходит под любой паттерн
                {
                    Console.Write(" - Строка подходит");
                }
                Console.WriteLine();
            }
            

            //Задание 2
            Console.WriteLine("Задание 2");
            string str = Console.ReadLine();
            Console.WriteLine(new Regex(@"[0-9a-zA-Z]{5,}").IsMatch(str));
        }
    }
}
