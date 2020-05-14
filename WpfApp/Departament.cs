using System.Collections.Generic;

namespace WpfApp
{
    public class Departament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
        public override string ToString()
        {
            return $"Id:{Id}, Name:{Name}, Employees Count:{Employees.Count}";
        }
    }
}
