using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Net.Mail;
using System.Threading;

namespace BL
{
    class BL_imp : IBL
    {
        DAL.Idal dal;
        Thread t;
        public BL_imp()
        {
            dal = DAL.FactoryDal.GetXMLDAL();
            t = new Thread(updateExpireOrder);
            t.Start();
            
        }
        
        #region GuestRequest
        public void addGuestRequest(GuestRequest gs)
        {
            int duration;
            duration = getDuration(gs.EntryDate, gs.ReleaseDate);
            if (duration < 1)
                throw new BE.unvalidDates();
            duration = getDuration(DateTime.Now, gs.EntryDate);
            if (duration < 0)
                throw new BE.exception("יש לבחור תאריך החל מיום הבא ואילך"); ;
            dal.addGuestRequest(gs);

        }

        public void updateGuestRequest(BE.GuestRequest gs, STATUS status)
        {
            List<GuestRequest> l = dal.getAllGuests();
            GuestRequest g = l.Find(x => gs.GuestRequestKey == x.GuestRequestKey);
            if (g == null)
                throw new BE.exception("בקשת אירוח לא נמצאה");
            dal.updateGuestRequest(gs, status);

        }
        public List<BE.GuestRequest> getAllGuests()
        {
            return dal.getAllGuests();
        }
        public GuestRequest getGRByOrder(Order or)
        {
            List<GuestRequest> l = dal.getAllGuests();
            return l.Find(x => or.GuestRequestKey == x.GuestRequestKey);
        }
        public int getDuration(DateTime start, DateTime end)
        {
            if (end == null)
                end = DateTime.Now;
            return (end - start).Days;
        }
        public List<GuestRequest> findMatchGR(Predicate<GuestRequest> p)
        {
            List<GuestRequest> l = getAllGuests();
            return l.FindAll(p);
        }
        public List<IGrouping<LOCATION, GuestRequest>> GROrderByLocation()
        {
            List<GuestRequest> l = getAllGuests();
            var groups = l.GroupBy(s => s.Area);
            return groups.ToList();
        }
        public List<IGrouping<int, GuestRequest>> GROrderByNumOfVacationers()
        {
            List<GuestRequest> l = getAllGuests();
            var groups = l.GroupBy(s => s.Adults + s.Children);
            return groups.ToList();
        }
        public List<GuestRequest> GetGRByLocation( LOCATION location ,List<GuestRequest> l)
        {
            
            var v =
               from GuestRequest item in l
               let b = item.Area
               where b == location
               select item;
            return v.ToList();
        }
        public List<GuestRequest> GetGRByType(TYPE t,List<GuestRequest> l)
        {
             
            var v =
               from GuestRequest item in l
               let b = item.Type
               where b == t
               select item;
            return v.ToList();
        }
        public List<GuestRequest> GetGRByStatus(STATUS s, List<GuestRequest> l)
        {
            
            var v =
               from GuestRequest item in l
               let b = item.Status
               where b == s
               select item;
            return v.ToList();
        }
        public List<GuestRequest> GetGRByPool(OPTIONS p, List<GuestRequest> l)
        {
            
            var v =
               from GuestRequest item in l
               let b = item.Pool
               where b == p
               select item;
            return v.ToList();
        }
        public List<GuestRequest> GetGRByFM(string s,List<GuestRequest> l)
        {
            
            var v =
               from GuestRequest item in l
               let b = item.FamilyName
               where b == s
               select item;
            return v.ToList();
        }
         
        #endregion


