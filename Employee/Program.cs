using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    class Program
    {       
        static void Main(string[] args)
        {
            Array ar = new Array();
            ar.ArrayEmployee();
            
            EmployeeInput ei = new EmployeeInput();
            ei.EmployeeIn();
            
            Console.ReadLine();            
        } 
    }
}

