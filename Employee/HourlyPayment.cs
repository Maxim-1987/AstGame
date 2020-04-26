using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
      class HourlyPayment : BaseEmployee
      {
        private const float daysMonth = 20.8f;
        private const int workingHours = 8;
        //private const int rate = 85;
        public HourlyPayment(int rate, int id, string name)
            : base(rate,  id,  name)
        {

        }
        public override void PaymentCalculation()
        {
            _MonthlyPayment = /*(float)*/(daysMonth * workingHours * _Rate);
            Console.WriteLine(_Name + "|" + "<Id>" + _Id + "|" + "Ваша среднемесячная зарплата составляет: " + _MonthlyPayment);
        }
        
      }
}
