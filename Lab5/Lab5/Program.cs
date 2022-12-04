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
            
            string[] input = File.ReadAllLines(@"D:\github\Lab5\Text1.txt"); //чтение массива строк
            Regex regex1 = new Regex(@"а");

            for (int i = 0; i < input.Length; ++i)
            {
                Console.WriteLine(input[i]);
                
                Console.WriteLine(regex1.IsMatch(input[i]));
                Console.WriteLine();
            }
            
        }
    }
}
