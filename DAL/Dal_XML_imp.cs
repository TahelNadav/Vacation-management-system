using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using BE;
using DS;

namespace DAL
{
    public class Dal_XML_imp :Idal
    {
        XElement orderRoot;
        XElement configRoot;

        string configPath = @"config.xml";
        string guestRequestPath = @"guestRequest.xml";
        string hostingUnitPath = @"hostingUnit.xml";
        string orderPath = @"order.xml";

        public Dal_XML_imp()
        {
            if (!File.Exists(orderPath))
                CreateFilesOrder();
            else
                LoadDataOrder();

            if (!File.Exists(configPath))
                CreateFilesCode();
            else
                LoadDataCode();

            if (!File.Exists(hostingUnitPath))
            {
                FileStream fileHostingUnit = new FileStream(hostingUnitPath, FileMode.Create);

                fileHostingUnit.Close();
            }
            else
                DataSource.ListHostingUnit = (loadListFromXML<HostingUnit>(hostingUnitPath));

            if (!File.Exists(guestRequestPath))
            {
                FileStream fileGuestRequest = new FileStream(guestRequestPath, FileMode.Create);
                fileGuestRequest.Close();
            }
            else
                DataSource.ListGuestRequest = (loadListFromXML<GuestRequest>(guestRequestPath));

            saveListToXML<HostingUnit>(DataSource.ListHostingUnit, hostingUnitPath);
            saveListToXML<GuestRequest>(DataSource.ListGuestRequest, guestRequestPath);
        }

        private void LoadDataCode()
        {
            try
            {
                configRoot = XElement.Load(configPath);
            }
            catch
            {
                throw new exception("File upload problem");
            }
        }

        private void LoadDataOrder()
        {
            try
            {
                orderRoot = XElement.Load(orderPath);
            }
            catch
            {
                throw new exception("File upload problem");
            }
        }

        private void CreateFilesOrder()
        {
            orderRoot = new XElement("orders");
            orderRoot.Save(orderPath);
        }

        public static void saveListToXML<T>(List<T> list, string Path)
        {
            FileStream file = new FileStream(Path, FileMode.Create);
            XmlSerializer x = new XmlSerializer(list.GetType());
            x.Serialize(file, list);
            file.Close();
        }

        public static List<T> loadListFromXML<T>(string path)
        {
            if (File.Exists(path))
            {
                List<T> list;
                XmlSerializer x = new XmlSerializer(typeof(List<T>));
                FileStream file = new FileStream(path, FileMode.Open);
                list = (List<T>)x.Deserialize(file);
                file.Close();
                return list;
            }
            else return new List<T>();
        }

        private void CreateFilesCode()
        {
            XElement guestRequestKey = new XElement("GuestRequestKey", "00000001");
            XElement hostingKey = new XElement("HostingUnitKey", "00000001");
            XElement orderKey = new XElement("OrderKey", "00000001");
            configRoot = new XElement("Config", guestRequestKey, hostingKey, orderKey);
            configRoot.Save(configPath);
        }

        #region GuestRequest
        public void addGuestRequest(BE.GuestRequest gs)
        {
            LoadDataCode();
            long guestKey = long.Parse(configRoot.Element("GuestRequestKey").Value);
            DataSource.ListGuestRequest =  loadListFromXML<GuestRequest>(guestRequestPath);
            BE.GuestRequest g = DataSource.ListGuestRequest.Find(x => gs.GuestRequestKey == x.GuestRequestKey);
            if (g != null)
            {
                return;
            }
            g = gs.Clone();
            g.GuestRequestKey = guestKey++;
            DataSource.ListGuestRequest.Add(g);
            saveListToXML<GuestRequest>(DataSource.ListGuestRequest, guestRequestPath);
            configRoot.Element("GuestRequestKey").Value = guestKey.ToString();
            configRoot.Save(configPath);
        }
        public void updateGuestRequest(BE.GuestRequest gs, BE.STATUS status)
        {
            DataSource.ListGuestRequest = loadListFromXML<GuestRequest>(guestRequestPath);
            GuestRequest g = DataSource.ListGuestRequest.Find(x => gs.GuestRequestKey == x.GuestRequestKey);
            g.Status = status;
            saveListToXML<GuestRequest>(DataSource.ListGuestRequest, guestRequestPath);
        }
        public List<BE.GuestRequest> getAllGuests()
        {
            DataSource.ListGuestRequest = loadListFromXML<GuestRequest>(guestRequestPath);
            return DataSource.ListGuestRequest.Select(item => item).ToList();
        }
        #endregion 


