using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Collection
    {
        internal void NumberRepetitions()
        {
            var list = new List<string>();
            Random rnd = new Random();
            for (var i = 0; i < 10; i++)
                list.Add(rnd.Next(1, 5).ToString());

            var dict = new Dictionary<string, int>();
            foreach (var item in list)
            {
                if (!dict.ContainsKey(item))
                    dict.Add(item, 1);
                else
                    dict[item]++;
            }
            foreach (var point in dict)
                Console.WriteLine($"строка: {point.Key}, встречается {point.Value} раз");
            Console.WriteLine("_______________________________________");

            var result = dict.Select(r => new { Value = r.Value, Key = r.Key });
            foreach (var item in result)
                Console.WriteLine($"строка: {item.Key as string}, встречается {item.Value} раз");
        }
        
    }
}
