using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    public class Array
    {
        public void ArrayEmployee()
        {
            BaseEmployee[] workers = new BaseEmployee[4];
            workers[0] = new HourlyPayment(85, 1, "Максим");
            workers[1] = new FixedPayment(10000, 2, "Сергей");
            workers[2] = new HourlyPayment(60, 1, "Юрий");
            workers[3] = new FixedPayment(25000, 2, "Светлана");
            foreach (BaseEmployee worker in workers)
            {
                worker.PaymentCalculation();
            }
        }        
    }
}


