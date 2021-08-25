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
    /// Interaction logic for UpdateHU.xaml
    /// </summary>
    public partial class UpdateHU : Window
    {
        private ObservableCollection<BE.HostingUnit> listHU  = new ObservableCollection<BE.HostingUnit>();
        public BE.HostingUnit hu = new BE.HostingUnit();
        List<BE.BankBranch> bankList = new List<BE.BankBranch>();
        string bankName;
        public UpdateHU(List<BE.HostingUnit> list , List<BE.BankBranch> l)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            bankList = l;
            listHU = new ObservableCollection<BE.HostingUnit>(list);
            HUList_ComboBox.ItemsSource = listHU;
            locationComboBox.ItemsSource = Enum.GetValues(typeof(BE.LOCATION));
            typeComboBox.ItemsSource = Enum.GetValues(typeof(BE.TYPE));
            BankName_comboBox.ItemsSource = MainWindow.bl.getBankListNames(bankList);

        }

        private void HUList_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Ok_Button.IsEnabled = true; 
        }

        private void Ok_Button_Click(object sender, RoutedEventArgs e)
        {
            hu = (BE.HostingUnit)HUList_ComboBox.SelectedItem;
            updateHU2_Border.DataContext = hu;
            updateHU1_Border.Visibility = Visibility.Collapsed;
            updateHU2_Border.Visibility = Visibility.Visible;
        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow.bl.updateHostingUnit(hu);
                MainWindow.listHU = MainWindow.bl.getHUListByID(hu.Owner.HostKey);
                MessageBox.Show("", "היחידה עודכנה בהצלחה", MessageBoxButton.OK, MessageBoxImage.Information);
                updateHU1_Border.Visibility = Visibility.Visible;
                updateHU2_Border.Visibility = Visibility.Collapsed;
                this.Close();
            }
            catch (BE.MyException exc)
            {
                MessageBox.Show("", exc.what(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception exc)
            {
                MessageBox.Show("", exc.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BankName_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bankName = (string)BankName_comboBox.SelectedItem;
            BranchNumber_comboBox.IsEnabled = true;
            BranchNumber_comboBox.ItemsSource = MainWindow.bl.getBranchListByBankName(bankList, bankName);

        }

        private void BranchNumber_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            hu.Owner.BankBranchDetails = (BE.BankBranch)BranchNumber_comboBox.SelectedItem;
        }
    }
}
