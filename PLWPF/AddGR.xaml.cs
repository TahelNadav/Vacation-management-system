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
    /// Interaction logic for AddGR.xaml
    /// </summary>
    public partial class AddGR : Window
    {
        public BE.GuestRequest gs;
        private ObservableCollection<BE.GuestRequest> listGS = new ObservableCollection<BE.GuestRequest>();
        public AddGR()
        {
            
            gs = new BE.GuestRequest();
            this.DataContext = gs;
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            entryDateDatePicker.DisplayDate = DateTime.Now;
            releaseDateDatePicker.DisplayDate = DateTime.Now;
            entryDateDatePicker.SelectedDate = DateTime.Now;
            releaseDateDatePicker.SelectedDate = DateTime.Now;
            areaComboBox.ItemsSource = Enum.GetValues(typeof(BE.LOCATION));
            areaComboBox.SelectedValue = BE.LOCATION.הכול;
            poolComboBox.ItemsSource = Enum.GetValues(typeof(BE.OPTIONS));
            poolComboBox.SelectedValue = BE.OPTIONS.אפשרי;
            childrensAttractionsComboBox.ItemsSource = Enum.GetValues(typeof(BE.OPTIONS));
            childrensAttractionsComboBox.SelectedValue = BE.OPTIONS.אפשרי;
            typeComboBox.ItemsSource = Enum.GetValues(typeof(BE.TYPE));
            typeComboBox.SelectedValue = BE.TYPE.הכול;
            

        }

        private void add_Button_Click(object sender, RoutedEventArgs e)
        {
            if (privateNameTextBox.Text.Length==0||familyNameTextBox.Text.Length == 0||mailAddressTextBox.Text.Length==0) 
            {
                MessageBox.Show("יש למלא את כל השדות", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    MainWindow.bl.addGuestRequest(gs);
                    listGS.Add(gs);
                    MessageBox.Show("בקשתך הוכנסה למערכת", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                catch (BE.MyException exc)
                {
                    MessageBox.Show(exc.what(), "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

         
    }
}
