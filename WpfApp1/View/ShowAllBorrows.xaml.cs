using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Newtonsoft.Json;
using WpfApp1.Models;

namespace WpfApp1.View
{
    public partial class ShowAllBorrows : Window
    {
        public ShowAllBorrows()
        {
            InitializeComponent();
            BorrowsListView.ItemsSource = LoadBorrowsFromFile();
        }

        private List<Borrow> LoadBorrowsFromFile()
        {
            const string FilePath = "borrows.json";
            if (!File.Exists(FilePath))
            {
                return new List<Borrow>();
            }

            string json = File.ReadAllText(FilePath);
            List<Borrow> borrows = JsonConvert.DeserializeObject<List<Borrow>>(json);

            return borrows;
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
