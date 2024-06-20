using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using Newtonsoft.Json;
using WpfApp1.Models;

namespace WpfApp1.View
{
    public partial class RemoveMember : Window
    {
        private const string MembersFilePath = "members.json";
        private const string BorrowsFilePath = "borrows.json";

        public RemoveMember()
        {
            InitializeComponent();
            MembersListView.ItemsSource = LoadMembersFromFile();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            string membershipID = MembershipIDTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(membershipID))
            {
                List<Member> members = LoadMembersFromFile();
                Member memberToRemove = members.FirstOrDefault(m => m.MembershipID == membershipID);

                if (memberToRemove != null)
                {
                    members.Remove(memberToRemove);
                    SaveMembersToFile(members);
                    RemoveMemberBorrows(memberToRemove);
                    MessageBox.Show("Member and associated borrows removed successfully!");
                    MembersListView.ItemsSource = members; // Aktualizuj listę
                }
                else
                {
                    MessageBox.Show("Membership ID not found.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Membership ID.");
            }
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

        private void SaveMembersToFile(List<Member> members)
        {
            string json = JsonConvert.SerializeObject(members, Formatting.Indented);
            File.WriteAllText(MembersFilePath, json);
        }

        private void RemoveMemberBorrows(Member member)
        {
            List<Borrow> borrows = LoadBorrowsFromFile();
            borrows.RemoveAll(b => b.Member.MembershipID == member.MembershipID);
            SaveBorrowsToFile(borrows);
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

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeDashboard emp = new EmployeeDashboard();
            emp.Show();
            this.Close();
        }
    }
}