        #region HostingUnit
        public void addHostingUnit(BE.HostingUnit hu)
        {
            dal.addHostingUnit(hu);
        }
        public void removeHostingUnit(BE.HostingUnit hu)
        {
            if (openOrders(hu) == 0)
                dal.removeHostingUnit(hu);
            else
                throw new BE.thereIsOpenOrder();
            return;
        }
        public void updateHostingUnit(BE.HostingUnit hu)
        {
            List<HostingUnit> l = dal.getAllUnits();
            HostingUnit h = l.Find(x => hu.HostingUnitKey == x.HostingUnitKey);
            if (h == null)
                throw new BE.exception("Hosting Unit doesn't exsit");
            if (hu.Owner.CollectionClearance == false)
                if (h.Owner.CollectionClearance == true && orderInProcesses(hu))
                    throw new BE.thereIsOpenOrder();

            dal.updateHostingUnit(hu);

        }
        public List<BE.HostingUnit> getAllUnits()
        {
            return dal.getAllUnits();
        }
        public bool HostingUnitNotOccupied(HostingUnit hu, DateTime d, int duration)
        {
            for (int i = duration; i > 0; i--)
            {
                if (hu[d])
                    return false;
                d = d.AddDays(1);
            }
            return true;
        }
        public void fillDatesAndUpdateStatus(Order or)
        {
            HostingUnit hu = getHUByOrder(or);
            GuestRequest gs = getGRByOrder(or);
            int duration = getDuration(gs.EntryDate, gs.ReleaseDate);
            DateTime d = gs.EntryDate;
            for (int i = duration; i > 0; i--)
            {
                hu[d] = true;
                d = d.AddDays(1);
            }
            dal.updateHostingUnit(hu);
            dal.updateGuestRequest(gs, STATUS.נסגרה);
        }
        public List<HostingUnit> getPossibleHU(DateTime d, int duration)
        {
            List<HostingUnit> l = dal.getAllUnits();
            var v =
                from HostingUnit item in l
                let b = HostingUnitNotOccupied(item, d, duration)
                where b == true
                select item;
            return v.ToList();

        }
        public HostingUnit getHUByOrder(Order or)
        {
            List<HostingUnit> l = dal.getAllUnits();
            return l.Find(x => or.HostingUnitKey == x.HostingUnitKey);
        }
        public List<IGrouping<LOCATION, HostingUnit>> HUOrderByLocation()
        {
            List<HostingUnit> l = getAllUnits();
            var groups = l.GroupBy(s => s.location);

            return groups.ToList();
        }
        public List<HostingUnit> getHUListByID(long id)
        {
            List<HostingUnit> l = dal.getAllUnits();
            var v =
               from HostingUnit item in l
               let b = item.Owner.HostKey
               where b == id
               select item;
            return v.ToList();
        }
        public List<HostingUnit> getHUByLocation(LOCATION location, List<HostingUnit> l)
        {
            return l.Where(x => x.location == location).Select(x => x).ToList();
        }
        public List<HostingUnit> getHUByType(TYPE t, List<HostingUnit> l)
        {
            return l.Where(x => x.type == t).Select(x => x).ToList();
        }
        public List<HostingUnit> getHUByPool(bool b, List<HostingUnit> l)
        {
            return l.Where(x => x.Pool == b).Select(x => x).ToList();
        }
        public List<HostingUnit> getHUByChildrenA(bool b, List<HostingUnit> l)
        {
            return l.Where(x => x.ChildrensAttractions == b).Select(x => x).ToList();
        }
        public List<HostingUnit> getHUByName(string s, List<HostingUnit> l)
        {
            return l.Where(x => x.HostingUnitName == s).Select(x => x).ToList();
        }

        #endregion


        #region Order
        public void addOrder(BE.Order or)
        {

            GuestRequest gs = getGRByOrder(or);
            HostingUnit hu = getHUByOrder(or);
            int duration = getDuration(gs.EntryDate, gs.ReleaseDate);
            bool b = HostingUnitNotOccupied(hu, gs.EntryDate, duration);
            if (b)
            {
                or.Status = STATUS.בתהליך;
                or.CreateDate = DateTime.Now;
                dal.addOrder(or);
            }
            else
                throw new BE.occupideDates();
        }
        public void updateOrder(BE.Order or, STATUS status)
        {
            List<Order> orders = dal.getAllOrder();
            if (orders.Find(x => or.OrderKey == x.OrderKey) == null)
                throw new BE.exception("order doesn't exsit");
            if (or.Status == STATUS.נסגרה|| or.Status == STATUS.בוטלה)
                throw new BE.theOrderIsDone();
            switch (status)
            {
                case STATUS.בתהליך:
                    dal.updateOrder(or, status);
                    break;
                case STATUS.נסגרה:
                    fillDatesAndUpdateStatus(or);
                    Configuration.profit += calculateFee(or);
                    CanceleOrders(or);
                    break;
                case STATUS.בוטלה:
                    dal.updateOrder(or, status);
                    break;
                case STATUS.אימיילנשלח:
                    if (or.Status != STATUS.אימיילנשלח)
                    {
                        if (getHUByOrder(or).Owner.CollectionClearance)
                        {
                            dal.updateOrder(or, status);
                            MailMessage mail = new MailMessage();
                            string key = getGRByOrder(or).MailAddress;
                            mail.To.Add(key);
                            mail.From = new MailAddress("leshemvacations@gmail.com");

                            mail.Subject = "שליחת מייל";

                            mail.Body = "שלום,זוהי הצעה המתאימה עבורך יחידה  ";
                            mail.IsBodyHtml = true;
                            SmtpClient smtp = new SmtpClient();
                            smtp.Host = "smtp.gmail.com";
                            smtp.Credentials = new System.Net.NetworkCredential("leshemvacations@gmail.com", "leshem0000");
                            smtp.EnableSsl = true;
                            try
                            {
                                smtp.Send(mail);
                            }
                            catch (Exception exc)
                            {
                                throw new Exception();

                            }
                        }
                        else
                            throw new BE.noCollectionClearance();
                        break;
                    }
                    else
                        break;
            }

        }
        public List<BE.Order> getAllOrder()
        {
            return dal.getAllOrder();
        }
        public int openOrders(HostingUnit hu)
        {
            List<Order> orders = new List<Order>();
            orders = dal.getAllOrder();
            var v = from item in orders
                    let key = item.HostingUnitKey
                    where ((key == hu.HostingUnitKey) && (item.Status == STATUS.בתהליך || item.Status == STATUS.אימיילנשלח))
                    select item;

            return v.Count();
        }
        public List<Order> getOrderByGR(long GRKey)
        {
            List<Order> l = dal.getAllOrder();
            var v =
                from Order item in l
                let b = item.GuestRequestKey
                where b == GRKey
                select item;
            return v.ToList();
        }
        public int numOfOrdersByGR(GuestRequest gs)
        {
            return getOrderByGR(gs.GuestRequestKey).Count();
        }
        public void CanceleOrders(Order or)
        {
            List<Order> l = getOrderByGR(or.GuestRequestKey);
            foreach (Order item in l)
            {
                if ((item.GuestRequestKey == or.GuestRequestKey) && (item.Status != STATUS.נסגרה))
                    dal.updateOrder(item, STATUS.בוטלה);

            }
        }
        public int orderOfHU(HostingUnit hu)
        {
            List<Order> l = getAllOrder();
            var v =
                from Order item in l
                where (item.HostingUnitKey == hu.HostingUnitKey) && (item.Status == STATUS.אימיילנשלח || item.Status == STATUS.נסגרה)
                select item;
            return v.Count();
        }
        public bool orderInProcesses(HostingUnit hu)
        {
            List<Order> l = getAllOrder();
            var v =
                from Order item in l
                where (item.HostingUnitKey == hu.HostingUnitKey) && (item.Status == STATUS.אימיילנשלח || item.Status == STATUS.בתהליך)
                select item;
            return v.Count() != 0;
        }
        public List<Order> oldOrders(int days)
        {
            List<Order> l = getAllOrder();
            var v =
                from Order item in l
                let d1 = (item.OrderDate - DateTime.Now).Days
                let d2 = (item.CreateDate - DateTime.Now).Days
                where (d1 > days) || (item.OrderDate==null&&(d2 > days))
                select item;
            return v.ToList();
        }
        public List<Order> getOrdersByHostId(long id,List<Order> l)
        {
            return l.Where(x=> x.HostId == id).Select(x=>x).ToList();
        }
        public List<Order> getOrdersByStatus(STATUS s, List<Order> l)
        {
            return l.Where(x => x.Status == s).Select(x => x).ToList();
        }

