using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
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
    /// Interaction logic for GuestRequest.xaml
    /// </summary>
    public partial class GuestRequest : Window
    {
        private ObservableCollection<BE.GuestRequest> listGR ;
        public GuestRequest()
        {

            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            listGR = new ObservableCollection<BE.GuestRequest>(MainWindow.bl.getAllGuests());
            GR_ListView.ItemsSource = listGR;
            Type_ComboBox.ItemsSource = Enum.GetValues(typeof(BE.TYPE));
            Area_ComboBox.ItemsSource = Enum.GetValues(typeof(BE.LOCATION));
            Pool_ComboBox.ItemsSource = Enum.GetValues(typeof(BE.OPTIONS));
            Status_ComboBox.ItemsSource = Enum.GetValues(typeof(BE.STATUS));
        }

        private void Area_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listGR = new ObservableCollection<BE.GuestRequest>(MainWindow.bl.GetGRByLocation((BE.LOCATION)Area_ComboBox.SelectedItem, listGR.ToList()));
            GR_ListView.ItemsSource = listGR;
        }

        private void Status_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listGR = new ObservableCollection<BE.GuestRequest>(MainWindow.bl.GetGRByStatus((BE.STATUS)Status_ComboBox.SelectedItem, listGR.ToList()));
            GR_ListView.ItemsSource = listGR;
        }

        private void Type_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listGR = new ObservableCollection<BE.GuestRequest>(MainWindow.bl.GetGRByType((BE.TYPE)Type_ComboBox.SelectedItem, listGR.ToList()));
            GR_ListView.ItemsSource = listGR;
        }

        private void Pool_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listGR = new ObservableCollection<BE.GuestRequest>(MainWindow.bl.GetGRByPool((BE.OPTIONS)Pool_ComboBox.SelectedItem, listGR.ToList()));
            GR_ListView.ItemsSource = listGR;
        }

        private void FM_Button_Click(object sender, RoutedEventArgs e)
        {
            if (FamilyName_TextBox.Text !="")
            {
                listGR = new ObservableCollection<BE.GuestRequest>(MainWindow.bl.GetGRByFM(FamilyName_TextBox.Text, listGR.ToList()));
                GR_ListView.ItemsSource = listGR; 
            }
            else
            {
                MessageBox.Show("הכנס שם לחיפוש", "",  MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            listGR = new ObservableCollection<BE.GuestRequest>(MainWindow.bl.getAllGuests());
            GR_ListView.ItemsSource = listGR;
            Type_ComboBox.ItemsSource = Enum.GetValues(typeof(BE.TYPE));
            Area_ComboBox.ItemsSource = Enum.GetValues(typeof(BE.LOCATION));
            Pool_ComboBox.ItemsSource = Enum.GetValues(typeof(BE.OPTIONS));
            Status_ComboBox.ItemsSource = Enum.GetValues(typeof(BE.STATUS));
            FamilyName_TextBox.Text = "";
        }
        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
