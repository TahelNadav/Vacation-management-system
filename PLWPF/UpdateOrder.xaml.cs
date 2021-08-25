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
    /// Interaction logic for UpdateOrder.xaml
    /// </summary>
    public partial class UpdateOrder : Window
    {
        private long hostId;
        private BE.Order or = new BE.Order();
        private BE.STATUS s;
        public UpdateOrder(string Id)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            hostId = long.Parse(Id);
            Order_ComboBox.ItemsSource = MainWindow.bl.getOrdersByHostId(hostId,MainWindow.bl.getAllOrder());
            Status_ComboBox.ItemsSource = Enum.GetValues(typeof(BE.STATUS));
        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                or = (BE.Order)Order_ComboBox.SelectedItem;
                if (or == null)
                {
                    MessageBox.Show("יש לבחור הזמנה   מהרשימה", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (Status_ComboBox.SelectedIndex==-1)
                {
                    MessageBox.Show("יש לבחור סטטוס לעדכון", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    s = (BE.STATUS)Status_ComboBox.SelectedItem;
                    MainWindow.bl.updateOrder(or, s);
                    MessageBox.Show("הזמנתך עודכנה בהצלחה", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                
            }
            catch(BE.theOrderIsDone exc)
            {
                MessageBox.Show( exc.what(),"", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception exc)
            {
                MessageBox.Show( exc.Message,"", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
