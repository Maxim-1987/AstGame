using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
   public class EmployeeInput
    {
         public void EmployeeIn()
        {
            Console.WriteLine("\nВведите Ваше имя: ");
            string name = Console.ReadLine();
            Console.WriteLine("Введите Ваш id: 1 - часовая ставка или 2 - фиксированная ставка");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите Вашу ставку:");
            int rate = int.Parse(Console.ReadLine());
            if (id == 1)
            {
                HourlyPayment hp = new HourlyPayment(rate, id, name);
                hp.PaymentCalculation();
            }
            if (id == 2)
            {
                FixedPayment fp = new FixedPayment(rate, id, name);
                fp.PaymentCalculation();
            }
        }
    }
}
