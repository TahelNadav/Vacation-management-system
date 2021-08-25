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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for ChangeFee.xaml
    /// </summary>
    public partial class ChangeFee : Window
    {
        public ChangeFee()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!fee_TextBox.Text.All(char.IsDigit))
            {
                MessageBox.Show("יש להכניס תוכן מספרי בלבד", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                BE.Configuration.fee = float.Parse(fee_TextBox.Text);
                this.Close();
            }
        }
    }
}
