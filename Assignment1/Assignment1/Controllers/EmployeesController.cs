using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment1.EntityModels;
using Assignment1.Models;

namespace Assignment1.Controllers
{
    public class EmployeesController : Controller
    {
        private Manager m = new Manager();
        // GET: Employees
        public ActionResult Index() //get all
        {
            var allEmps = m.EmployeeGetAll();
            return View(allEmps);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            var employee = m.EmployeeGetById(id.GetValueOrDefault());
            if (employee == null || id == null)
            {
                return HttpNotFound();
            }


            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
           
            return View(new EmployeeAddViewModel());
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(EmployeeAddViewModel newEmployee)
        {
            if (!ModelState.IsValid)
            {
                return View(newEmployee);
            }

            try
            {
                var addedEmployee = m.EmployeeAdd(newEmployee);
                if (addedEmployee == null)
                {
                    return View(newEmployee);
                }
                else
                {
                    return RedirectToAction("Details", new {id = addedEmployee.EmployeeId});
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            var employee = m.EmployeeGetById(id.GetValueOrDefault());
            if (employee == null)
            {
                return HttpNotFound();
            }

            var formObj = m.mapper.Map<EmployeeBaseViewModel, EmployeeEditFormViewModel>(employee);
            return View(formObj);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, EmployeeEditViewModel employee)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit", new {id = employee.EmployeeId});
            }

            if (id.GetValueOrDefault() != employee.EmployeeId)
            {
                return RedirectToAction("Index");
            }


            try
            {
                var editedEmp = m.EmployeeEdit(employee);
                if (editedEmp == null)
                {
                    return RedirectToAction("Edit", new {id = employee.EmployeeId});
                }
                else
                {
                    return RedirectToAction("Details", new {id = employee.EmployeeId});
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
