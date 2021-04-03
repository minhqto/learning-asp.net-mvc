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
    public class ArtistController : Controller
    {
        private Manager m = new Manager();

        // GET: Artist
        public ActionResult Index()
        {
            return View(m.ArtistGetAll());
        }

        // GET: Artist/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var artist = m.ArtistGetById(id.GetValueOrDefault());
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // GET: Artist/Create
        [Authorize(Roles = "Executive")]
        public ActionResult Create()
        {
            var form = new ArtistAddFormViewModel();
            form.Genres = new SelectList(m.GenreGetAll(), "Name", "Name");

            return View(form);
        }

        // POST: Artist/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Executive")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArtistAddViewModel newArtist)
        {
            if (!ModelState.IsValid)
            {
                return View(newArtist);
            }
            try
            {
                var addedArtist = m.ArtistAdd(newArtist);
                if(addedArtist == null)
                {
                    return View(newArtist);
                }

                return RedirectToAction("Details", new { id = addedArtist.ArtistId });
            }
            catch
            {
                return View();
            }

        }
        [Authorize(Roles = "Coordinator")]
        [Route("{id}/addalbum")]
        public ActionResult AddAlbum(int? id)
        {
            var artist = m.ArtistGetById(id.GetValueOrDefault());
            if(artist == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = new AlbumAddFormViewModel();
                form.CurrentArtist = artist.Name;
                form.Genres = new SelectList(m.GenreGetAll(), "Name", "Name");
                form.ArtistId = artist.ArtistId;
                List<int> artistIds = new List<int>();
                artistIds.Add(artist.ArtistId);
                var selectedArtists = artistIds;

                form.AvailableArtists = new MultiSelectList(m.ArtistGetAll(), "ArtistId", "Name", selectedArtists);
                form.Tracks = new MultiSelectList(m.TrackGetAllByArtistId(id.GetValueOrDefault()), "TrackId", "Name");
                return View(form);
            }

        }
        [Authorize(Roles = "Coordinator")]
        [HttpPost]
        [Route("{id}/addalbum")]
        [ValidateAntiForgeryToken]
        public ActionResult AddAlbum(AlbumAddViewModel newAlbum)
        {

            if (!ModelState.IsValid)
            {
                return View(newAlbum);
            }
            try
            {
                var addedAlbum = m.AlbumAdd(newAlbum);
                if (addedAlbum == null)
                {
                    return View(newAlbum);
                }
                return RedirectToAction("Details", "Album", new { id = addedAlbum.AlbumId });
            }
            catch
            {
                return View(newAlbum);
            }
        }
    }
}
