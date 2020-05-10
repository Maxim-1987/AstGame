using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public class Departament
    {        
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
        public override string ToString()
        {
            return $"Name:{Name}, Employees Count:{Employees.Count}";
        }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public override string ToString()
        {
            return $"Id:{Id}, Name:{Name}";
        }
    }

    public partial class MainWindow : Window
    {
        public List<Departament> Departaments = new List<Departament>();
        public List<Employee> Employees = new List<Employee>();

        Departament selectedDepartameent = new Departament();
        Employee selectedEmployee = new Employee();

        public MainWindow()
        {
            
            InitializeComponent();            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBoxDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Departaments.Add(new Departament { Name = "Бухгалтерия" });
        }
    }
}