        public Order getOrderByGRHU(long GRKey, long HUNum)
        {
            List<Order> l = getOrderByGR(GRKey);

            Order result = l.Where(x => x.HostingUnitKey == HUNum).FirstOrDefault();

            return result;

        }
        public void updateExpireOrder() 
        {
            while (true) {
                List<Order> l = oldOrders(30);
                foreach (Order or in l)
                {
                    updateOrder(or, STATUS.בוטלה);
                }
                Thread.Sleep(86400000);
            }
        }
        #endregion


        #region BankBranch
        public List<string> getBankListNames(List<BankBranch> l)
        {
            List<string> listNames = new List<string>();
            foreach (BankBranch bank in l)
            {
                bool b = true;
                if (l != null)
                {
                    foreach (string name in listNames)
                    {
                        if (name == bank.BankName)
                            b = false;
                    }
                }
                if (b)
                    listNames.Add(bank.BankName);
            }
            return listNames;
        }
        public List<BankBranch> getBranchListByBankName(List<BankBranch> l, string name)
        {
            return l.Where(x => x.BankName == name).Select(x => x).ToList();
        }
        #endregion


        #region siteManager

        public float calculateFee(Order or)
        {
            GuestRequest gs = getGRByOrder(or);

            return Configuration.fee * getDuration(gs.EntryDate, gs.ReleaseDate);
        }
        #endregion


        #region Host
        public List<IGrouping<int, Host>> HostOrderByNumOfHU()
        {
            List<Host> l = getHostList(getAllUnits());
            var groups = l.GroupBy(s => s.numOfHU);
            return groups.ToList();
        }
        public List<Host> getHostList(List<HostingUnit> hu)
        {
            List<Host> l = new List<Host>();
            foreach (HostingUnit h in hu)
            {
                bool b = true;
                if (l != null)
                {
                    foreach (Host host in l)
                    {
                        if (h.Owner.HostKey == host.HostKey)
                            b = false;
                    }
                }
                if (b)
                    l.Add(h.Owner);
            }
            return l;

        }
        public List<Host> getHostByFM(string s ,List<Host> l)
        {
            return l.Where(x=> x.FamilyName==s).Select(x=>x).ToList();
        }
        public List<Host> getHostById(long id, List<Host> l)
        {
            return l.Where(x => x.HostKey == id).Select(x => x).ToList();
        }
        public List<Host> getHostByNumOfHU(int num, List<Host> l)
        {
            return l.Where(x => x.numOfHU == num).Select(x => x).ToList();
        }
        #endregion
    }
}