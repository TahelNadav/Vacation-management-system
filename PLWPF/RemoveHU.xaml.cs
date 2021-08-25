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
    /// Interaction logic for RemoveHU.xaml
    /// </summary>
    public partial class RemoveHU : Window
    {
        BE.HostingUnit hu = new BE.HostingUnit();
        ObservableCollection<BE.HostingUnit> listHU;
        public RemoveHU(List<BE.HostingUnit> list)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            listHU = new ObservableCollection<BE.HostingUnit>(list);
            HU_ComboBox.ItemsSource = listHU;
        }

        private void Remove_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                hu = (BE.HostingUnit)HU_ComboBox.SelectedItem;
                MainWindow.bl.removeHostingUnit(hu);
                MainWindow.listHU = MainWindow.bl.getHUListByID(hu.Owner.HostKey);
                MessageBox.Show("","היחידה הוסרה ", MessageBoxButton.OK, MessageBoxImage.Information);
                Remove_Button.IsEnabled = false;
                this.Close();
            }
            catch (BE.MyException exc)
            {
                MessageBox.Show(exc.what(), "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void HU_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Remove_Button.IsEnabled = true;
        }
    }
}
