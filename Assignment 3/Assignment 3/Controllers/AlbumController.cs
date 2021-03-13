using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_3.Controllers
{
    public class AlbumController : Controller
    {

        private Manager m = new Manager();
        // GET: Album
        public ActionResult Index()
        {
            var albums = m.AlbumGetAll();
            return View(albums);
        }

        //GET ONE
        public ActionResult Details(int? id)
        {
            var album = m.AlbumGetById(id.GetValueOrDefault());
            if(album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }
    }
}