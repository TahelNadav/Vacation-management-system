using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class  Cloning
    {
        public static BE.GuestRequest Clone(this BE.GuestRequest original)
        {
            BE.GuestRequest target = new BE.GuestRequest();
            target.Adults = original.Adults;
            target.Area = original.Area;
            target.Children = original.Children;
            target.ChildrensAttractions = original.ChildrensAttractions;
            target.EntryDate = original.EntryDate;
            target.FamilyName = original.FamilyName;
            target.GuestRequestKey = original.GuestRequestKey;
            target.MailAddress = original.MailAddress;
            target.Pool = original.Pool;
            target.PrivateName = original.PrivateName;
            target.RegistrationDate = original.RegistrationDate;
            target.ReleaseDate = original.ReleaseDate;
            target.Status = original.Status;
            target.Type = original.Type;
            return target;
        }
        public static BE.BankBranch Clone(this BE.BankBranch original)
        {
            BE.BankBranch target = new BE.BankBranch();
            target.BankName = original.BankName;
            target.BankNumber = original.BankNumber;
            target.BranchAddress = original.BranchAddress;
            target.BranchCity = original.BranchCity;
            target.BranchNumber = original.BranchNumber;
            return target;
        }

        public static BE.Host Clone(this BE.Host original)
        {
            BE.Host target = new BE.Host();
            target.BankAccountNumber = original.BankAccountNumber;
            target.BankBranchDetails = original.BankBranchDetails.Clone(); 
            target.CollectionClearance = original.CollectionClearance;
            target.FamilyName = original.FamilyName;
            target.FhoneNumber = original.FhoneNumber;
            target.HostKey = original.HostKey;
            target.MailAddress = original.MailAddress;
            target.PrivateName = original.PrivateName;
            target.numOfHU = original.numOfHU;
            return target;
        }
        public static BE.HostingUnit Clone(this BE.HostingUnit original)
        {
            BE.HostingUnit target = new BE.HostingUnit();
            target.location = original.location;
            target.type = original.type;
            target.Pool = original.Pool;
            target.ChildrensAttractions = original.ChildrensAttractions;
            target.Diary = original.Diary;
            target.HostingUnitKey = original.HostingUnitKey;
            target.HostingUnitName = original.HostingUnitName;
            target.Owner = original.Owner.Clone();
            return target;
        }
        
        public static BE.Order Clone(this BE.Order original)
        {
            BE.Order target = new BE.Order();
            target.CreateDate= original.CreateDate;
            target.GuestRequestKey = original.GuestRequestKey;
            target.HostingUnitKey = original.HostingUnitKey;
            target.HostId = original.HostId;
            target.OrderDate = original.OrderDate;
            target.OrderKey = original.OrderKey;
            target.Status = original.Status;
          
            return target;
        }

    }
}
