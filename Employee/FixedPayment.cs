using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    public class FixedPayment : BaseEmployee
    {
        public FixedPayment(int rate, int id, string name)
            : base(rate, id, name)
        {

        }

        public override void PaymentCalculation()
        {
            _MonthlyPayment = _Rate;
        }
    }
}
