using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Newtonsoft.Json;
using WpfApp1.Models;
using WpfApp1.View;

namespace WpfApp1.View
{
    public partial class ConnectAuthorBook : Window
    {
        private const string AuthorsFilePath = "authors.json";
        private const string BooksFilePath = "books.json";
        private const string AuthorBookConnectionsFilePath = "author_book_connections.json";

        public ConnectAuthorBook()
        {
            InitializeComponent();
            AuthorsListView.ItemsSource = LoadAuthorsFromFile();
            BooksListView.ItemsSource = LoadBooksFromFile();
        }

        private List<Author> LoadAuthorsFromFile()
        {
            if (!File.Exists(AuthorsFilePath))
            {
                return new List<Author>();
            }

            string json = File.ReadAllText(AuthorsFilePath);
            return JsonConvert.DeserializeObject<List<Author>>(json);
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

        private void SaveAuthorBookConnectionToFile(Author author, LibraryObject book)
        {
            var connection = new
            {
                Member = new
                {
                    Human = new
                    {
                        Name = author.Human.Name,
                        Surname = author.Human.Surname,
                        Year = author.Human.Year,
                        Address = author.Human.Address,
                        Gender = author.Human.Gender
                    },
                },
                LibraryObject = new
                {
                    book.Title,
                    book.NumberOfPages,
                    book.Type,
                    book.ISBN,
                    book.Illustration,
                    book.Rating,
                    book.Languages
                }
            };

            List<object> connections;
            if (File.Exists(AuthorBookConnectionsFilePath))
            {
                string json = File.ReadAllText(AuthorBookConnectionsFilePath);
                connections = JsonConvert.DeserializeObject<List<object>>(json) ?? new List<object>();
            }
            else
            {
                connections = new List<object>();
            }

            connections.Add(connection);
            string updatedJson = JsonConvert.SerializeObject(connections, Formatting.Indented);
            File.WriteAllText(AuthorBookConnectionsFilePath, updatedJson);
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            Author selectedAuthor = (Author)AuthorsListView.SelectedItem;
            LibraryObject selectedBook = (LibraryObject)BooksListView.SelectedItem;

            if (selectedAuthor == null || selectedBook == null)
            {
                MessageBox.Show("Please select authora and a booka.");
                return;
            }

            selectedAuthor.setBook(selectedBook);
            SaveAuthorBookConnectionToFile(selectedAuthor, selectedBook);

            MessageBox.Show("Authorek and book connected successfuly!");

            EmployeeDashboard emp = new EmployeeDashboard();
            emp.Show();
            this.Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeDashboard emp = new EmployeeDashboard();
            emp.Show();
            this.Close();
        }
    }
}
