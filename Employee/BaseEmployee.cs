using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
   public abstract class BaseEmployee:IComparable
    {
        public int _Rate { get; private set; }
        public int _Id { get; private set; }
        public string _Name { get; private set; }
        public float _MonthlyPayment { get; set; }        
        protected BaseEmployee(int rate, int id, string name)
        {
            _Rate = rate;
            _Id = id;
            _Name = name;            
        }
        public abstract void PaymentCalculation();
        
        public int CompareTo(object obj)
        {
            BaseEmployee b = obj as BaseEmployee;
            if (b != null)                
            return this._MonthlyPayment.CompareTo(b._MonthlyPayment);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }

    }
}
