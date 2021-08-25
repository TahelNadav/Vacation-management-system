using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Order.xaml
    /// </summary>
    /// 
    public partial class Order : Window
    {
        private ObservableCollection<BE.Order> listOrder;
        public Order()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            listOrder = new ObservableCollection<BE.Order>(MainWindow.bl.getAllOrder());
            Order_ListView.ItemsSource = listOrder;
            Status_ComboBox.ItemsSource = Enum.GetValues(typeof(BE.STATUS));
        }

        private void Status_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listOrder = new ObservableCollection<BE.Order>(MainWindow.bl.getOrdersByStatus((BE.STATUS)Status_ComboBox.SelectedItem, listOrder.ToList()));
            Order_ListView.ItemsSource = listOrder;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (Id_TextBox.Text!="") 
            {
                listOrder = new ObservableCollection<BE.Order>(MainWindow.bl.getOrdersByHostId(long.Parse(Id_TextBox.Text), listOrder.ToList()));
                Order_ListView.ItemsSource = listOrder;
            }
            else
            {
                MessageBox.Show("", "יש להכניס ת.ז במקום המיועד", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Id_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                long.Parse(Id_TextBox.Text);
                Search.IsEnabled = true;
            }
            catch
            {
                Search.IsEnabled = false;
                MessageBox.Show("יש להכניס מספרים בן 9 ספרות בלבד!");
            }
        }

        private void Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            listOrder = new ObservableCollection<BE.Order>(MainWindow.bl.getAllOrder());
            Order_ListView.ItemsSource = listOrder;
            Status_ComboBox.ItemsSource = Enum.GetValues(typeof(BE.STATUS));
            Id_TextBox.Text = "";
        }
    }
}
