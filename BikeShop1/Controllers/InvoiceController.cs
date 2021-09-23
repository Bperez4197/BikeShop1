using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BikeShop1.Dal;
using BikeShop1.Models;

namespace BikeShop1.Controllers
{


    public class InvoiceController : Controller
    {
        // GET: Customer


        public ActionResult Index(int customerId = 0)
        {
            InvoiceAdapter adapter = new InvoiceAdapter();
            List<Invoice> invoices = new List<Invoice>();
            if (customerId == 0)
            {
                invoices = adapter.GetAll();
            }
            else
            {
                invoices = adapter.GetByCustomerId(customerId);
            }
            AllInvoicesModel model = new AllInvoicesModel();
            List<InvoiceModel> invoiceModels = new List<InvoiceModel>();
            foreach (Invoice invoice in invoices)
            {
                InvoiceModel invoiceModel = new InvoiceModel();
                invoiceModel.InvoiceId = invoice.InvoiceId;
                invoiceModel.CustomerId = invoice.CustomerId;
                invoiceModel.Amount = invoice.Amount;
                invoiceModel.InvoiceDate = invoice.InvoiceDate;
                invoiceModels.Add(invoiceModel);
            }
            model.Invoices = invoiceModels;
            return View(model);
        }



        public ActionResult Add()
        {
            InvoiceModel model = new InvoiceModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(InvoiceModel model)
        {
            if (ModelState.IsValid)
            {
                InvoiceAdapter customerAdapter = new InvoiceAdapter();
                Invoice invoice = new Invoice();
                invoice.CustomerId = model.CustomerId;
                invoice.Amount = model.Amount;
                invoice.InvoiceDate = model.InvoiceDate;
                bool returnValue = customerAdapter.InsertInvoice(invoice);
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

        public ActionResult Edit(int invoiceId)
        {
            InvoiceAdapter invoiceAdapter = new InvoiceAdapter();
            Invoice invoice = invoiceAdapter.GetById(invoiceId);
            if (invoice == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                InvoiceModel model = new InvoiceModel();
                model.InvoiceId = invoice.InvoiceId;
                model.CustomerId = invoice.CustomerId;
                model.Amount = invoice.Amount;
                model.InvoiceDate = invoice.InvoiceDate;
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Edit(InvoiceModel model)
        {
            if (ModelState.IsValid)
            {
                InvoiceAdapter invoiceAdapter = new InvoiceAdapter();
                Invoice invoice = new Invoice();
                invoice.InvoiceId = model.InvoiceId;
                invoice.CustomerId = model.CustomerId;
                invoice.Amount = model.Amount;
                invoice.InvoiceDate = model.InvoiceDate;
                bool returnValue = invoiceAdapter.UpdateInvoice(invoice);
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

        public ActionResult Delete(int invoiceId)
        {
            InvoiceAdapter invoiceAdapter = new InvoiceAdapter();
            bool returnValue = invoiceAdapter.DeleteInvoice(invoiceId);
            return RedirectToAction("Index");
        }
    }


}