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

        static public void printList<T>(List<T> list)       //print the list its get
        {
            foreach (T item in list)
            {
                Console.WriteLine(item.ToString() + "\n");
            }
        }
        static public void printList<T, U>(List<IGrouping<T, U>> list)  //print the list hat group by keys its get
        {
            foreach (var item in list)
            {
                Console.WriteLine("Key:{0}\nelements:", item.Key);
                foreach (var v in item)
                {
                    Console.WriteLine(v.ToString() + "\n");
                }
            }
        }
        static public bool match(GuestRequest gs)      //The function get GuestRequest an dreturn true if it match to her terms
        {
            return (gs.Area == LOCATION.צפון) ? true : false;
        }
        static BL.IBL bl = BL.FactoryBL.GetBL();
        static void Main(string[] args)
        {

            try
            {
                DateTime date = new DateTime(2020, 3, 4);

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
                    location = LOCATION.דרום,
                    Owner = host1,
                    type = TYPE.מלון,
                    Pool  = true,
                    ChildrensAttractions = false
                };
                HostingUnit h2 = new HostingUnit
                {
                    HostingUnitName = "h2",
                    location = LOCATION.צפון,
                    Owner = host2,
                    type = TYPE.מלון,
                    Pool = false,
                    ChildrensAttractions = false
                };
                HostingUnit h2update = new HostingUnit
                {
                    HostingUnitName = "h2update",
                    location = LOCATION.צפון,
                    Owner = host2,
                    HostingUnitKey = 2,
                    type = TYPE.מלון,
                    Pool = false,
                    ChildrensAttractions = false
                };
                HostingUnit h3 = new HostingUnit
                {
                    HostingUnitName = "h3",
                    location = LOCATION.ירושלים,
                    Owner = host2,
                    type = TYPE.מלון,
                    Pool = true,
                    ChildrensAttractions = true
                };


                GuestRequest guest1 = new GuestRequest
                {
                    Adults = 2,
                    Children = 3,
                    Area = LOCATION.צפון,
                    MailAddress = "osher@gmail.com",
                    Pool = OPTIONS.מעוניין,
                    EntryDate = date,
                    ReleaseDate = date.AddDays(4),
                    ChildrensAttractions = OPTIONS.מעוניין,
                    PrivateName = "osher",
                    FamilyName = "Cohen",
                    Status = STATUS.בתהליך,
                    Type = TYPE.מלון,
                    RegistrationDate = DateTime.Now
                };
                GuestRequest guest2 = new GuestRequest
                {
                    Adults = 4,
                    Children = 1,
                    Area = LOCATION.הכול,
                    MailAddress = "Dan@gmail.com",
                    Pool = OPTIONS.אפשרי,
                    EntryDate = date.AddDays(56),
                    ReleaseDate = date.AddDays(62),
                    ChildrensAttractions = OPTIONS.איןצורך,
                    PrivateName = "Dan",
                    FamilyName = "Levi",
                    Status = STATUS.בתהליך,
                    Type = TYPE.צימר,
                    RegistrationDate = DateTime.Now
                };


                Order order1 = new Order
                {
                    CreateDate = DateTime.Now,
                    GuestRequestKey = 1,
                    HostingUnitKey = 2,
                    Status = STATUS.בתהליך
                };
                Order order2 = new Order
                {
                    CreateDate = DateTime.Now,
                    GuestRequestKey = 2,
                    HostingUnitKey = 1,
                    Status = STATUS.אימיילנשלח
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
                bl.updateOrder(order1, STATUS.אימיילנשלח);
                bl.updateOrder(order2, STATUS.נסגרה);

                //chek the other function:
                bl.getPossibleHU(date, 7);
                bl.oldOrders(3);
                bl.getOrderByGR(guest1.GuestRequestKey);
                bl.orderOfHU(h1);
                bl.findMatchGR(match);

                //print the list that group by keys(location,num of vacationers etc.)
                printList(bl.HUOrderByLocation());
                printList(bl.HostOrderByNumOfHU());
                printList(bl.GROrderByNumOfVacationers());
                printList(bl.GROrderByLocation());


                //print the lists 
                printList(bl.getAllOrder());
                printList(bl.getAllGuests());
                printList(bl.getAllUnits());
               

                //Print profit till now
                Console.WriteLine("The profit till now:{0}",Configuration.profit);

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
