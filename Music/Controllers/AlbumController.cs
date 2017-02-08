using Music.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Music.Controllers
{
    public class AlbumController : Controller
    {
        private BandsContext db = new BandsContext();
        
        // GET: Album
        public ActionResult Index()
        {
            return View(db.Albums.OrderByDescending(a => a.Title).ToList());
        }

        // GET: BandId and Name
        public ActionResult Create()
        {
            ViewBag.BandId = new SelectList(db.Bands, "Id", "Name");
            return View();
        }

        // GET: Band/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }

            ViewBag.trackList = db.Tracks.Where(t => t.Album.Id == id).ToList();
            return View(album);
        }

        // CREATE: Album
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BandId,Title,ReleaseDate")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Albums.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(album);
        }

        // GET: Album to edit
        public ActionResult Edit(int? id)
        {
            /*
             * SELECT b.Id
             * FROM Band b
             * INNER JOIN Album a ON a.BandId == b.Id
             * WHERE a.Id = id
             */
             
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Album album = db.Albums.Find(id);
            ViewBag.BandId = new SelectList(db.Bands, "Id", "Name", album.BandId);

            if (album == null)
            {
                return HttpNotFound();
            }

            ViewBag.trackList = db.Tracks.Where(t => t.Album.Id == id).ToList();

            return View(album);
        }
                
        // POST: Album Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BandId,Title,ReleaseDate")] Album album)
        {
            ViewBag.BandId = new SelectList(db.Bands, "Id", "Name");

            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(album);
        }

        // GET: Album/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Album/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Albums.Find(id);
            db.Albums.Remove(album);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

