using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BikeShop1.Dal;
using System.ComponentModel.DataAnnotations;

namespace BikeShop1.Models
{
    public class CustomerModels
    {
    }



    public class CustomerModel
    {
        public int CustomerId { get; set; }
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
    }



    public class AllCustomersModel
    {
        public List<CustomerModel> Customers { get; set; }
    }


}