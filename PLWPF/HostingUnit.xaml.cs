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
    /// Interaction logic for HostingUnit.xaml
    /// </summary>
    public partial class HostingUnit : Window
    {
        private ObservableCollection<BE.HostingUnit> listHU;
        public HostingUnit()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            listHU = new ObservableCollection<BE.HostingUnit>(MainWindow.bl.getAllUnits());
            HostingUnit_ListView.ItemsSource = listHU;
            Type_ComboBox.ItemsSource = Enum.GetValues(typeof(BE.TYPE));
            Area_ComboBox.ItemsSource = Enum.GetValues(typeof(BE.LOCATION));
            Pool_ComboBox.ItemsSource = Enum.GetValues(typeof(BE.BOOL));
            ChildrenAttraction_ComboBox.ItemsSource = Enum.GetValues(typeof(BE.BOOL));
        }

        private void Area_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listHU = new ObservableCollection<BE.HostingUnit>(MainWindow.bl.getHUByLocation((BE.LOCATION)Area_ComboBox.SelectedItem, listHU.ToList()));
            HostingUnit_ListView.ItemsSource = listHU;
        }

        private void Type_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listHU = new ObservableCollection<BE.HostingUnit>(MainWindow.bl.getHUByType((BE.TYPE)Type_ComboBox.SelectedItem, listHU.ToList()));
            HostingUnit_ListView.ItemsSource = listHU;
        }

        private void ChildrenAttraction_ComboBox_Checked(object sender, RoutedEventArgs e)
        {
            if ((BE.BOOL)ChildrenAttraction_ComboBox.SelectedItem == BE.BOOL.יש) {
                listHU = new ObservableCollection<BE.HostingUnit>(MainWindow.bl.getHUByChildrenA(true, listHU.ToList()));
                HostingUnit_ListView.ItemsSource = listHU;
            }
            else
            {
                listHU = new ObservableCollection<BE.HostingUnit>(MainWindow.bl.getHUByChildrenA(false, listHU.ToList()));
                HostingUnit_ListView.ItemsSource = listHU;
            }
        }

        private void Pool_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((BE.BOOL)Pool_ComboBox.SelectedItem == BE.BOOL.יש)
            {
                listHU = new ObservableCollection<BE.HostingUnit>(MainWindow.bl.getHUByPool(true, listHU.ToList()));
                HostingUnit_ListView.ItemsSource = listHU;
            }
            else
            {
                listHU = new ObservableCollection<BE.HostingUnit>(MainWindow.bl.getHUByPool(false, listHU.ToList()));
                HostingUnit_ListView.ItemsSource = listHU;
            }
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            if (HUName_TextBox.Text!="") 
            {
                listHU = new ObservableCollection<BE.HostingUnit>(MainWindow.bl.getHUByName(HUName_TextBox.Text, listHU.ToList()));
                HostingUnit_ListView.ItemsSource = listHU;
            }
            else
            {
                MessageBox.Show("","יש להכניס שם במקום המיועד", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            listHU = new ObservableCollection<BE.HostingUnit>(MainWindow.bl.getAllUnits());
            HostingUnit_ListView.ItemsSource = listHU;
            Type_ComboBox.ItemsSource = Enum.GetValues(typeof(BE.TYPE));
            Area_ComboBox.ItemsSource = Enum.GetValues(typeof(BE.LOCATION));
            Pool_ComboBox.ItemsSource = Enum.GetValues(typeof(BE.BOOL));
            ChildrenAttraction_ComboBox.ItemsSource = Enum.GetValues(typeof(BE.BOOL));
            HUName_TextBox.Text = "";

        }
    }
}
