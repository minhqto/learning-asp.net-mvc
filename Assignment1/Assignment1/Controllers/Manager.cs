// **************************************************
// WEB524 Project Template V1 == 307be1fa-96bd-4a64-b588-8b408485cab8
// Do not change this header.
// **************************************************

using Assignment1.EntityModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
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
                cfg.CreateMap<Customer, CustomerBaseViewModel>();
                //here, we're telling our program where the view model should
                //get it's data from, and where the design model should send the data
                cfg.CreateMap<CustomerAddViewModel, Customer>();
                cfg.CreateMap<CustomerBaseViewModel, CustomerEditContactFormViewModel>();

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
        public IEnumerable<CustomerBaseViewModel> CustomerGetAll()
        {
            return mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerBaseViewModel>>(ds.Customers);
        }

        public CustomerBaseViewModel CustomerGetById(int id)
        {
            var obj = ds.Customers.Find(id);

            return obj == null ? null : mapper.Map<Customer, CustomerBaseViewModel>(obj);

        }

        public CustomerBaseViewModel AddNew(CustomerAddViewModel newCustomer)
        {
            var mappedNewCustomer = mapper.Map<CustomerAddViewModel, Customer>(newCustomer);
            var addedItem = ds.Customers.Add(mappedNewCustomer);
            ds.SaveChanges();

            return addedItem == null ? null : mapper.Map<Customer, CustomerBaseViewModel>(addedItem);
        }

        public CustomerBaseViewModel EditExisting(CustomerEditContactViewModel updatedCustomer)
        {
            var obj = ds.Customers.Find(updatedCustomer.CustomerId);
            if(obj == null)
            {
                return null;
            }
            else
            {
                ds.Entry(obj).CurrentValues.SetValues(updatedCustomer);
                ds.SaveChanges();
            }

            return mapper.Map<Customer, CustomerBaseViewModel>(obj);
        }

        public bool DeleteExisting(int id)
        {
            //always attempt to find the object first, then delete

            var obj = ds.Customers.Find(id);
            if (obj == null)
            {
                return false;
            }
            else
            {
                ds.Customers.Remove(obj);
                ds.SaveChanges();
                return true;
            }
        }

    }
}