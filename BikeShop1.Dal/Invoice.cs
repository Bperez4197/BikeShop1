using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeShop1.Dal
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public DateTime InvoiceDate { get; set; }
    }
}
