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
    /// Interaction logic for AddOrder.xaml
    /// </summary>
    /// 
    public partial class AddOrder : Window
    {
        BE.GuestRequest gs = new BE.GuestRequest();
        BE.HostingUnit hu = new BE.HostingUnit();
        BE.Order or  = new BE.Order();
        private List<BE.GuestRequest> GRList;
        private List<BE.HostingUnit> HUList  = new List<BE.HostingUnit>();
        public AddOrder(List<BE.HostingUnit> hu )
        {
            HUList = hu;
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            GRList =MainWindow.bl.getAllGuests();
            GR_ComboBox.ItemsSource = GRList;
            HU_ComboBox.ItemsSource = HUList;
             
        }

        private void chek_Button_Click(object sender, RoutedEventArgs e)
        {
            
            gs = (BE.GuestRequest)GR_ComboBox.SelectedItem;

            hu = (BE.HostingUnit)HU_ComboBox.SelectedItem;
            if (gs == null )
            {
                MessageBox.Show(" יש לבחור בקשת אירוח מהרשימה","", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if ( hu == null)
            {
                MessageBox.Show(" יש לבחור יחידת אירוח מהרשימה", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                int duration = MainWindow.bl.getDuration(gs.EntryDate, gs.ReleaseDate);
                if (MainWindow.bl.HostingUnitNotOccupied(hu, gs.EntryDate, duration))
                {

                    or.CreateDate = DateTime.Now;
                    or.GuestRequestKey = gs.GuestRequestKey;
                    or.HostingUnitKey = hu.HostingUnitKey;
                    or.HostId = hu.Owner.HostKey;
                    or.Status = BE.STATUS.בתהליך;
                    addOrder_Button.IsEnabled = true;
                    MessageBox.Show("נמצאה התאמה", "", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                {
                    MessageBox.Show("לא נמצאה התאמה", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void sendMail_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BE.HostingUnit h = (BE.HostingUnit)HU_ComboBox.SelectedItem;
                BE.GuestRequest g = (BE.GuestRequest)GR_ComboBox.SelectedItem;
                BE.Order or = (BE.Order)MainWindow.bl.getOrderByGRHU(g.GuestRequestKey, h.HostingUnitKey);
                MainWindow.bl.updateOrder(or, BE.STATUS.אימיילנשלח);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            this.Close();
            this.Close();
        }

        private void addOrder_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.bl.addOrder(or);
            sendMail_Button.IsEnabled = true;
            MessageBox.Show("ההזמנה נשמרה במערכת", "", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
