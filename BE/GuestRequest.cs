using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   
    public class GuestRequest
    {
        private long m_GuestRequestKey;
        public long GuestRequestKey
        {
            get { return m_GuestRequestKey; }
            set { m_GuestRequestKey = value; }
        }
        private string m_PrivateName;
        public string PrivateName
        {
            get { return m_PrivateName; }
            set { m_PrivateName = value; }
        }
        private string m_FamilyName;

        public string FamilyName
        {
            get { return m_FamilyName; }
            set { m_FamilyName = value; }
        }
        private string m_MailAddress;
        public string MailAddress
        {
            get { return m_MailAddress; }
            set { m_MailAddress = value; }
        }
        private STATUS m_Status;
        public STATUS Status
        {
            get { return m_Status; }
            set { m_Status = value; }
        }
        private DateTime m_RegistrationDate;
        public DateTime RegistrationDate
        {
            get { return m_RegistrationDate; }
            set { m_RegistrationDate = value; }
        }
        private DateTime m_EntryDate;
        public DateTime EntryDate
        {
            get { return m_EntryDate; }
            set { m_EntryDate = value; }
        }
        private DateTime m_ReleaseDate;
        public DateTime ReleaseDate
        {
            get { return m_ReleaseDate; }
            set { m_ReleaseDate = value; }
        }
        private LOCATION m_Area;
        public LOCATION Area
        {
            get { return m_Area; }
            set { m_Area = value; }
        }
        private TYPE m_Type;
        public TYPE Type
        {
            get { return m_Type; }
            set { m_Type = value; }
        }
        private int m_Adults;
        public int Adults
        {
            get { return m_Adults; }
            set { m_Adults = value; }
        }
        private int m_Children;
        public int Children
        {
            get { return m_Children; }
            set { m_Children = value; }
        }
        private OPTIONS m_Pool;
        public OPTIONS Pool
        {
            get { return m_Pool; }
            set { m_Pool = value; }
        }
        private OPTIONS m_ChildrensAttractions;
        public OPTIONS ChildrensAttractions
        {
            get { return m_ChildrensAttractions; }
            set { m_ChildrensAttractions = value; }
        }
        public override string ToString()
        {
            string s = "GuestRequest Details:" + "\nGuestRequestKey:" + GuestRequestKey+"\nPrivat Name:" + PrivateName + "\nFamily Name:" + FamilyName + "\nMail Adress:" + MailAddress +           ///////////////ststus????
                "\nStatus:" + Status+"\nEntry Date:" + EntryDate.ToString("d") + "\nReleaseDate:" + ReleaseDate.ToString("d") +"\nRegistration Date:" + RegistrationDate.ToString("d") 
                + "\nArea:" + Area +"\nType:" + Type + "\nAdults:" + Adults +"\nChildren:" + Children 
                + "\npool:" + Pool +"\nchildrens Attractions:" + ChildrensAttractions;
            return s;
        }
    }
}
