using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Additional_task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string example = "Добро пожаловать в наш магазин, вот наши цены:" +
                             " 1 кг. яблоки - 90 руб., 2 кг. апельсины - 130 руб. " +
                             "Также в ассортименте орехи в следующей фасовке: 0.5 кг. миндаль - 500 руб.";

            var regex = new Regex(@"(?<product>[а-я]+\s-).(?<price>\d+(\.\d)?\sруб).(?<weight>\d+(\.\d+)?\sкг)");
            MatchCollection collection = regex.Matches(example);

            double weight;
            double priceByKg;

            foreach (Match match in collection)
            {
                weight = Convert.ToDouble(match.Groups["weight"]);
                priceByKg = Convert.ToDouble(match.Groups["price"]);
                if (weight != 1)
                    priceByKg = priceByKg / weight;
            }

                foreach (Match match in collection)
            {
                Console.WriteLine($" цена {match.Groups["product"]} за 1 кг = ");
            }
        }
    }
}
