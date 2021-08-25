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
    /// Interaction logic for Host.xaml
    /// </summary>
    public partial class Host : Window
    {
        private ObservableCollection<BE.Host> listHost;
        public Host()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            listHost = new ObservableCollection<BE.Host>(MainWindow.bl.getHostList(MainWindow.bl.getAllUnits()));
            Host_ListView.ItemsSource = listHost;
        }
        #region ButtonEvent
        private void Sort_Button_Click(object sender, RoutedEventArgs e)
        {
            if(LastName_TextBox.Text != "")
            {
                listHost = new ObservableCollection< BE.Host>(MainWindow.bl.getHostByFM(LastName_TextBox.Text,listHost.ToList()));
                Host_ListView.ItemsSource = listHost;
            }
            if(Id_TextBox.Text != "")
            {
                listHost = new ObservableCollection<BE.Host>(MainWindow.bl.getHostById(long.Parse(Id_TextBox.Text), listHost.ToList()));
                Host_ListView.ItemsSource = listHost;
            }
            if (numOHU_TextBox.Text != "")
            {
                listHost = new ObservableCollection<BE.Host>(MainWindow.bl.getHostByNumOfHU(int.Parse(numOHU_TextBox.Text), listHost.ToList()));
                Host_ListView.ItemsSource = listHost;
            }
        }

        private void Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            listHost = new ObservableCollection<BE.Host>(MainWindow.bl.getHostList(MainWindow.bl.getAllUnits()));
            Host_ListView.ItemsSource = listHost;
            LastName_TextBox.Text = "";
            Id_TextBox.Text = "";
            numOHU_TextBox.Text = "";
        }
        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
