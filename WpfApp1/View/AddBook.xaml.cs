
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using WpfApp1.Models;

namespace WpfApp1.View
{
    public partial class AddBook : Window
    {
        private const string FilePath = "books.json";

        public AddBook()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string title = TitleTextBox.Text;
                int numberOfPages = int.Parse(NumberOfPagesTextBox.Text);
                string type = TypeTextBox.Text;
                string isbn = ISBNTextBox.Text;
                bool illustration = IllustrationCheckBox.IsChecked ?? false;
                double rating = double.Parse(RatingTextBox.Text);

                LibraryObject libraryObject = new LibraryObject(title)
                {
                    NumberOfPages = numberOfPages,
                    Type = type,
                    ISBN = isbn,
                    Illustration = illustration ? "Yes" : "No",
                    Rating = rating,
                    AddedDate = DateTime.Now
                };

                List<LibraryObject> libraryObjects = LoadLibraryObjectsFromFile() ?? new List<LibraryObject>();
                libraryObjects.Add(libraryObject);
                SaveLibraryObjectsToFile(libraryObjects);

                MessageBox.Show("Book added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeDashboard emp = new EmployeeDashboard();
            emp.Show();
            this.Close();
        }

        private List<LibraryObject> LoadLibraryObjectsFromFile()
        {
            if (!File.Exists(FilePath))
            {
                return new List<LibraryObject>();
            }

            string json = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<LibraryObject>>(json) ?? new List<LibraryObject>();
        }

        private void SaveLibraryObjectsToFile(List<LibraryObject> libraryObjects)
        {
            string json = JsonConvert.SerializeObject(libraryObjects, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }
    }
}


