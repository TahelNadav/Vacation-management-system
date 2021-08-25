using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public static bool bankListready = false,loadBanksWorkerIsDone = false;
        public List<BE.BankBranch> bankList = new List<BE.BankBranch>();
        BackgroundWorker loadBanksWorker;
        public static List<BE.HostingUnit> listHU;
        public static BL.IBL bl = BL.FactoryBL.GetBL();

        public MainWindow()
        {
            InitializeComponent();
            loadBanksWorker = new BackgroundWorker();
            loadBanksWorker.DoWork += LoadBanksWorker_DoWork;
            loadBanksWorker.ProgressChanged += LoadBanksWorker_ProgressChanged;
            loadBanksWorker.RunWorkerCompleted += LoadBanksWorker_RunWorkerCompleted;
            loadBanksWorker.WorkerReportsProgress = true;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            listHU = new List<BE.HostingUnit>();
            HU_ListView.ItemsSource = listHU;
            Fee_TextBlock.Text = BE.Configuration.fee.ToString();
            Profit_TextBlock.Text = BE.Configuration.profit.ToString();
            NumOfHU_TextBlock.Text = MainWindow.bl.getAllUnits().Count().ToString();
            NumofHost_TextBlock.Text = MainWindow.bl.getHostList(MainWindow.bl.getAllUnits()).Count().ToString();
            NumOfOrders_TextBlock.Text = MainWindow.bl.getAllOrder().Count().ToString();
        }

        private void LoadBanksWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
             
        }

        private void LoadBanksWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (bankListready)
            {
                string path = @"atm.xml";
                XElement bankRoot = XElement.Load(path);
                bankList = (from p in bankRoot.Elements() select new BE.BankBranch() 
                {
                    BankNumber = Convert.ToInt32(p.Element("קוד_בנק").Value),
                    BankName = (p.Element("שם_בנק").Value), 
                    BranchNumber = Convert.ToInt32(p.Element("קוד_סניף").Value),
                    BranchAddress = (p.Element("כתובת_ה-ATM").Value),
                    BranchCity = (p.Element("ישוב").Value)
                }).ToList();
                loadBanksWorkerIsDone = true;
            }
        }

        private void LoadBanksWorker_DoWork(object sender, DoWorkEventArgs e)
        {
           
            const string xmlLocalPath = @"atm.xml";
            WebClient wc = new WebClient();
            
                try
                {
                    string xmlServerPath = @"http://www.boi.org.il/he/BankingSupervision/BanksAndBranchLocations/Lists/BoiBankBranchesDocs/at m.xml";
                    wc.DownloadFile(xmlServerPath, xmlLocalPath);
                    bankListready = true;
                }
                catch (Exception)
                {
                  try
                  {
                    MessageBox.Show("בעיה בטעינת הנתונים מהרשת , המערכת תיטען את הנתונים ממקור מקומי", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    string xmlServerPath = @"http://www.jct.ac.il/~coshri/atm.xml";
                    wc.DownloadFile(xmlServerPath, xmlLocalPath);
                    bankListready = true;
                  }
                  catch (Exception)
                  {
                    throw new Exception();
                  }
                }
                finally
                {
                    wc.Dispose();
                }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            hostId_TextBlock.Text = "";
            managerPassword.Password = "";
            TabControl tabControl = sender as TabControl;
            try
            {
                if (tabControl.SelectedIndex == 1)
                {
                    borderHost2.Visibility = Visibility.Collapsed;
                    borderHost1.Visibility = Visibility.Visible;
                    borderManager2.Visibility = Visibility.Collapsed;
                    borderManager1.Visibility = Visibility.Visible;
                }
                if (tabControl.SelectedIndex == 2)
                {
                    borderHost2.Visibility = Visibility.Collapsed;
                    borderHost1.Visibility = Visibility.Visible;
                    NumOfHU_TextBlock.Text = MainWindow.bl.getAllUnits().Count().ToString();
                    NumofHost_TextBlock.Text = MainWindow.bl.getHostList(MainWindow.bl.getAllUnits()).Count().ToString();
                    NumOfOrders_TextBlock.Text = MainWindow.bl.getAllOrder().Count().ToString();
                }
                if (tabControl.SelectedIndex == 3)
                {
                    borderManager2.Visibility = Visibility.Collapsed;
                    borderManager1.Visibility = Visibility.Visible;
                }
                if (tabControl.SelectedIndex == 4)
                {
                    borderHost2.Visibility = Visibility.Collapsed;
                    borderHost1.Visibility = Visibility.Visible;
                    borderManager2.Visibility = Visibility.Collapsed;
                    borderManager1.Visibility = Visibility.Visible;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
    
        #region SiteManager
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (managerPassword.Password != BE.Configuration.password)
            {
                MessageBox.Show("סיסמא שגויה", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                managerPassword.Password = "";
            }
            else
            {
                managerPassword.Password = "";
                borderManager1.Visibility = Visibility.Collapsed;
                borderManager2.Visibility = Visibility.Visible;
            }
        }

        private void changePassword_Button_Click(object sender, RoutedEventArgs e)
        {
            ChangePassword changePassword = new ChangePassword();
            changePassword.ShowDialog();
        }

        private void changeFee_Button_Click(object sender, RoutedEventArgs e)
        {
            ChangeFee changeFee = new ChangeFee();
            changeFee.ShowDialog();
            Fee_TextBlock.Text = BE.Configuration.fee.ToString();

        }
        private void order_Button_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            order.ShowDialog();
        }
        private void GR_Button_Click(object sender, RoutedEventArgs e)
        {
            GuestRequest gs = new GuestRequest();
            gs.ShowDialog();
        }
        private void HU_Button_Click(object sender, RoutedEventArgs e)
        {
            HostingUnit hostingUnit = new HostingUnit();
            hostingUnit.ShowDialog();
        }
        private void Host_Button_Click(object sender, RoutedEventArgs e)
        {
            Host host = new Host();
            host.ShowDialog();
        }
        #endregion
        #region Host
        private void hostId_Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                long id = long.Parse(hostId_TextBlock.Text);
                if (hostId_TextBlock.Text.Length != 9 || hostpassword_Textbox.Password != BE.Configuration.hostPassword)
                    throw new Exception();

                borderHost1.Visibility = Visibility.Collapsed;
                borderHost2.Visibility = Visibility.Visible;
                listHU = bl.getHUListByID(id);
                HU_ListView.ItemsSource = listHU;
            }
            catch (Exception exc)
            {
                if (hostpassword_Textbox.Password != BE.Configuration.hostPassword)
                    MessageBox.Show("סיסמא שגויה ", "", MessageBoxButton.OK, MessageBoxImage.Error);

                else
                    MessageBox.Show("יש להכניס מספר בן 9 ספרות בלבד", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void addOrder_Button_Click(object sender, RoutedEventArgs e)
        {
            AddOrder addOrder = new AddOrder(listHU);
            addOrder.ShowDialog();
        }

        private void updateOrder_Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateOrder updateOrder = new UpdateOrder(hostId_TextBlock.Text);
            updateOrder.ShowDialog();
            Profit_TextBlock.Text = BE.Configuration.profit.ToString();
        }
        private void removeHU_Button_Click(object sender, RoutedEventArgs e)
        {
            RemoveHU removeHU = new RemoveHU(listHU);
            removeHU.ShowDialog();
            HU_ListView.ItemsSource = listHU;
        }
        private void addHU_Button_Click(object sender, RoutedEventArgs e)
        {
            
            long id = long.Parse(hostId_TextBlock.Text);
            try
            {
                loadBanksWorker.RunWorkerAsync();
                while (!loadBanksWorkerIsDone) { }
                AddHU addHU = new AddHU(id, bankList);
                addHU.ShowDialog();
                HU_ListView.ItemsSource = listHU;
            }
            catch (Exception)
            {
                MessageBox.Show(" בעיה בטעינת הנתונים, בדוק את תקינות החיבור לאינטרנט ונסה שוב ", "", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        private void updateHU_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                loadBanksWorker.RunWorkerAsync();
                while (!loadBanksWorkerIsDone) { }
                UpdateHU updateHU = new UpdateHU(listHU, bankList);
                updateHU.ShowDialog();
                HU_ListView.ItemsSource = listHU;
            }
            catch (Exception)
            {
                MessageBox.Show(" בעיה בטעינת הנתונים, בדוק את תקינות החיבור לאינטרנט ונסה שוב ", "", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

        #endregion
        #region Guest
        private void addGR_Click(object sender, RoutedEventArgs e)
        {
            AddGR addGR = new AddGR();
            addGR.ShowDialog();
        }
        #endregion
    }
}
