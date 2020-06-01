using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reportgeneration
{
    class carthistory
    {

        [DisplayName("Bill No#")]
        public long invoicebill
        {
            get;
            set;
        }

        [DisplayName("Date")]
        public DateTime billedate
        {
            get;
            set;
        }

        [DisplayName("Comapny/Mr")]
        public long companyIDforhistory
        {
            get;
            set;
        }

    }
}
