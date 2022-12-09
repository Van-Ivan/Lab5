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
            var rPrice = new Regex(@"\d+(\.\d)?\sруб");
            MatchCollection priceCollection = rPrice.Matches(example);
            var rWeight = new Regex(@"\d+(\.\d+)?\sкг");
            MatchCollection weightCollection = rWeight.Matches(example);
            var rProduct = new Regex(@"[а-я]+\s-");
            MatchCollection productCollection = rProduct.Matches(example);

            var rValue = new Regex(@"\d+(\.\d+)?");
            double weight;
            double priceByKg;
            for (int i = 0; i < weightCollection.Count; i++)
            {
                weight = Convert.ToDouble(rValue.Match(weightCollection[i].Value).Value, CultureInfo.InvariantCulture);
                priceByKg = Convert.ToDouble(rValue.Match(priceCollection[i].Value).Value, CultureInfo.InvariantCulture);
                if (weight != 1)
                    priceByKg = priceByKg / weight;
                Console.WriteLine($"{productCollection[i]} {priceByKg} за 1 кг");
            }
        }
    }
}
