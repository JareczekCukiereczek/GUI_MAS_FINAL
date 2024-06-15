using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for EmployeeDashboard.xaml
    /// </summary>
    public partial class EmployeeDashboard : Window
    {
        public EmployeeDashboard()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void AddMemberButton_Click(object sender, RoutedEventArgs e)
        {
            AddMember addMemberWindow = new AddMember();
            addMemberWindow.Show();
            this.Close();
        }
        private void AddAuthorButton_Click(object sender, RoutedEventArgs e)
        {
            AddAuthor addAuthorWindow = new AddAuthor();
            addAuthorWindow.Show();
            this.Close();
        }
        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee addEmployeeWindow = new AddEmployee();
            addEmployeeWindow.Show();
            this.Close();
        }
        private void ShowallBooksButton_Click(object sender, RoutedEventArgs e)
        {
            AllLibraryObjects allObjects = new AllLibraryObjects();
            allObjects.Show();
            this.Close();
        }
        private void AddSectionToLibButton_Click(object sender, RoutedEventArgs e)
        {
            AddSectionToLib addSectionToLibWindow = new AddSectionToLib();
            addSectionToLibWindow.Show();
            this.Close();
        }
        private void CreateSectionButton_Click(object sender, RoutedEventArgs e)
        {
            CreateSection createSectionWindow = new CreateSection();
            createSectionWindow.Show();
            this.Close();
        }
        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            AddBook addBookWindow = new AddBook();
            addBookWindow.Show();
            this.Close();
        }
        private void RemoveMemberButton_Click(object sender, RoutedEventArgs e)
        {
            RemoveMember removeMemberWindow = new RemoveMember();
            removeMemberWindow.Show();
            this.Close();
        }
        private void RemoveBorrowButton_Click(object sender, RoutedEventArgs e)
        {
            RemoveBorrow removeBorrowWindow = new RemoveBorrow();
            removeBorrowWindow.Show();
            this.Close();
        }
        private void BookBorrowButton_Click(object sender, RoutedEventArgs e)
        {
            BorrowBook borrowik = new BorrowBook();
            borrowik.Show();
            this.Close();
        }


    }
}
