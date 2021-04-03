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
    public class AlbumController : Controller
    {
        private Manager m = new Manager();

        // GET: Album
        [Route("Albums")]
        public ActionResult Index()
        {
            return View(m.AlbumGetAll());
        }

        // GET: Album/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var album = m.AlbumGetById(id.GetValueOrDefault());
            if(album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: Album/{id}/addtrack
        [Authorize(Roles = "Clerk")]
        [Route("{id}/addtrack")]
        public ActionResult AddTrack(int? id)
        {
            var form = new TrackAddFormViewModel();
            var album = m.AlbumGetById(id.GetValueOrDefault());
            form.AlbumName = album.Name;
            form.AlbumId = album.AlbumId;
            form.GenreList = new SelectList(m.GenreGetAll(), "Name", "Name");

            return View(form);
        }

        [Authorize(Roles = "Clerk")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{id}/addtrack")]
        public ActionResult AddTrack(TrackAddViewModel newTrack)
        {
            if (!ModelState.IsValid)
            {
                return View(newTrack);
            }
            try
            {
                var addedTrack = m.TrackAdd(newTrack);
                if (addedTrack == null)
                {
                    return View(newTrack);
                }
                
                  return RedirectToAction("Details", "Track", new { id = addedTrack.TrackId });
            }
            catch
            {
                return View(newTrack);
            }
          
        }

    }
}
