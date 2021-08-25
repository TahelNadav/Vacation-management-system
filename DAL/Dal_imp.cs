//Adi Malachi 209244250
//Tahel Nadav 207816612
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace DAL
{
    public class Dal_imp : Idal
    {
        #region GuestRequest
        public void addGuestRequest(BE.GuestRequest gs)
        {
            BE.GuestRequest g = DS.DataSource.ListGuestRequest.Find(x => gs.GuestRequestKey == x.GuestRequestKey);
            if (g != null)
            {
                return;
            }
             g = gs.Clone();
            g.GuestRequestKey = Configuration.guestRequestKey++;
            DS.DataSource.ListGuestRequest.Add(g);
        }
        public void updateGuestRequest(BE.GuestRequest gs, BE.STATUS status)
        {
            BE.GuestRequest g = DS.DataSource.ListGuestRequest.Find(x => gs.GuestRequestKey == x.GuestRequestKey);
            g.Status = status;
        }
        public List<BE.GuestRequest> getAllGuests()
        {
            return DS.DataSource.ListGuestRequest.Select(item => item).ToList();
        }
        #endregion 


        #region HostingUnit
        public void addHostingUnit(BE.HostingUnit hu)
        {
            BE.HostingUnit h = DS.DataSource.ListHostingUnit.Find(x => hu.HostingUnitKey == x.HostingUnitKey);
            if (h != null)
            {
                return;
            }
            h = hu.Clone();
            h.HostingUnitKey = BE.Configuration.hostingUnitKey++;
            h.Owner.numOfHU += 1;
            DS.DataSource.ListHostingUnit.Add(h);
        }
        public void removeHostingUnit(BE.HostingUnit hu)
        {
            BE.HostingUnit h = DS.DataSource.ListHostingUnit.Find(x => hu.HostingUnitKey == x.HostingUnitKey);
            if (h ==null)      
                throw new KeyNotFoundException();
            DS.DataSource.ListHostingUnit.Remove(h);
        }
        public void updateHostingUnit(BE.HostingUnit hu)
        {

            BE.HostingUnit h = DS.DataSource.ListHostingUnit.Find(x => hu.HostingUnitKey == x.HostingUnitKey);
            h = hu.Clone();

        }
        public List<BE.HostingUnit> getAllUnits()
        {
            return DS.DataSource.ListHostingUnit.Select(item => item).ToList();
        }
        #endregion 


        #region Order
        public void addOrder(BE.Order order)
        {
            BE.Order o = DS.DataSource.ListOrder.Find(x => order.OrderKey == x.OrderKey);
            if (o != null)
            {
                return;
            }
            o = order.Clone();
            o.OrderKey = BE.Configuration.orderKey++;
            DS.DataSource.ListOrder.Add(o);
        }
        public void updateOrder(BE.Order order, BE.STATUS status)
        {
            BE.Order o = DS.DataSource.ListOrder.Find(x => order.OrderKey == x.OrderKey);
            o.Status = status;
            if (status == STATUS.אימיילנשלח)
                o.OrderDate = DateTime.Now;
        }
        public List<BE.Order> getAllOrder()
        {
            return DS.DataSource.ListOrder.Select(item => item).ToList();
        }
        #endregion


        #region BankBranch

        public List<BE.BankBranch> getAllBanksBranch()//החזרת רשימת סניפי בנק
        {
            BE.BankBranch b1 = new BE.BankBranch(), b2= new BE.BankBranch(), b3 = new BE.BankBranch(), b4 = new BE.BankBranch(),b5 = new BE.BankBranch();
            b1.BankName = "poalim";//סניף 1
            b1.BankNumber = 323;
            b1.BranchAddress = "hapoalim@gmail.com";
            b1.BranchCity = "telaviv";
            b1.BranchNumber = 035678894;
            b2.BankName = "mizrahi";//סניף 2
            b2.BankNumber = 678;
            b2.BranchAddress = "mizrahi1@gmail.com";
            b2.BranchCity = "telaviv";
            b2.BranchNumber = 036789595;
            b3.BankName = "mizrahi";//סניף 3
            b3.BankNumber = 446;
            b3.BranchAddress = "mizrahi2@gmail.com";
            b3.BranchCity = "haifa";
            b3.BranchNumber = 045678432;
            b4.BankName = "leumi";//סניף 4
            b4.BankNumber = 534;
            b4.BranchAddress = "leumi@gmail.com";
            b4.BranchCity = "ramathasharon";
            b4.BranchNumber = 035466789;
            b5.BankName = "yahav";//סניף 5
            b5.BankNumber = 769;
            b5.BranchAddress = "yahav@gmail.com";
            b5.BranchCity = "herzeliya";
            b5.BranchNumber = 035467894;
            List<BE.BankBranch> l = new List<BE.BankBranch>();
            l.Add(b1);
            l.Add(b2);
            l.Add(b3);
            l.Add(b4);
            l.Add(b5);
            return l;
        }
        #endregion

    }
}
