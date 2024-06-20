using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using Newtonsoft.Json;

namespace WpfApp1.View
{
    public partial class ShowBooksWrittenByAuthor : Window
    {
        private const string AuthorBookConnectionsFilePath = "author_book_connections.json";
        private List<dynamic> authorBookConnections;

        public ShowBooksWrittenByAuthor()
        {
            InitializeComponent();
            authorBookConnections = LoadAuthorBookConnectionsFromFile();
        }

        private List<dynamic> LoadAuthorBookConnectionsFromFile()
        {
            if (!File.Exists(AuthorBookConnectionsFilePath))
            {
                return new List<dynamic>();
            }

            string json = File.ReadAllText(AuthorBookConnectionsFilePath);
            return JsonConvert.DeserializeObject<List<dynamic>>(json);
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string authorName = AuthorNameTextBox.Text.Trim().ToLower();
            var books = authorBookConnections
                        .Where(abc => abc.Member.Human.Name != null && ((string)abc.Member.Human.Name).ToLower() == authorName)
                        .Select(abc => new { abc.LibraryObject.Title, abc.LibraryObject.ISBN })
                        .ToList();

            if (books.Any())
            {
                BooksListView.ItemsSource = books;
            }
            else
            {
                MessageBox.Show("Author not found.");
                BooksListView.ItemsSource = null;
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            AuthorDashboard authDash = new AuthorDashboard();
            authDash.Show();
            this.Close();
        }
    }
}
