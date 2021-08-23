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

namespace EmployeeHours.View
{
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        public EmployeeHours.ViewModel.EmployeeViewModel EmployeeViewModel;
        public AddEmployee(EmployeeHours.ViewModel.EmployeeViewModel employeeViewModel)
        {
            InitializeComponent();
            EmployeeViewModel = employeeViewModel;
        }

        private void btnSaveEmployee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeViewModel.NewEmployee = new Model.Employee { Name = txtEmployeeName.Text, JobDesc = txtEmployeejobDesc.Text, IsNightshift = (bool)chxIsNightShift.IsChecked};
            EmployeeViewModel.SaveChanges();
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       


    }
}
