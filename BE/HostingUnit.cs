using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BE
{
    public class HostingUnit
    {
        private long m_HostingUnitKey;
        public long HostingUnitKey
        {
            get { return m_HostingUnitKey; }
            set { m_HostingUnitKey = value; }
        }
        private string m_HostingUnitName;
        public string HostingUnitName
        {
            get { return m_HostingUnitName; }
            set { m_HostingUnitName = value; }
        }
        private Host m_Owner;
        public Host Owner
        {
            get { return m_Owner; }
            set { m_Owner = value; }
        }
        private LOCATION m_location;
        public LOCATION location
        {
            get { return m_location; }
            set { m_location = value; }
        }
        private TYPE m_type;
        public TYPE type
        {
            get { return m_type; }
            set { m_type = value; }
        }
        private bool m_Pool;
        public bool Pool
        {
            get { return m_Pool; }
            set { m_Pool = value; }
        }
        private bool m_ChildrensAttractions;
        public bool ChildrensAttractions
        {
            get { return m_ChildrensAttractions; }
            set { m_ChildrensAttractions = value; }
        }
       
        private bool[,] m_Diary = new bool[12,31];      
        [XmlIgnore]
        public bool[,] Diary
        {
            get { return m_Diary; }
            set { m_Diary = value; }
        }
        [XmlArray("Diary")]
        public bool[] DiaryDto
        {
            get { return Diary.Flatten(); }
            set { Diary = value.Expand(12); } //5 is the number of roes in the matrix    
        } 
        public bool this[DateTime date]      //indexer,return true if aspecific day full,else return false
        {
            get
            {
                return this.Diary[date.Month - 1, date.Day - 1];
            }
            set
            {
                this.Diary[date.Month - 1, date.Day - 1] = value;
            }
        }
        public override string ToString()
        {
            string s1 = "\nOccupied dates:\n", s2;
            DateTime date1, date2,date3;
            date1 = DateTime.Now;
            date2 =date1.AddDays(1);
            date3 = date1.AddYears(1);
            while (date1!=date3)
            {
                if (this[date1])
                {

                    s1 += date1.ToString("d") + " - ";

                    while (this[date2])
                    {
                        date1 = date1.AddDays(1);
                        date2 = date2.AddDays(1);
                    }
                    s1 += date1.ToString("d") + "\n";
                }
                date1 = date1.AddDays(1);
                date2 = date2.AddDays(1);
            }
            if (s1 == "\nOccupied dates:\n")
                s1 += " 0";
            s2 = "HostingUnit Details:" + "\nHostingUnitKey:" + HostingUnitKey + "\nName:" + HostingUnitName+ "\nOwner Details:" + Owner.ToString()+
                "\ntype:"+type+"\nPool:"+Pool+ "\nChildrensAttractions:" + ChildrensAttractions+s1;
            return s2;
        }

    }
}
