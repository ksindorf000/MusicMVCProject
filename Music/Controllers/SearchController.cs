using Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Music.Controllers
{
    public class SearchController : Controller
    {
        private BandsContext db = new BandsContext();

        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        // GET: BandResults
        public ActionResult BandResults(string searchString)
        {
            var band = from b in db.Bands
                       select b;

            var album = from a in db.Albums
                        select a;

            if (!String.IsNullOrEmpty(searchString))
            {
                band = band.Where(b => b.Name.Contains(searchString));
                return View(band);             

             if (band == null)
                {
                    album = album.Where(a => a.Title.Contains(searchString));
                    return View(album);
                }
            }
            return View();
        }

    }    
}