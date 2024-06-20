using System.Windows;

namespace WpfApp1.View
{
    public partial class BorrowSuccess : Window
    {
        public BorrowSuccess()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeDashboard emp = new EmployeeDashboard();
            emp.Show();
            this.Close();
        }
    }
}
