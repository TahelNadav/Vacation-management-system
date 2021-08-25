using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
     

namespace DAL
{
    public interface Idal
    {
        #region GuestRequest
        /// <summary>
        /// הוספת דרישת לקוח
        /// </summary>
        /// <param name="gs"></param>
        void addGuestRequest(BE.GuestRequest gs);
       
        /// <summary>
        /// עדכון דרישת לקוח
        /// </summary>
        /// <param name="gs"></param>
        /// <param name="status"></param>
        void updateGuestRequest(BE.GuestRequest gs, STATUS status);
        
        /// <summary>
        /// החזרת רשימת כל דרישות הלקוח
        /// </summary>
        /// <returns></returns>
        List<BE.GuestRequest> getAllGuests();
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
        /// החזרת רשימת כל י"א
        /// </summary>
        /// <returns></returns>
        List<BE.HostingUnit> getAllUnits();
        #endregion


        #region Order
        /// <summary>
        ///  הוספת הזמנה
        /// </summary>
        /// <param name="or"></param>
        void addOrder(BE.Order or);
        
        /// <summary>
        /// עדכון הזמנה
        /// </summary>
        /// <param name="or"></param>
        /// <param name="status"></param>
        void updateOrder(BE.Order or,STATUS status);
        
        /// <summary>
        /// החזרת רשימת כל ההזמנות
        /// </summary>
        /// <returns></returns>
        List<BE.Order> getAllOrder();
        #endregion


        
    }
}
