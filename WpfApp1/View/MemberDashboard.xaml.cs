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

namespace WpfApp1.View
{
    public partial class MemberDashboard : Window
    {
        public MemberDashboard()
        {
            InitializeComponent();
        }
        private void BorrowBookButton_Click(object sender, RoutedEventArgs e)
        {
            BorrowBook borrowBookWindow = new BorrowBook();
            borrowBookWindow.Show();
            this.Close();
        }

        private void ShowAllBooksButton_Click(object sender, RoutedEventArgs e)
        {
            AllLibraryObjects allObjects = new AllLibraryObjects();
            allObjects.Show();
            this.Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Save button clicked");
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
        
    }
}

