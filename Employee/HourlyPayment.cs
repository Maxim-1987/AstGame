using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
     public class HourlyPayment : BaseEmployee
    {
        private const double daysMonth = 20.8;
        private const int workingHours = 8;
        private const int rate = 80;

        public HourlyPayment(int rate, int id, string name)
            : base(rate,  id,  name)
        {

        }
        public override void PaymentCalculation()
        {
            _MonthlyPayment = (double)(daysMonth * workingHours * rate);
            Console.WriteLine(_Name + "|" + "<Id>" + _Id + "|" + "Ваша среднемесячная зарплата составляет: " + _MonthlyPayment);
        }
        
    }
}
