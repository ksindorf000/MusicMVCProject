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
            ViewBag.BandId = new SelectList(db.Bands, "Id", "Name");

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

    }
}

