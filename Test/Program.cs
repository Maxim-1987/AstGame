using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        private static Lambda __Lambda = new Lambda();
        private static Collection __Collection = new Collection();

        static void Main(string[] args)
        {                        
            __Lambda.MethodLambda();
            Console.WriteLine("_______________________________________");
            __Collection.NumberRepetitions();
            
            Console.ReadLine();
        }
    }
}
