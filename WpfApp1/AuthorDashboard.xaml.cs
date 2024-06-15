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
    /// Interaction logic for AuthorDashboard.xaml
    /// </summary>
    public partial class AuthorDashboard : Window
    {
        public AuthorDashboard()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void ShowBooksButton_Click(object sender, RoutedEventArgs e)
        {
            AllLibraryObjects all = new AllLibraryObjects();
            all.Show();
            this.Close();
        }
    }
}
