using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{

    public abstract class MyException : Exception
    {
        public abstract string what();
    }
    public class unvalidDates : MyException
    {
        public override string what()
        {
            return "לא ניתן להזמין חופשה לפחות מיום";
        }
    }
    public class thereIsOpenOrder : MyException
    {
        public override string what()
        {
            return "עקב הזמנות פתוחות לא ניתן לבצע את הפעולה";
        }
    }
    public class occupideDates : MyException
    {
        public override string what()
        {
            return "תאריכים אלו כבר תפוסים";
        }
    }
    public class theOrderIsDone : MyException
    {
        public override string what()
        {
            return "ההזמנה נסגרה, לא ניתן לשנות את הסטטוס שלה";
        }
    }
    public class noCollectionClearance : MyException
    {
        public override string what()
        {
            return "לא קיים אישור אישור הרשאה מהבנק";
        }
        
    }
    public class exception : MyException
    {
        string str;
        public exception(string s)
        {
            str = s;
        }
        public override string what()
        {
            return str;
        }
    }
}
