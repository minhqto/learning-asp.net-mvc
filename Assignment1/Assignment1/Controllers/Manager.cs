// **************************************************
// WEB524 Project Template V1 == 3e3c9376-8d95-4b5c-9bc5-249787524579
// Do not change this header.
// **************************************************

using Assignment1.EntityModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment1.Models;

namespace Assignment1.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private DataContext ds = new DataContext();

        // AutoMapper instance
        public IMapper mapper;

        public Manager()
        {
            // If necessary, add more constructor code here...

            // Configure the AutoMapper components
            var config = new MapperConfiguration(cfg =>
            {
                // Define the mappings below, for example...
                // cfg.CreateMap<SourceType, DestinationType>();
                // cfg.CreateMap<Employee, EmployeeBase>();
                cfg.CreateMap<Employee, EmployeeBaseViewModel>();
                cfg.CreateMap<EmployeeAddViewModel, Employee>();
                cfg.CreateMap<Employee, EmployeeEditViewModel>();
                cfg.CreateMap<EmployeeBaseViewModel, EmployeeEditFormViewModel>();

                //when we map, we want to map in the direction that teh data flows in the app that we have
                //for example, if we're just getting data from an entity, we just have to map from entity to the view model, but not vice versa
                //if there is an add functionality, then we have to map from the view model where the data is coming from, to the entity 

            });

            mapper = config.CreateMapper();
     

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
        }

        // Add your methods and call them from controllers.  Use the suggested naming convention.
        // Ensure that your methods accept and deliver ONLY view model objects and collections.
        // When working with collections, the return type is almost always IEnumerable<T>.

        public IEnumerable<EmployeeBaseViewModel> EmployeeGetAll()
        {
            var sortedEmps = from emps in ds.Employees
                                            select emps;
            sortedEmps = sortedEmps.OrderBy(emp => emp.LastName).ThenBy(emp => emp.FirstName);
            return mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeBaseViewModel>>(sortedEmps);
        }

        public EmployeeBaseViewModel EmployeeGetById(int id)
        {
            var emp = ds.Employees.Find(id);
            return emp == null ? null : mapper.Map<Employee, EmployeeBaseViewModel>(emp);
        }

        public EmployeeBaseViewModel EmployeeAdd(EmployeeAddViewModel newEmployee)
        {
            var addedItem = ds.Employees.Add(mapper.Map<EmployeeAddViewModel, Employee>(newEmployee));
            ds.SaveChanges();
            return addedItem == null ? null : mapper.Map<Employee, EmployeeBaseViewModel>(addedItem);
        }

        public EmployeeBaseViewModel EmployeeEdit(EmployeeEditViewModel editEmp)
        {
            var result =  ds.Employees.Find(editEmp);
            if (result == null)
            {
                return null;
            }
            ds.Entry(result).CurrentValues.SetValues(editEmp);
            ds.SaveChanges();
            return mapper.Map<Employee, EmployeeBaseViewModel>(result);

        }

    }
}