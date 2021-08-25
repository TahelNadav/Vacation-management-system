using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BE
{
    public class Configuration
    { 
        public static long hostingUnitKey = 1;
        public static long guestRequestKey = 1;
        public static long orderKey = 1;
        public static string password = "0000";// סיסמא של מנהל האתר
        public static string hostPassword = "1234";//סיסמא של מארחים
        public static float fee = 10;//עמלה
        public static float profit;

    }
}
