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
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для NewEmployee.xaml
    /// </summary>
    public partial class NewEmployee : Window
    {
        public Employee employee { get; set; }
        public Departament departament { get; set; }

        public NewEmployee()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            employee.Name = TexBoxName.Text;
            Close();
        }

        //private void ComboBoxDepartament_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    ComboBox comboBox = (ComboBox)sender;
        //    departament = (Departament)comboBox.SelectedItem;
        //}
    }
}
