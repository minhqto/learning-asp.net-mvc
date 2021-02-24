using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment2.Models;
using Assignment2.EntityModels;

namespace Assignment2.Controllers
{
    public class TrackController : Controller
    {
        private Manager m = new Manager();
        // GET: Track
        public ActionResult Index()
        {
            var tracks = m.TrackGetAll();
            return View("Index", tracks);
        }

        public ActionResult ReggaeTracks()
        {
            var reggaeTracks = m.TrackGetAllReggae();
            return View("Index", reggaeTracks);

        }

        public ActionResult JohnPaulJonesTracks()
        {
            var jpjTracks = m.TrackGetAllJohnPaulJones();
            return View("Index", jpjTracks);

        }

        public ActionResult Top50LongestTracks()
        {
            var top50 = m.TrackGetAllTop50Longest();
            return View("Index", top50);
        }

    }
}
