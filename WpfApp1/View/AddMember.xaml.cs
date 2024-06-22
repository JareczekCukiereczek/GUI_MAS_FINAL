using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Models;
using System.Text.RegularExpressions;

namespace WpfApp1.View
{
    public partial class AddMember : Window
    {
        private const string FilePath = "members.json";

        public AddMember()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = NameTextBox.Text;
                string surname = SurnameTextBox.Text;
         
                if (!int.TryParse(YearTextBox.Text.Trim(), out int year) || year > 2024)
                {
                    MessageBox.Show("Year cannot be greater than 2024.");
                    return;
                }

                string address = AddressTextBox.Text;
                Gender gender = (Gender)Enum.Parse(typeof(Gender), ((ComboBoxItem)GenderComboBox.SelectedItem).Content.ToString());
                bool isPremium = PremiumCheckBox.IsChecked ?? false;
                string membershipID = MembershipIDTextBox.Text;

                if (string.IsNullOrWhiteSpace(membershipID))
                {
                    MessageBox.Show("MembershipID cannot be empty.");
                    return;
                }
                if (!Regex.IsMatch(membershipID, @"^\d{9}$"))
                {
                    MessageBox.Show("MembershipID must be 9 digit numbers.");
                    return;
                }

                Human human = new Human(name, surname, year, address, gender);

                Member member = new Member(human, membershipID)
                {
                    IsPremium = isPremium
                };

                List<Member> members = LoadMembersFromFile() ?? new List<Member>();
                members.Add(member);
                SaveMembersToFile(members);

                MessageBox.Show("Member added successfuly!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error");
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeDashboard emp = new EmployeeDashboard();
            emp.Show();
            this.Close();
        }

        private List<Member> LoadMembersFromFile()
        {
            if (!File.Exists(FilePath))
            {
                return new List<Member>();
            }

            string json = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<Member>>(json) ?? new List<Member>();
        }

        private void SaveMembersToFile(List<Member> members)
        {
            string json = JsonConvert.SerializeObject(members, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }
    }
}
