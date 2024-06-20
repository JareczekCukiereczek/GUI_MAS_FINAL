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
    /// <summary>
    /// Interaction logic for MemberCheck.xaml
    /// </summary>
    public partial class MemberCheck : Window
    {
        public MemberCheck()
        {
            InitializeComponent();
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            BorrowBook borrowBookWindow = new BorrowBook();
            borrowBookWindow.Show();
            this.Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            AddMember addMemberWindow = new AddMember();
            addMemberWindow.Show();
            this.Close();
        }
    }
}

