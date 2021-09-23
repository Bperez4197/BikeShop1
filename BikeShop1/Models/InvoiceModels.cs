using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeShop1.Models
{
    public class InvoiceModels
    {
    }



    public class InvoiceModel
    {
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public DateTime InvoiceDate { get; set; }
    }

    public class AllInvoicesModel
    {
        public List<InvoiceModel> Invoices { get; set; }
    }


}