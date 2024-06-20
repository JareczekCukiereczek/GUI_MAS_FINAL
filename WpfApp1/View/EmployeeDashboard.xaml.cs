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
using WpfApp1.View;

namespace WpfApp1.View
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
            MainWindow main = new MainWindow();
            main.Show();
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
        private void ShowAllBooksButton_Click(object sender, RoutedEventArgs e)
        {
            AllLibraryObjects allLibraryObjectsWindow = new AllLibraryObjects();
            allLibraryObjectsWindow.Show();
            this.Close();
        }
        private void RemoveBorrowButton_Click(object sender, RoutedEventArgs e)
        {
            RemoveBorrow removik = new RemoveBorrow();
            removik.Show();
            this.Close();
        }
        private void BookBorrowButton_Click(object sender, RoutedEventArgs e)
        {
            MemberCheck memberCheckWindow = new MemberCheck();
            memberCheckWindow.Show();
            this.Close();
        }
        private void ShowAllMembersButton_Click(object sender, RoutedEventArgs e)
        {
            ShowAllMembers showAllMembersWindow = new ShowAllMembers();
            showAllMembersWindow.Show();
            this.Close();
        }
        private void ShowAllBorrowsButton_Click(object sender, RoutedEventArgs e)
        {
            ShowAllBorrows showAllBorrowsWindow = new ShowAllBorrows();
            showAllBorrowsWindow.Show();
            this.Close();
        }
        private void ConnAuthorBookButton_Click(object sender, RoutedEventArgs e)
        {
            ConnectAuthorBook connectAuthorBookWindow = new ConnectAuthorBook();
            connectAuthorBookWindow.Show();
            this.Close();
        }

    }
}
