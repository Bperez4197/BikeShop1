using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BikeShop1.Dal;
using BikeShop1.Models;

namespace BikeShop1.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            CustomerAdapter adapter = new CustomerAdapter();
            List<Customer> customers = adapter.GetAll();
            AllCustomersModel model = new AllCustomersModel();
            List<CustomerModel> customerModels = new List<CustomerModel>();
            foreach (Customer customer in customers)
            {
                CustomerModel customerModel = new CustomerModel();
                customerModel.CustomerId = customer.CustomerId;
                customerModel.FirstName = customer.FirstName;
                customerModel.LastName = customer.LastName;
                customerModels.Add(customerModel);
            }
            model.Customers = customerModels;
            return View(model);
        }



        public ActionResult Add()
        {
            CustomerModel model = new CustomerModel();
            return View(model);
        }



        [HttpPost]
        public ActionResult Add(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                CustomerAdapter customerAdapter = new CustomerAdapter();
                Customer customer = new Customer();
                customer.FirstName = model.FirstName;
                customer.LastName = model.LastName;
                bool returnValue = customerAdapter.InsertCustomer(customer);
                if (returnValue)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            return View(model);
        }



        public ActionResult Edit(int customerId)
        {
            CustomerAdapter customerAdapter = new CustomerAdapter();
            Customer customer = customerAdapter.GetById(customerId);
            if (customer == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                CustomerModel model = new CustomerModel();
                model.CustomerId = customer.CustomerId;
                model.FirstName = customer.FirstName;
                model.LastName = customer.LastName;
                return View(model);
            }
        }




        [HttpPost]
        public ActionResult Edit(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                CustomerAdapter customerAdapter = new CustomerAdapter();
                Customer customer = new Customer();
                customer.FirstName = model.FirstName;
                customer.LastName = model.LastName;
                customer.CustomerId = model.CustomerId;
                bool returnValue = customerAdapter.UpdateCustomer(customer);
                if (returnValue)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            return View(model);
        }



        public ActionResult Delete(int customerId)
        {
            CustomerAdapter customerAdapter = new CustomerAdapter();
            bool returnValue = customerAdapter.DeleteCustomer(customerId);
            return RedirectToAction("Index");
        }



    }
}