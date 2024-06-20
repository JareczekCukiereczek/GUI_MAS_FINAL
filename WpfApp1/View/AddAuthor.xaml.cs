using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Models;

namespace WpfApp1.View
{
    public partial class AddAuthor : Window
    {
        private const string FilePath = "authors.json";

        public AddAuthor()
        {
            InitializeComponent();
        }

        private void AddAuthorButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = NameTextBox.Text;
                string surname = SurnameTextBox.Text;
                int year = int.Parse(YearTextBox.Text);
                string address = AddressTextBox.Text;
                Gender gender = (Gender)Enum.Parse(typeof(Gender), ((ComboBoxItem)GenderComboBox.SelectedItem).Content.ToString());
                string biography = BiographyTextBox.Text;
                bool receivedNobel = NobelCheckBox.IsChecked == true;

                Human human = new Human(name, surname, year, address, gender);

                Author author = new Author(human, name, surname, year, address, gender)
                {
                    Biography = biography,
                    ReceivedNobel = receivedNobel
                };

                List<Author> authors = LoadAuthorsFromFile() ?? new List<Author>();
                authors.Add(author);
                SaveAuthorsToFile(authors);

                MessageBox.Show("Author added successfully!");
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

        private List<Author> LoadAuthorsFromFile()
        {
            if (!File.Exists(FilePath))
            {
                return new List<Author>();
            }

            string json = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<Author>>(json) ?? new List<Author>();
        }

        private void SaveAuthorsToFile(List<Author> authors)
        {
            string json = JsonConvert.SerializeObject(authors, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }
    }
}
