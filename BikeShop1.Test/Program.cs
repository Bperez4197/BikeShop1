using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeShop1.Dal;

namespace BikeShop1.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerAdapter adapter = new CustomerAdapter();
            List<Customer> customers = adapter.GetAll();

            foreach (Customer customer in customers)
            {
                Console.WriteLine(customer.CustomerId + ":" + customer.FirstName + " " + customer.LastName);
            }
            Console.ReadLine();
        }
    }
}
