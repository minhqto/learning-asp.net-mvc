using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment_3.Models;

namespace Assignment_3.Controllers
{
    public class TrackController : Controller
    {
        private Manager m = new Manager();
        // GET: Track
        public ActionResult Index()
        {
            return View(m.TrackGetAllWithDetail());
        }

        // GET: Track/Details/5
        public ActionResult Details(int? id)
        {
            var track = m.TrackGetOneWithDetail(id.GetValueOrDefault());
            if(track == null)
            {
                return HttpNotFound();
            }
            return View(track);
        }

        // GET: Track/Create
        public ActionResult Create()
        {
            var form = new TrackAddFormViewModel();
            form.AlbumList = new SelectList(m.AlbumGetAll(), "AlbumId", "Title");
            form.MediaTypeList = new SelectList(m.MediaTypeGetAll(), "MediaTypeId", "Name");

            return View(form);
        }

        // POST: Track/Create
        [HttpPost]
        public ActionResult Create(TrackAddViewModel newTrack)
        {

            if (!ModelState.IsValid)
            {
                return View(newTrack);
            }
            try
            {
                var addedTrack = m.TrackAdd(newTrack);
                if(addedTrack == null)
                {
                    return View(newTrack);
                }

                return RedirectToAction("Details", new { id = addedTrack.TrackId});
            }
            catch
            {
                return View();
            }
        }
    }
}
