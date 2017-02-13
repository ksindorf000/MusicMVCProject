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
    public class BandController : Controller
    {
        private BandsContext db = new BandsContext();

        // GET: Band
        public ActionResult Index()
        {
            return View(db.Bands.ToList());
        }

        // POST: Band Search
        [HttpPost]
        public ActionResult Index(BandSearch searchBox)
        {
            var bands = db.Bands
                .Where(b => b.Name.Contains(searchBox.Search));
            return View(bands.ToList());
        }

        // GET: Band/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Band band = db.Bands.Find(id);
            ViewBag.albumList = new List<Album>();
            ViewBag.albumList = db.Albums.Where(a => a.BandId == band.Id).ToList();

            if (band == null)
            {
                return HttpNotFound();
            }
            return View(band);
        }

        // GET: Band/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Band/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Formed")] Band band)
        {
            if (ModelState.IsValid)
            {
                db.Bands.Add(band);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(band);
        }

        // GET: Band/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Band band = db.Bands.Find(id);
            if (band == null)
            {
                return HttpNotFound();
            }
            return View(band);
        }

        // POST: Band/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Formed")] Band band)
        {
            if (ModelState.IsValid)
            {
                db.Entry(band).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(band);
        }

        // GET: Band/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Band band = db.Bands.Find(id);
            ViewBag.albumList = new List<Album>();
            ViewBag.albumList = db.Albums.Where(a => a.BandId == band.Id).ToList();
            if (band == null)
            {
                return HttpNotFound();
            }
            return View(band);
        }

        // POST: Band/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Band band = db.Bands.Find(id);
            db.Bands.Remove(band);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
