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
    /// Interaction logic for AddHU.xaml
    /// </summary>
    public partial class AddHU : Window
    {
        
        BE.HostingUnit hu;
        BE.Host host;
       List<BE.BankBranch> bankList = new List<BE.BankBranch>();
        string bankName;

        public AddHU(long id, List<BE.BankBranch> l)
        {
            hu = new BE.HostingUnit();
            host = new BE.Host();
            host.HostKey = id;
            bankList = l;
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            grid1.DataContext = hu;
            grid2.DataContext = host;
            BankName_comboBox.ItemsSource = MainWindow.bl.getBankListNames(l);
            typeComboBox.ItemsSource = Enum.GetValues(typeof(BE.TYPE));
            locationComboBox.ItemsSource = Enum.GetValues(typeof(BE.LOCATION));
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(privateNameTextBox.Text.Length == 0||familyNameTextBox.Text.Length==0||mailAddressTextBox.Text.Length==0||
                fhoneNumberTextBox.Text.Length!=10||bankAccountNumberTextBox.Text.Length==0||hostingUnitNameTextBox.Text.Length==0)
            {
                MessageBox.Show(" שים לב  מספר טלפון צריך להכיל 10 תווים  \nיש למלא את כל השדות כרצוי  ", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    hu.Owner = host;
                    hu.Owner.BankBranchDetails = (BE.BankBranch)BranchNumber_comboBox.SelectedItem;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
                    MainWindow.bl.addHostingUnit(hu);
                    MainWindow.listHU = MainWindow.bl.getHUListByID(host.HostKey);
                    MessageBox.Show("יחידת האירוח נוספה בהצלחה", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                }
               
            }
        }

        private void BankName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bankName = (string)BankName_comboBox.SelectedItem;
            BranchNumber_comboBox.IsEnabled = true;
            BranchNumber_comboBox.ItemsSource = MainWindow.bl.getBranchListByBankName(bankList, bankName);

        }
    }
}
