using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_3.Controllers
{
    public class ArtistController : Controller
    {
        private Manager m = new Manager();
        // GET: Artist
        public ActionResult Index()
        {
            return View(m.ArtistGetAll());
        }

    }
}
