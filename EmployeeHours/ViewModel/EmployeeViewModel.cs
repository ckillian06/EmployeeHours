using EmployeeHours.Model;
using EmployeeHours.View;
using Microsoft.VisualStudio.PlatformUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EmployeeHours.ViewModel
{
    public partial class EmployeeViewModel : INotifyPropertyChanged
    {
        readonly EmployeeHoursEntities EmployeeHoursEntities = new EmployeeHoursEntities();

        public EmployeeViewModel()
        {            
            RetrieveEmployees();
            ConfirmHours = new DelegateCommand(CalculateBreak);
            PrintHoursReport = new DelegateCommand(PrintEmployeeHoursReport);
            AddEmployee = new DelegateCommand(AddNewEmployee);
            ViewEmployee = new DelegateCommand(ViewEmployeeDetails);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddEmployee
        {
            get;
            private set;
        }
        public ICommand ViewEmployee
        {
            get;
            private set;
        }
        public ICommand ConfirmHours
        {
            get;
            private set;
        }
        public ICommand PrintHoursReport
        {
            get;
            private set;
        }


        private List<Employee> _employees;
        public List<Employee> Employees
        {
            get
            {
                return _employees;
            }
            set
            {
                _employees = value;

                NotifyPropertyChanged();
            }
        }


        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                NotifyPropertyChanged();
                SetEmployeeHours();
            }
        }


        private EmployeeHour _selectedHours;
        public EmployeeHour SelectedHours
        {
            get { return _selectedHours; }

            set
            {
                _selectedHours = value;
                NotifyPropertyChanged();

            }
        }


        private Employee _newEmployee;
        public Employee NewEmployee
        {
            get { return _newEmployee; }
            set
            {
                _newEmployee = value;
                NotifyPropertyChanged();
                EmployeeHoursEntities.Employees.Add(_newEmployee);
            }
        }


        private void AddNewEmployee(object obj)
        {
            AddEmployee addEmployee = new AddEmployee(this);
            addEmployee.Show();
        }

        private void ViewEmployeeDetails(object obj)
        {
            ViewEmployeeHours employeeHours = new ViewEmployeeHours(this);
            employeeHours.Show();
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void RetrieveEmployees()
        {
            Employees = (from employees in EmployeeHoursEntities.Employees
                         join hours in EmployeeHoursEntities.EmployeeHours
                         on employees.Id equals hours.Employee_Id into employeeHours
                         from query in employeeHours.DefaultIfEmpty()
                         select employees).ToList();
        }

        private void SetEmployeeHours()
        {
            if (SelectedEmployee.EmployeeHours.Count() == 0)
            {
                SelectedHours = new EmployeeHour() { Employee_Id = SelectedEmployee.Id, Hours = 0, BreakTime = 0, Employee = SelectedEmployee };
                EmployeeHoursEntities.EmployeeHours.Add(SelectedHours);
            }
            else
                SelectedHours = SelectedEmployee.EmployeeHours.FirstOrDefault(); //Change this if hours entered by month to take most recent
        }

        private void PrintEmployeeHoursReport(object obj)
        {
            HoursReporting.PrintDocument(SelectedEmployee);
        }

        public void SaveChanges()
        {
            EmployeeHoursEntities.SaveChanges();

            RetrieveEmployees();
        }

        private void CalculateBreak(object obj)
        {
            SelectedHours.BreakTime = HoursProcessor.CalculateBreakTime(_selectedEmployee);
            NotifyPropertyChanged(nameof(SelectedHours));            
            SaveChanges();
        }

    }
}