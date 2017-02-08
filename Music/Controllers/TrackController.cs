using Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Music.Controllers
{
    public class TrackController : Controller
    {
        private BandsContext db = new BandsContext();
        
        // GET: Tracks for given album
        public ActionResult Index(int? id)
        {            
            return View(db.Tracks.Where(t => t.Album.Id == id).ToList());
        }
        
        // CREATE: Track
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Album,Title,Length")] Track track)
        {
            if (ModelState.IsValid)
            {
                db.Tracks.Add(track);
                db.SaveChanges();
                return RedirectToAction("Index", "Album");
            }

            return RedirectToAction("Index", "Album");
        }
    }
}