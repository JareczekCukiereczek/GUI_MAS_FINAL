using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Newtonsoft.Json;
using WpfApp1.Models;


namespace WpfApp1.View
{
    public partial class BorrowBook : Window
    {
        private const string MembersFilePath = "members.json";
        private const string BooksFilePath = "books.json";
        private const string BorrowsFilePath = "borrows.json";
        public Member Member { get; set; }

        public BorrowBook()
        {
            InitializeComponent();
            MembersListView.ItemsSource = LoadMembersFromFile();
            BooksListView.ItemsSource = LoadBooksFromFile();
        }

        private List<Member> LoadMembersFromFile()
        {
            if (!File.Exists(MembersFilePath))
            {
                return new List<Member>();
            }

            string json = File.ReadAllText(MembersFilePath);
            return JsonConvert.DeserializeObject<List<Member>>(json);
        }

        private List<LibraryObject> LoadBooksFromFile()
        {
            if (!File.Exists(BooksFilePath))
            {
                return new List<LibraryObject>();
            }

            string json = File.ReadAllText(BooksFilePath);
            return JsonConvert.DeserializeObject<List<LibraryObject>>(json);
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


        private static Random random = new Random();
        private void BorrowButton_Click(object sender, RoutedEventArgs e)
        {
            Member selectedMember = (Member)MembersListView.SelectedItem;
            LibraryObject selectedBook = (LibraryObject)BooksListView.SelectedItem;

            if (selectedMember == null || selectedBook == null)
            {
                MessageBox.Show("Please select a member and a book.");
                return;
            }
            int id = GenerateUniqueBorrowID();
            Borrow newBorrow = new Borrow(selectedMember, selectedBook, DateTime.Now,id);
            List<Borrow> borrows = LoadBorrowsFromFile();
            borrows.Add(newBorrow);
            SaveBorrowsToFile(borrows);
            selectedMember.SerializeBorrowsToFile();


            BorrowSuccess successWindow = new BorrowSuccess();
            successWindow.Show();
            this.Close();
        }
        private static HashSet<int> existingBorrowIDs = new HashSet<int>();
        private int GenerateUniqueBorrowID()
        {
            int newID;
            do
            {
                newID = random.Next(100000, 999999); // Losowego ID  od 100000 do 999999 jako liczba
            } while (existingBorrowIDs.Contains(newID));

            existingBorrowIDs.Add(newID);
            return newID;
        }



        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeDashboard emp = new EmployeeDashboard();
            emp.Show();
            this.Close();
        }
    }
}
