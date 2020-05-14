﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class MainWindow : Window
    {
        const int departamentsCount = 10;
        const int employeeCount = 20;

        public ObservableCollection<Departament> Departaments = new ObservableCollection<Departament>();
        public ObservableCollection<Employee> Employees = new ObservableCollection<Employee>();

        Departament selectedDepartameent = new Departament();
        Employee selectedEmployee = new Employee();

        Random rnd = new Random();
        public MainWindow()
        {
            InitializeComponent();
            FillList();
            Bindings();
        }

        private void Bindings()
        {
            listBoxDepartament.ItemsSource = Departaments;
            listBoxEmlployee.ItemsSource = Employees;
            comboBoxSelectDepartament.ItemsSource = Departaments;
        }

        private void FillList()
        {
            for (var i = 0; i < departamentsCount; i++)
            {
                var employees = new List<Employee>(employeeCount);
                for (var j = 0; j < employeeCount; j++)
                {
                    employees.Add(new Employee
                    {
                        Id = j,
                        Name = $"Работник {i * 2 + 1}{j * 3 + 1}",
                        Age = rnd.Next(30 + i, 50 + j)
                    });
                }
                Departaments.Add(new Departament
                {
                    Id = i,
                    Name = $"Депантамент {i + 1}",
                    Employees = employees
                });
            }

        }

        //выбор департамента
        private void ChangedDepartament(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count <= 0) return;
            selectedDepartameent = (Departament)e.AddedItems[0];

            Employees.Clear();
            foreach (var v in selectedDepartameent.Employees)
                Employees.Add(v);

            textBoxDepartament.Text = $"Выбран департамент {selectedDepartameent.Name}";

            textBoxDepartamentName.Text = selectedDepartameent.Name;

        }

        //изменяем имя выбранного департамента
        private void buttonDepartamentName_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxDepartamentName.Text))
            {
                selectedDepartameent.Name = textBoxDepartamentName.Text;
                Departaments[selectedDepartameent.Id] = selectedDepartameent;
            }
        }

        //запоминаем выбранного сотрудника и вносим его данные на форму
        private void listBoxEmlployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count <= 0) return;
            selectedEmployee = (Employee)e.AddedItems[0];
            textBoxEmployeeName.Text = selectedEmployee.Name;
            textBoxEmployeeAge.Text = selectedEmployee.Age.ToString();
            //ставим департамент сотрудника выбранным в комбобоксе
            comboBoxSelectDepartament.SelectedItem = selectedDepartameent;
        }

        //изменяем данные сотрудника
        private void buttonEmployeeSave_Click(object sender, RoutedEventArgs e)
        {
            //удаляем работника из департамента
            foreach (var d in Departaments)
            {
                if (d.Employees.Contains(selectedEmployee))
                {
                    d.Employees.Remove(selectedEmployee);
                }
            }

            //изменяем его данные
            selectedEmployee.Name = textBoxEmployeeName.Text;
            selectedEmployee.Age = Int32.Parse(textBoxEmployeeAge.Text);

            //добавляем работника в выбранный департамент
            foreach (var d in Departaments)
            {
                if (d == selectedDepartameent)
                    d.Employees.Add(selectedEmployee);
            }
        }

        //запоминаем департамент в который надо перенести работника
        private void comboBoxSelectDepartament_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            selectedDepartameent = (Departament)comboBox.SelectedItem;
        }

        NewEmployee newEmployee = new NewEmployee();
        private void buttonNewEmployee_Click(object sender, RoutedEventArgs e)
        {
            newEmployee = new NewEmployee();
            newEmployee.Owner = this;
            newEmployee.comboBoxDepartaments.ItemsSource = Departaments;
            newEmployee.employee = new Employee();
            newEmployee.departament = new Departament();
            newEmployee.Show();

            newEmployee.Closed += Window_Closed;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //добавляем работника в выбранный департамент при закрытии формы
            foreach (var d in Departaments)
            {
                if (d == newEmployee.departament)
                    d.Employees.Add(new Employee
                    {
                        Id = d.Employees.Count + 1,
                        Age = newEmployee.employee.Age,
                        Name = newEmployee.employee.Name
                    });
            }
        }
    }
}
