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
using System.Collections.ObjectModel;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public class Departament
    {        
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
        //public override string ToString()
        //{
        //    return $"Name:{Name}, Employees Count:{Employees.Count}";
        //}
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
        public ObservableCollection<Departament> Departaments;
        public ObservableCollection<Employee> Employees = new ObservableCollection<Employee>();

        //Departament selectedDepartameent = new Departament();
        //Employee selectedEmployee = new Employee();

        public MainWindow()
        {
        InitializeComponent();
            Departaments = new ObservableCollection<Departament>
            {
              new Departament {Name = "Департамент финансов" },
              new Departament {Name = "Департамент по недропользованию" },
              new Departament {Name = "Судебный департамент" },
              new Departament {Name = "Департамент здравоохранения" }
            };
            ComboBoxDepartment.ItemsSource = Departaments;

        }

        private void ComboBoxDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            //ComboBox comboBox = (ComboBox)sender;
            //selectedDepartameent = (Departament)comboBox.SelectedItem;
        }

        NewEmployee _NewEmployee = new NewEmployee();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _NewEmployee = new NewEmployee
            {
                Owner = this,
                Employee = new Employee(),
                Departament = new Departament()
            };
            _NewEmployee.ShowDialog();
            //_NewEmployee.Closed += NewEmployee_WindowClosed;
            
        }
        
        //private void NewEmployee_WindowClosed(object sender, EventArgs e)
        //{            
        //    foreach (var d in Departaments)
        //    {
        //        if (d == _NewEmployee.departament)
        //            d.Employees.Add(new Employee
        //            {
        //                Id = d.Employees.Count + 1,                        
        //                Name = _NewEmployee.employee.Name
        //            });
        //    }
        //}

    }
}