        #region HostingUnit
        public void addHostingUnit(BE.HostingUnit hu)
        {
            LoadDataCode();
            long hostingKey = long.Parse(configRoot.Element("HostingUnitKey").Value);
            DataSource.ListHostingUnit = loadListFromXML<HostingUnit>(hostingUnitPath);
            BE.HostingUnit h = DataSource.ListHostingUnit.Find(x => hu.HostingUnitKey == x.HostingUnitKey);
            if (h != null)
            {
                return;
            }
            h = hu.Clone();
            h.HostingUnitKey = hostingKey++;
            h.Owner.numOfHU += 1;
            DS.DataSource.ListHostingUnit.Add(h);
            saveListToXML<HostingUnit>(DataSource.ListHostingUnit, hostingUnitPath);
            configRoot.Element("HostingUnitKey").Value = hostingKey.ToString();
            configRoot.Save(configPath);
        }
        public void removeHostingUnit(BE.HostingUnit hu)
        {
            DataSource.ListHostingUnit = loadListFromXML<HostingUnit>(hostingUnitPath);
            HostingUnit h = DataSource.ListHostingUnit.Find(x => hu.HostingUnitKey == x.HostingUnitKey);
            if (h == null)
                throw new KeyNotFoundException();
            DS.DataSource.ListHostingUnit.Remove(h);
            saveListToXML<HostingUnit>(DataSource.ListHostingUnit, hostingUnitPath);
        }
        public void updateHostingUnit(BE.HostingUnit hu)
        {
            DataSource.ListHostingUnit = loadListFromXML<HostingUnit>(hostingUnitPath);
            HostingUnit h = DataSource.ListHostingUnit.Find(x => hu.HostingUnitKey == x.HostingUnitKey);
            h = hu.Clone();
            saveListToXML<HostingUnit>(DataSource.ListHostingUnit, hostingUnitPath);
        }
        public List<HostingUnit> getAllUnits()
        {
            DataSource.ListHostingUnit = loadListFromXML<HostingUnit>(hostingUnitPath);
            return DataSource.ListHostingUnit.Select(item => item).ToList();
        }
        #endregion 


        #region Order
       
        public void getOrdersList()
        {
            LoadDataOrder();
            List<Order> orders;
            try
            {
                orders = (from p in orderRoot.Elements()
                          select new Order()
                          {
                              HostingUnitKey = Convert.ToInt64(p.Element("HostingUnitKey").Value),
                              GuestRequestKey = Convert.ToInt64(p.Element("GuestRequestKey").Value),
                              OrderKey = Convert.ToInt64(p.Element("OrderKey").Value),
                              HostId = Convert.ToInt64(p.Element("HostId").Value),
                              Status = (STATUS) Enum.Parse(typeof(STATUS),p.Element("Status").Value),
                              CreateDate = DateTime.Parse( p.Element("CreateDate").Value),
                              OrderDate = DateTime.Parse(p.Element("OrderDate").Value)
                              
                          }).ToList();
            }
            catch
            {
                orders = null;
            }
            DataSource.ListOrder = orders;
        }
        public void saveOrderList(List<Order> orders)
        {
            orderRoot = new XElement("Orders",
            from p in orders
            select new XElement("order",
            new XElement("HostingUnitKey", p.HostingUnitKey),
            new XElement("GuestRequestKey", p.GuestRequestKey),
            new XElement("OrderKey", p.OrderKey),
            new XElement("HostId", p.HostId),
            new XElement("Status", p.Status),
            new XElement("CreateDate", p.CreateDate),
            new XElement("OrderDate", p.OrderDate)
            
            )
            );
            orderRoot.Save(orderPath);
        }
        public void addOrder(Order order)
        {
            getOrdersList();
            LoadDataCode();
            long orderKey1 = long.Parse(configRoot.Element("OrderKey").Value);
            Order o = DS.DataSource.ListOrder.Find(x => order.OrderKey == x.OrderKey);
            if (o != null)
            {
                return;
            }
            o = order.Clone();
            o.OrderKey = orderKey1++;
            DS.DataSource.ListOrder.Add(o);
            configRoot.Element("OrderKey").Value = orderKey1.ToString();
            configRoot.Save(configPath);
            saveOrderList(DataSource.ListOrder);
        }
        public void updateOrder(Order order, STATUS status)
        {
            getOrdersList();
            BE.Order o = DS.DataSource.ListOrder.Find(x => order.OrderKey == x.OrderKey);
            o.Status = status;
            if (status == STATUS.אימיילנשלח)
                o.OrderDate = DateTime.Now;
            saveOrderList(DataSource.ListOrder);
        }
        public List<BE.Order> getAllOrder()
        {
            getOrdersList();
            return DS.DataSource.ListOrder.Select(item => item).ToList();
        }
        #endregion


         


    }
}
