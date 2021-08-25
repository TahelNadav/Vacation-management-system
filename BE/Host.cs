using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class Host
    {
        private long m_HostKey;
        public long HostKey
        {
            get { return m_HostKey; }
            set { m_HostKey = value; }
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
        private long m_FhoneNumber;
        public long FhoneNumber
        {
            get { return m_FhoneNumber; }
            set { m_FhoneNumber = value; }
        }
        private string m_MailAddress;
        public string MailAddress
        {
            get { return m_MailAddress; }
            set { m_MailAddress = value; }
        }
        private BankBranch m_BankBranchDetails;
        public BankBranch BankBranchDetails
        {
            get { return m_BankBranchDetails; }
            set { m_BankBranchDetails = value; }
        }
        private long m_BankAccountNumber;
        public long BankAccountNumber
        {
            get { return m_BankAccountNumber; }
            set { m_BankAccountNumber = value; }
        }
        private bool m_CollectionClearance;
        public bool CollectionClearance
        {
            get { return m_CollectionClearance; }
            set { m_CollectionClearance = value; }
        }
        private int m_numOfHU = 0;
        public int numOfHU
        {
            get { return m_numOfHU; }
            set { m_numOfHU = value; }
        }
        
        public override string ToString()
        {
            string s = "\n HostKey:" + HostKey+ "\n Private Name:" + PrivateName+ "\n Family Name:" + FamilyName+ "\n Fhone Number:" + FhoneNumber+
                "\n Mail Address:" + MailAddress+"NumOfHostingUnit\n"+ numOfHU+ "\n Bank Account Number:" + BankAccountNumber+ "\n Collection Clearance:" + CollectionClearance+ "\n Bank Branch Details:" + BankBranchDetails.ToString();
            return s;
        }

    }
}
