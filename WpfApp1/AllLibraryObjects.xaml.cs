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
    /// Interaction logic for AllLibraryObjects.xaml
    /// </summary>
    public partial class AllLibraryObjects : Window
    {
        public AllLibraryObjects()
        {
            InitializeComponent();
        }

       
        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement your find logic here
            MessageBox.Show("Find button clicked");
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement your select logic here
            MessageBox.Show("Select button clicked");
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

