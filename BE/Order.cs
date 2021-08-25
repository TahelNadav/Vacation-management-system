using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{

    public class Order
    {
        private long m_HostingUnitKey;
        public long HostingUnitKey
        {
            get { return m_HostingUnitKey; }
            set { m_HostingUnitKey = value; }
        }
        private long m_GuestRequestKey;
        public long GuestRequestKey
        {
            get { return m_GuestRequestKey; }
            set { m_GuestRequestKey = value; }
        }
        private long m_OrderKey;
        public long OrderKey
        {
            get { return m_OrderKey; }
            set { m_OrderKey = value; }
        }
        private long m_HostId;
        public long HostId
        {
            get { return m_HostId; }
            set { m_HostId = value; }
        }
        private STATUS m_Status;
        public STATUS Status
        {
            get { return m_Status; }
            set { m_Status = value; }
        }
        private DateTime m_CreateDate;
        public DateTime CreateDate
        {
            get { return m_CreateDate; }
            set { m_CreateDate = value; }
        }
        private DateTime m_OrderDate;
        public DateTime OrderDate
        {
            get { return m_OrderDate; }
            set { m_OrderDate = value; }
        }
        public override string ToString()
        {
            string s = "Order Details:"+"\nOrderKey:" + OrderKey + "\nHostingUnit Key:" + HostingUnitKey + "\nGuestRequest Key:" + GuestRequestKey
                +  "\nStatus:" + Status+ "\nCreate Date:" + CreateDate.ToString("d")
            +"\nOrder Date:" + OrderDate.ToString("d");
            return s;
        }
    }
}
