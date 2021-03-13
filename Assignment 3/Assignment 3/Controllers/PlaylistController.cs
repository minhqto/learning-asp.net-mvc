using Assignment_3.EntityModels;
using Assignment_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_3.Controllers
{
    public class PlaylistController : Controller
    {
        private Manager m = new Manager();
        // GET: Playlist
        public ActionResult Index()
        {
            return View(m.PlaylistGetAll());
        }

        // GET: Playlist/Details/5
        public ActionResult Details(int? id)
        {
            var playlist = m.PlaylistGetById(id.GetValueOrDefault());
            if (playlist == null)
            {
                return HttpNotFound();
            }
            var form = playlist;
            form.Tracks = playlist.Tracks.OrderBy(t => t.Name);
            
            return View(form);
        }

        
        // GET: Playlist/Edit/5
        public ActionResult Edit(int? id)
        {
            var playlist = m.PlaylistGetById(id.GetValueOrDefault());
            if(playlist == null)
            {
                return HttpNotFound();
            }

            var form = m.mapper.Map<PlaylistEditTracksFormViewModel>(playlist);
            form.CurrentTracks = playlist.Tracks.OrderBy(t => t.Name);
            var selectedVals = form.CurrentTracks.Select(t => t.TrackId);

            form.PlaylistTracks = new MultiSelectList(
                items: m.TrackGetAllWithDetail(),
                dataValueField: "TrackId",
                dataTextField: "NameFull",
                selectedValues: selectedVals);

            return View(form);
        }

        // POST: Playlist/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, PlaylistEditTracksViewModel form)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("edit", new { id = form.PlaylistId });
                }

                if(id != form.PlaylistId)
                {
                    return RedirectToAction("index");
                }

                var result = m.PlaylistEditTracks(form);
                if(result == null)
                {
                    return RedirectToAction("edit", new { id = form.PlaylistId });
                }
                else
                {
                    return RedirectToAction("Details", new { id = form.PlaylistId });
                }
              
            }
            catch
            {
                return View();
            }
        }

    }
}
