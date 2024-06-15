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
    /// Interaction logic for BorrowBook.xaml
    /// </summary>
    public partial class BorrowBook : Window
    {
        public BorrowBook()
        {
            InitializeComponent();
        }

        private void BorrowButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement your borrow logic here
            MessageBox.Show("Borrow button clicked");
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
