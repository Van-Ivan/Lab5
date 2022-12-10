using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Lab5
{
    internal class Program
    {
        static void Main()
        {

            //Задание 1
            string[] input = File.ReadAllLines(@"Text1.txt");
            //Regex regex1 = new Regex(@"^а$"); 
            //Regex regex2 = new Regex(@"[а]{6}");
            //Regex regex3 = new Regex(@"а\s[а]{2}\s");

            
            for (int i = 0; i < input.Length; ++i)
            {
                Console.Write(input[i]);
            
                if (new Regex(@"(^а$)|(аааааа)|(а аа а)").IsMatch(input[i])) 
                {
                    Console.Write(" - Строка подходит");
                }
                Console.WriteLine(String.Empty);
            }
            

            //Задание 2
            Console.WriteLine("\nЗадание 2");

            Console.WriteLine("Введи не менее 5 алфавитно-цифровых символов:");
            string str = Console.ReadLine();                                //Считываем с консоли текст
            Console.WriteLine(new Regex(@"[0-9a-zA-Z]{5,}").IsMatch(str)); //Выводим правильный ли он

            //Задание 3
            Console.WriteLine("\nЗадание 3");
            input = File.ReadAllLines(@"Text3.txt");
            foreach (string line in input)
            {
                Console.Write(line + " - ");
                Console.WriteLine(new Regex(@"^[a-zA-Z]\w{3,20}@[a-z]{2,10}\.[a-z]{2,5}").IsMatch(line));
            }

            //Задание 4
            Console.WriteLine("\nЗадание 4");
            //Console.OutputEncoding = Encoding.UTF8; 

            input = File.ReadAllLines(@"Text4.txt");

            var patternFor4Exs = new Regex(@"(?<city>[А-Я][а-я]+([-][А-Я][а-я]+)*)[:]\s+(?<shirota>(широта\s+)?[0-9]{1,2}(\.[0-9]+)?,?)\s(?<dolgota>(долгота\s)?[0-9]{1,2}(\.[0-9]+)?)");
            //Паттерн для поиска подходящих строк
            var city = new Regex(@"[А-Я][а-я]+([-][А-Я][а-я]+)?");
            //Паттерн для поиска названия города
            var digit = new Regex(@"[0-9]{1,2}(\.[0-9]+)?");
            //Паттерн для поиска значений широты и долготы

            foreach (string line in input)
            {
                if(patternFor4Exs.IsMatch(line))
                    Console.WriteLine(patternFor4Exs.Match(line).Groups["city"] + " Ш: " + 
                        patternFor4Exs.Match(line).Groups["shirota"] + " Д: " + 
                        patternFor4Exs.Match(line).Groups["dolgota"]);
            }
            //Задание 5
            Console.WriteLine("\nЗадание 5");

            input = File.ReadAllLines(@"Лабораторная работа 5 - testData.xml");

            Console.WriteLine("Пункт а");

            foreach (string line in input)
            {       //Ищем строки, в которых прописаны координаты, и выводим их на консоль
                if (patternFor4Exs.IsMatch(line))
                {
                    Console.WriteLine(city.Match(line) + " Ш: " + digit.Match(line) + " Д: " + digit.Match(line)); 
                }
            }

            Console.WriteLine("Пункт b,c,d");

            Regex nodeSpace = new Regex(@"\s+<node1>"); //Паттерн для поиска узлов 1 уровня
            Regex tags1 = new Regex(@"<node\d>");  //Паттерн для поиска открывающих тегов любого уровня
            Regex tags2 = new Regex(@"</node\d>"); //Паттерн для поиска закрывающих тегов любого уровня
            string buff;        //Строка для хранения изменяемой и выводимой строки
            string tag1;        //Строка для хранения открывающего тега в строке
            string tag2;        //Строка для хранения закрывающего тега в строке

            foreach (string line in input)
            {
                buff = Regex.Replace(line, @"^\d+.", String.Empty); //убираем нумерацию
                if (nodeSpace.IsMatch(buff))
                {
                    buff = Regex.Replace(buff, @"\s+<node1>", "..<node1>"); //пробелы заменяем на 2 точки (чтоб видно лучше было) в node1
                }

                //Ищем теги узлов
                tag1 = tags1.Match(line).Value;                          
                tag2 = tags2.Match(line).Value;                            
                if (tag1 != tag2)                                     //Если они не совпадают то
                    buff = Regex.Replace(buff, @"</node\d>", tag1);  //Заменяем неправильный закрывающийся тег
                Console.WriteLine(buff);
            }
        }
    }
}
