using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FactoryDal
    {
        static Idal dal;
        public static Idal GetDAL()
        {
            if (dal == null)
                dal = new Dal_imp();
            return dal;
        }
        public static Idal GetXMLDAL()
        {
            if (dal == null)
                dal = new Dal_XML_imp();
            return dal;
        }
    }
}
