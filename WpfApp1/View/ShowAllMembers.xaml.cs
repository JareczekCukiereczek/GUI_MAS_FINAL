using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Newtonsoft.Json;
using WpfApp1.Models;

namespace WpfApp1.View
{
    public partial class ShowAllMembers : Window
    {
        public ShowAllMembers()
        {
            InitializeComponent();
            MembersListView.ItemsSource = LoadMembersFromFile();
        }

        private List<Member> LoadMembersFromFile()
        {
            const string FilePath = "members.json";
            if (!File.Exists(FilePath))
            {
                return new List<Member>();
            }

            string json = File.ReadAllText(FilePath);
            List<Member> members = JsonConvert.DeserializeObject<List<Member>>(json);

            return members;
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Find button clicked");
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Select button clicked");
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeDashboard employeeDashboard = new EmployeeDashboard();
            employeeDashboard.Show();
            this.Close();
        }
    }
}
