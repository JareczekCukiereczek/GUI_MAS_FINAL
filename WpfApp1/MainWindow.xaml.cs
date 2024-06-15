using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WpfApp1;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private List<EmployeeMember> employees = new List<EmployeeMember>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MemberButton_Click(object sender, RoutedEventArgs e)
        {
            MemberDashboard memberDashboard = new MemberDashboard();
            memberDashboard.Show();
            this.Close();
        }

        private void EmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeDashboard employeeDashboard = new EmployeeDashboard();
            employeeDashboard.Show();
            this.Close();
        }

        private void AuthorButton_Click(object sender, RoutedEventArgs e)
        {
            AuthorDashboard authorDashboard = new AuthorDashboard();
            authorDashboard.Show();
            this.Close();
        }

    }
}
