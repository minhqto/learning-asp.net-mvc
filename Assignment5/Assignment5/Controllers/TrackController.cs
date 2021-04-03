using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment5.Models;

namespace Assignment5.Controllers
{
    public class TrackController : Controller
    {
        private Manager m = new Manager();

        // GET: Track
        public ActionResult Index()
        {
            return View(m.TrackGetAll());
        }

        // GET: Track/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var track = m.TrackGetById(id.GetValueOrDefault());
            if(track == null)
            {
                return HttpNotFound();
            }
            return View(track);

        }

        //// GET: Track/Create
        //[Authorize(Roles = "Clerk")]
        //public ActionResult Create()
        //{
        //    var form = new TrackAddFormViewModel();
        //    form.GenreList = new SelectList(m.GenreGetAll(), "Name", "Name");

        //    return View(form);
        //}

        //// POST: Track/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize(Roles = "Clerk")]
        //public ActionResult Create(TrackAddViewModel newTrack)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(newTrack);
        //    }
        //    var addedTrack = m.TrackAdd(newTrack);

        //    return View(addedTrack);
        //}

      
    }
}
