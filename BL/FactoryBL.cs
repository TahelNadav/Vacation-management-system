//Adi Malachi 209244250
//Tahel Nadav 207816612
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BL
{
    public class FactoryBL
    {
        static IBL bl = null;
        public static IBL  GetBL()
        {
            if (bl == null)
                bl = new BL_imp();
            return bl;
        }

    }
}
