using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using Newtonsoft.Json;
using WpfApp1.Models;

namespace WpfApp1.View
{
    public partial class RemoveBorrow : Window
    {
        private const string BorrowsFilePath = "borrows.json";
        public const string BorrowsFilePathMember = "borrowsMember.json";

        public RemoveBorrow()
        {
            InitializeComponent();
            BorrowsListView.ItemsSource = LoadBorrowsFromFile();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(BorrowIDTextBox.Text, out int borrowID))
            {
                List<Borrow> borrows = LoadBorrowsFromFile();
                List<Borrow> borrowsMember = LoadBorrowsFromFileMember();
                Borrow borrowToRemove = borrows.FirstOrDefault(b => b.BorrowID == borrowID);

                if (borrowToRemove != null)
                {
                    borrows.Remove(borrowToRemove);
                    borrowsMember.Remove(borrowToRemove);
                    SaveBorrowsToFile(borrows);
                    SaveBorrowsToFileMember(borrowsMember);
                    MessageBox.Show("Borrow removed successfully!");
                    BorrowsListView.ItemsSource = borrows; 
                }
                else
                {
                    MessageBox.Show("Borrow ID not found.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Borrow ID.");
            }
        }

        private List<Borrow> LoadBorrowsFromFile()
        {
            if (!File.Exists(BorrowsFilePath))
            {
                return new List<Borrow>();
            }

            string json = File.ReadAllText(BorrowsFilePath);
            return JsonConvert.DeserializeObject<List<Borrow>>(json);
        }

        private void SaveBorrowsToFile(List<Borrow> borrows)
        {
            string json = JsonConvert.SerializeObject(borrows, Formatting.Indented);
            File.WriteAllText(BorrowsFilePath, json);
        }

        private List<Borrow> LoadBorrowsFromFileMember()
        {
            if (!File.Exists(BorrowsFilePathMember))
            {
                return new List<Borrow>();
            }

            string json = File.ReadAllText(BorrowsFilePathMember);
            return JsonConvert.DeserializeObject<List<Borrow>>(json);
        }

        private void SaveBorrowsToFileMember(List<Borrow> borrows)
        {
            string json = JsonConvert.SerializeObject(borrows, Formatting.Indented);
            File.WriteAllText(BorrowsFilePathMember, json);
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeDashboard emp = new EmployeeDashboard();
            emp.Show();
            this.Close();
        }
    }
}
