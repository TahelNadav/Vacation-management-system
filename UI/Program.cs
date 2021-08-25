//Adi Malachi 209244250
//Tahel Nadav 207816612
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace PL
{
    class Program
    {
        
        static public void printList<T>(List<T> list)// של כל איבר ברשימה שהתקבלה  ToString()   הדפסת
        {
            foreach(T item in list)
            {
                Console.WriteLine(item.ToString()+"\n");
            }
        }
        static BL.IBL bl = BL.FactoryBL.GetBL();
        static void Main(string[] args)
        {
            
            try
            {
                DateTime date =new DateTime(2020,3,4);
               
                BankBranch bank1 = new BankBranch
                { 
                    BankName = "poalim",
                    BankNumber = 323, 
                    BranchAddress = "hapoalim@gmail.com",
                    BranchCity = "telaviv",
                    BranchNumber = 035678894 
                };
                 BankBranch bank2 = new BankBranch
                {
                    BankName = "poalim",
                    BankNumber = 323,
                    BranchAddress = "hapoalim@gmail.com",
                    BranchCity = "telaviv",
                    BranchNumber = 035678894
                };
                 BankBranch bank3 = new BankBranch
                {
                    BankName = "Mizrachi",
                    BankNumber = 446,
                    BranchAddress = "Mizrachi@gmail.com",
                    BranchCity = "Hifa",
                    BranchNumber = 048765332
                };


                Host host1 = new Host 
                {
                    PrivateName = "moshe", 
                    FamilyName = "nadav",
                    MailAddress = "moshe@gmail.com", 
                    BankAccountNumber = 182938,
                    BankBranchDetails = bank1, 
                    FhoneNumber = 0508796543,
                    CollectionClearance = true,
                    HostKey = 1
                };
                 Host host2 = new Host
                {
                    PrivateName = "ori",
                    FamilyName = "shalom",
                    MailAddress = "ori@gmail.com",
                    BankAccountNumber = 182938,
                    BankBranchDetails = bank1,
                    FhoneNumber = 0556678678,
                    CollectionClearance = true,
                    HostKey = 1
                };
                  


                HostingUnit h1 = new HostingUnit
                { 
                    HostingUnitName = "h1",
                    location = LOCATION.North,
                    Owner = host1 
                };
                HostingUnit h2 = new HostingUnit
                {
                    HostingUnitName = "h2",
                    location = LOCATION.South,
                    Owner = host2
                };
                HostingUnit h2update = new HostingUnit
                {
                    HostingUnitName = "h2update",
                    location = LOCATION.South,
                    Owner = host2,
                    HostingUnitKey = 2
                };
                HostingUnit h3 = new HostingUnit
                {
                    HostingUnitName = "h3",
                    location = LOCATION.Jerusalem,
                    Owner = host2
                };


                GuestRequest guest1 = new GuestRequest
                {
                    Adults = 2,
                    Children = 3,
                    Area = LOCATION.South,
                    MailAddress = "osher@gmail.com",
                    Pool = OPTIONS.necessery,
                    EntryDate = date,
                    ReleaseDate = date.AddDays(4),
                    ChildrensAttractions = OPTIONS.necessery,
                    PrivateName = "osher",
                    FamilyName = "Cohen",
                    Status = STATUS.OnHold,
                    Type = TYPE.Hotel,
                    RegistrationDate = DateTime.Now
                };
                GuestRequest guest2 = new GuestRequest
                {
                    Adults = 4,
                    Children = 1,
                    Area = LOCATION.All,
                    MailAddress = "Dan@gmail.com",
                    Pool = OPTIONS.possible,
                    EntryDate = date.AddDays(56),
                    ReleaseDate = date.AddDays(62),
                    ChildrensAttractions = OPTIONS.noIntersted,
                    PrivateName = "Dan",
                    FamilyName = "Levi",
                    Status = STATUS.OnHold,
                    Type = TYPE.Zimmer,
                    RegistrationDate = DateTime.Now
                };


                Order order1 = new Order
                {
                    CreateDate = DateTime.Now,
                    GuestRequestKey = 1,
                    HostingUnitKey = 2,
                    Status = STATUS.OnHold
                };
                Order order2 = new Order
                {
                    CreateDate = DateTime.Now,
                    GuestRequestKey = 2,
                    HostingUnitKey = 1,
                    Status = STATUS.EmailSent
                };
               
                //add HostingUnit 
                bl.addHostingUnit(h1); 
                bl.addHostingUnit(h2); 
                bl.addHostingUnit(h3);

                //updateHostingUnit
                bl.updateHostingUnit(h2update);

                //removeHostingUnit
                h3.HostingUnitKey = 3;
                bl.removeHostingUnit(h3);
                 
                //add addGuestRequest 
                bl.addGuestRequest(guest1);
                bl.addGuestRequest(guest2);
                 
                //addOrder
                bl.addOrder(order1);
                bl.addOrder(order2);
                 
                //updateOrder
                order1.OrderKey = 1;
                order2.OrderKey = 2;
                bl.updateOrder(order1, STATUS.EmailSent);  
                bl.updateOrder(order2, STATUS.Done);


                printList(bl.getAllOrder());
                printList(bl.getAllGuests());
                printList(bl.getAllUnits());
                printList(bl.getAllBanksBranch());

            }
      
            catch (BE.MyException e)
            {
                Console.WriteLine(e.what()); 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
