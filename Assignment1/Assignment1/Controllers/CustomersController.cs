using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment1.EntityModels;
using Assignment1.Models;

namespace Assignment1.Controllers
{
    public class CustomersController : Controller
    {
        private Manager m = new Manager();
        // GET: Customers
        public ActionResult Index() //the getAll
        {
            var allCustomers = m.CustomerGetAll();
            return View(allCustomers);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }

            var customer = m.CustomerGetById(id.Value);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        } 

        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create(CustomerAddViewModel newItem)
        {
            if (!ModelState.IsValid)
            {
                return View(newItem);
            }
            try
            {
                var newCustomer =  m.AddNew(newItem);
                if (newCustomer == null)
                {
                    return View(newItem);
                }

                return RedirectToAction("Details", new {id = newCustomer.CustomerId});
            }
            catch
            {
                return View(newItem);
            }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            var customer = m.CustomerGetById(id.GetValueOrDefault());
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                var formObj = m.mapper.Map<CustomerBaseViewModel, CustomerEditContactFormViewModel>(customer);
                return View(formObj);
            }
        }

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, CustomerEditContactViewModel customer)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit", new {id = customer.CustomerId});
            }

            if (id.GetValueOrDefault() != customer.CustomerId)
            {
                return RedirectToAction("Index");
            }
            try
            {
                var edited = m.EditExisting(customer);

                if (edited == null)
                {
                    return RedirectToAction("Edit", new {id = customer.CustomerId});
                }
                else
                {
                    return RedirectToAction("Details", new {id = customer.CustomerId});
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            var customer = m.CustomerGetById(id.GetValueOrDefault());
            if (customer == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(customer);
            }
            
        }

        // POST: Customers/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            try
            {
                m.DeleteExisting(id.GetValueOrDefault());

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
