﻿using System;
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
    /// Interaction logic for EmployeeHours.xaml
    /// </summary>
    public partial class ViewEmployeeHours : Window
    {
        public ViewEmployeeHours(ViewModel.EmployeeViewModel employeeViewModel)
        {
            InitializeComponent();
            this.DataContext = employeeViewModel;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }      
    }
}
