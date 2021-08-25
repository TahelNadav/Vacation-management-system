using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BankBranch
    {
        private int m_BankNumber;
        public int BankNumber
        {
            get { return m_BankNumber; }
            set { m_BankNumber = value; }
        }
        private string m_BankName;
        public string BankName
        {
            get { return m_BankName; }
            set { m_BankName = value; }
        }
        private int m_BranchNumber;
        public int BranchNumber
        {
            get { return m_BranchNumber; }
            set { m_BranchNumber = value; }
        }
        private string m_BranchAddress;
        public string BranchAddress
        {
            get { return m_BranchAddress; }
            set { m_BranchAddress = value; }
        }
        private string m_BranchCity;
        public string BranchCity
        {
            get { return m_BranchCity; }
            set { m_BranchCity = value; }
        }
        public override string ToString()
        {
            string s = "\n  BankNumber:" + BankNumber+ "\n  BankName:" + BankName + "\n  BranchNumber:" + BranchNumber +
                "\n  BranchAddress:" + BranchAddress + "\n  Branch City:" + BranchCity;
            return s;
        }
    }
}
