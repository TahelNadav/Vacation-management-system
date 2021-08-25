using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    public interface IBL
    {
        
        #region GuestRequest
        /// <summary>
        /// הוספת דרישת לקוח
        /// </summary>
        /// <param name="gs"></param>
        void addGuestRequest(GuestRequest gs);

        /// <summary>
        /// עדכון דרישת לקוח
        /// </summary>
        /// <param name="gs"></param>
        /// <param name="status"></param>
        void updateGuestRequest(BE.GuestRequest gs, STATUS status);
        
        /// <summary>
        /// החזרת רשימת דרישות לקוח
        /// </summary>
        /// <returns></returns>
        List<BE.GuestRequest> getAllGuests();
        
        /// <summary>
        /// החזרת דרישת לקוח השייכת להזמנה
        /// </summary>
        /// <param name="or"></param>
        /// <returns></returns>
        GuestRequest getGRByOrder(Order or);

        /// <summary>
        /// מחזירה את משך הזמן בין 2 תאריכים 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        int getDuration(DateTime start, DateTime end);

        /// <summary>
        /// p החזרת כל דרישות הלקוח המקיימות את תנאי
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        List<GuestRequest> findMatchGR(Predicate<GuestRequest> p);
        
        /// <summary>
        /// החזרת דרישות לקוח מקובצות לפי מיקום
        /// </summary>
        /// <returns></returns>
        List<IGrouping<LOCATION, GuestRequest>> GROrderByLocation();
        
        /// <summary>
        /// החזרת דרישות לקוח מקובצות לפי מספר הנופשים 
        /// </summary>
        /// <returns></returns>
        List<IGrouping<int, GuestRequest>> GROrderByNumOfVacationers();
        /// <summary>
        /// החזרת דרישות לקוח מקובצות לפי מיקום
        /// </summary>
        /// <param name="location"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        List<GuestRequest> GetGRByLocation(LOCATION location,List<GuestRequest> l);
        /// <summary>
        /// החזרת דרישות לקוח מקובצות לפי סוג האירוח
        /// </summary>
        /// <param name="t"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        List<GuestRequest> GetGRByType(TYPE t, List<GuestRequest> l);
        /// <summary>
        /// החזרת דרישות לקוח מקובצות לפי סטטוס
        /// </summary>
        /// <param name="s"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        List<GuestRequest> GetGRByStatus(STATUS s, List<GuestRequest> l);
        /// <summary>
        /// החזרת דרישות לקוח מקובצות לפי דרישה לבריכה
        /// </summary>
        /// <param name="p"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        List<GuestRequest> GetGRByPool(OPTIONS p, List<GuestRequest> l);
        /// <summary>
        /// החזרת דרישות לקוח מקובצות לפי שם המשפחה של הלקוח
        /// </summary>
        /// <param name="s"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        List<GuestRequest> GetGRByFM(string s, List<GuestRequest> l);
       
        #endregion


        #region HostingUnit
        /// <summary>
        /// הוספת י"א
        /// </summary>
        /// <param name="hu"></param>
        void addHostingUnit(BE.HostingUnit hu);
       
        /// <summary>
        /// מחיקת י"א
        /// </summary>
        /// <param name="hu"></param>
        void removeHostingUnit(BE.HostingUnit hu);
        
        /// <summary>
        /// עדכון י"א
        /// </summary>
        /// <param name="hu"></param>
        void updateHostingUnit(BE.HostingUnit hu);
        
        /// <summary>
        /// החזרת רשימת על י"א
        /// </summary>
        /// <returns></returns>
        List<BE.HostingUnit> getAllUnits();
        
        /// <summary>
        ///  בודקת האם י"א פנויה בתאריכים הנתונים  
        /// </summary>
        /// <param name="hu"></param>
        /// <param name="d"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        bool HostingUnitNotOccupied(HostingUnit hu, DateTime d, int duration);
        
        /// <summary>
        /// "עדכון המטריצה לתאריכים שנסגרו ועדכון סטטוס ההזמנה ל"נסגר
        /// </summary>
        /// <param name="or"></param>
        void fillDatesAndUpdateStatus(Order or);
        
        /// <summary>
        /// מחזירה את רשימת היחידות שפנויות בתאריכים הנתונים
        /// </summary>
        /// <param name="d"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        List<HostingUnit> getPossibleHU(DateTime d, int duration);
        
        /// <summary>
        /// החזרת י"א המתאימה להזמנה
        /// </summary>
        /// <param name="or"></param>
        /// <returns></returns>
        HostingUnit getHUByOrder(Order or);
        
        /// <summary>
        /// החזרת י"א מקובצות עפ"י מיקום
        /// </summary>
        /// <returns></returns>
        List<IGrouping<LOCATION, HostingUnit>> HUOrderByLocation();

        /// <summary>
        /// מחזירה את רשימת יחידות אירוח לפי תז מארח
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<HostingUnit> getHUListByID(long id);
        /// <summary>
        /// מחזירה את רשימת יחידות אירוח לפי מיקום היחידה  
        /// </summary>
        /// <param name="location"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        List<HostingUnit> getHUByLocation(LOCATION location, List<HostingUnit> l);
        /// <summary>
        /// מחזירה את רשימת יחידות אירוח לפי סוג האירוח
        /// </summary>
        /// <param name="t"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        List<HostingUnit> getHUByType(TYPE t, List<HostingUnit> l);
        /// <summary>
        /// מחזירה את רשימת יחידות אירוח לפי קיום בריכה
        /// </summary>
        /// <param name="b"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        List<HostingUnit> getHUByPool(bool b, List<HostingUnit> l);
        /// <summary>
        /// מחזירה את רשימת יחידות אירוח לפי קיום אטרקציות לילדים
        /// </summary>
        /// <param name="b"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        List<HostingUnit> getHUByChildrenA(bool b, List<HostingUnit> l);
        /// <summary>
        /// מחזירה את רשימת יחידות אירוח לפי שם היחידה
        /// </summary>
        /// <param name="s"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        List<HostingUnit> getHUByName(string s, List<HostingUnit> l);
       


        #endregion


        #region Order
        /// <summary>
        /// הוספת הזמנה
        /// </summary>
        /// <param name="or"></param>
        void addOrder(BE.Order or);
        
        /// <summary>
        /// עדכון הזמנה
        /// </summary>
        /// <param name="or"></param>
        /// <param name="status"></param>
        void updateOrder(BE.Order or, STATUS status);
        
        /// <summary>
        /// החזרת רשימת ההזמנות
        /// </summary>
        /// <returns></returns>
        List<BE.Order> getAllOrder();
        
        /// <summary>
        /// מחזירה את כמות ההזמנות הפתוחות של י"א
        /// </summary>
        /// <param name="hu"></param>
        /// <returns></returns>
        int openOrders(HostingUnit hu);
        
        /// <summary>
        /// מחזירה רשימת הזמנות המתאימות לדרישת לקוח
        /// </summary>
        /// <param name="GRKey"></param>
        /// <returns></returns>
        List<Order> getOrderByGR(long GRKey);
        
        /// <summary>
        /// מחזירה את כמות ההזמנות של דרישת לקוח
        /// </summary>
        /// <param name="gs"></param>
        /// <returns></returns>
        int numOfOrdersByGR(GuestRequest gs);
        
        /// <summary>
        /// ביטול הזמנות של דרישת לקוח
        /// </summary>
        /// <param name="or"></param>
        void CanceleOrders(Order or);
        
        /// <summary>
        /// מחזירה את כמות ההזמנות של י"א
        /// </summary>
        /// <param name="hu"></param>
        /// <returns></returns>
        int orderOfHU(HostingUnit hu);
        
        /// <summary>
        /// מחזירה האם יש הזמנות פתוחות לי"א
        /// </summary>
        /// <param name="hu"></param>
        /// <returns></returns>
        bool orderInProcesses(HostingUnit hu);
        
        /// <summary>
        /// החזרת רשימת ההזמנות שמשך הזמן שעבר מאז שנשלח מייל גדול ממס הימים שקיבלה
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        List<Order> oldOrders(int days);
        /// <summary>
        /// החזרת רשימת ההזמנות לפי ת.ז של מארח
        /// </summary>
        /// <param name="id"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        List<Order> getOrdersByHostId(long id, List<Order> l);
        /// <summary>
        /// החזרת רשימת ההזמנות לפי סטטוס ההזמנה
        /// </summary>
        /// <param name="s"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        List<Order> getOrdersByStatus(STATUS s, List<Order> l);
        /// <summary>
        /// החזרת הזמנות לפי דרישת לקוח ויחידת אירוח
        /// </summary>
        /// <param name="GRKey"></param>
        /// <param name="HUNum"></param>
        /// <returns></returns>
        Order getOrderByGRHU(long GRKey, long HUNum);
        #endregion


        #region BankBranch
        
        /// <summary>
        /// מחזירה רשימת שמות הבנקים
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        List<string> getBankListNames(List<BankBranch> l);
        /// <summary>
        /// מחזירה רשימת סניפי בנק של בנק מסוים 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        List<BankBranch> getBranchListByBankName(List<BankBranch> l, string name);
        /// <summary>
        /// פונקצית תהליכון מעדכנת סטטוס הזמנות שפג תוקפן
        /// </summary>
        /// <returns></returns>
        void updateExpireOrder();
        #endregion
        #region siteManager
        /// <summary>
        /// חישוב עמלה של הזמנה
        /// </summary>
        /// <param name="or"></param>
        /// <returns></returns>
        float calculateFee(Order or);
        #endregion


        #region Host
        /// <summary>
        /// מחזירה את רשימת המארחים מקובצים לפי מס יחידות שיש לכ"א
        /// </summary>
        /// <returns></returns>
        List<IGrouping<int, Host>> HostOrderByNumOfHU();
       
        /// <summary>
        /// מחזירה את רשימת המארחים
        /// </summary>
        /// <param name="hu"></param>
        /// <returns></returns>
        List<Host> getHostList(List<HostingUnit> hu);
        /// <summary>
        /// החזרת רשימת מארחים לפי שם משפחה 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        List<Host> getHostByFM(string s,List<Host> l);
        /// <summary>
        ///  החזרת רשימת מארחים לפי ת.ז שם מארח 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        List<Host> getHostById(long id, List<Host> l);
        /// <summary>
        ///  החזרת רשימת מארחים לפי כמות של מספר יחידות 
        /// </summary>
        /// <param name="num"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        List<Host> getHostByNumOfHU(int num, List<Host> l);


        #endregion


    }
}

