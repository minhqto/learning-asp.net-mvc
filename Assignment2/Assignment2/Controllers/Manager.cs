// **************************************************
// WEB524 Project Template V1 == f8a2c97b-3191-4808-a7e0-12d8b9604e58
// Do not change this header.
// **************************************************

using Assignment2.EntityModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Html;
using System.Web.UI.WebControls.Expressions;
using Assignment2.Models;

namespace Assignment2.Controllers
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
                cfg.CreateMap<Track, TrackBaseViewModel>();
                cfg.CreateMap<Invoice, InvoiceBaseViewModel>();

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
        public IEnumerable<TrackBaseViewModel> TrackGetAll()
        {
            var tracks = from t in ds.Tracks
                                        orderby t.GenreId, t.Name
                                        select t;

            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackBaseViewModel>>(tracks);
        }

        public IEnumerable<TrackBaseViewModel> TrackGetAllReggae()
        {
            var reggaeTracks = from t in ds.Tracks
                                                    where t.GenreId == 8
                                                    orderby t.Name
                                                    select t;
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackBaseViewModel>>(reggaeTracks);
        }

        public IEnumerable<TrackBaseViewModel> TrackGetAllJohnPaulJones()
        {
            var jpjTracks = from t in ds.Tracks
                                                where t.Composer.Contains("John Paul Jones")
                                                orderby t.AlbumId
                                                select t;

            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackBaseViewModel>>(jpjTracks);
        }

        public IEnumerable<TrackBaseViewModel> TrackGetAllTop50Longest()
        {
            var top50 = ds.Tracks.OrderByDescending(t => t.Milliseconds).Take(50);
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackBaseViewModel>>(top50);
        }

        public IEnumerable<InvoiceBaseViewModel> InvoiceGetAll()
        {
            var invoices = from i in ds.Invoices
                                            select i;

            return mapper.Map<IEnumerable<Invoice>, IEnumerable<InvoiceBaseViewModel>>(invoices);
        }

        public InvoiceBaseViewModel InvoiceGetOne(int id)
        {
            var invoice = ds.Invoices.Find(id);
           
            return invoice == null ? null : mapper.Map<Invoice, InvoiceBaseViewModel>(invoice);
            
        }
    }
}