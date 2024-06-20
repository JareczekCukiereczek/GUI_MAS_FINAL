using System.Windows;
using WpfApp1.Models;

namespace WpfApp1.View
{
    public partial class AllLibraryObjects : Window
    {
        public LibraryObjectViewModel ViewModel { get; set; }

        public AllLibraryObjects()
        {
            InitializeComponent();
            ViewModel = new LibraryObjectViewModel();
            this.DataContext = ViewModel;
            LibraryObjectsListView.ItemsSource = ViewModel.LibraryObjects;
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
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
