using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reportgeneration
{
    public class AddCart
    {

        [DisplayName("SNo")]
        public int Serialno
        {
            get;
            set;
        }

        [DisplayName("Product")]
        public string ProductName
        {
            get;
            set;
        }

        
        public decimal Qunatity
        {
            get;
            set;
        }

        public decimal Price
        {
            get;
            set;
        }


        [DisplayName("Amount")]
        public decimal TotalAmount
        {
            get;
            set;
        }
    }
}
