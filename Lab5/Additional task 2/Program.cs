using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Additional_task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"D:\github\Lab6\Адреса.txt");

            var rAddress = new Regex(@"(http | https | ftp)?(://)?(w{3})?([^-][a-z0-9_]+\.){2,5}");

            foreach (string line in input)
            {
                Console.WriteLine($"{line} {rAddress.IsMatch(line)}");
            }

        }
    }
}
