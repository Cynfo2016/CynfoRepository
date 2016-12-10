using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CynfoApp.Models;
using CynfoApp.azureUtils;

namespace cftest.Controllers
{
    public class adsController : Controller
    {
        private DefaultConnectioncontext db = new DefaultConnectioncontext();

        // GET: ads
        public async Task<ActionResult> Index()
        {
            return View(await db.ad.ToListAsync());
        }

        // GET: ads/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            adModels ad = await db.ad.FindAsync(id);
            if (ad == null)
            {
                return HttpNotFound();
            }
            return View(ad);
        }

        // GET: ads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idad,adTitle,adDescription,adMediaUrl,adArea,adPublishedDate,adPublishedDate,adMinor")] adModels ad, HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                PhotoService photoservice = new PhotoService();
                photoservice.CreateAndConfigureAsync();
                ad.adMediaUrl = await photoservice.UploadPhotoAsync(photo);
                ad.adPublishedDate = DateTime.UtcNow;
                ad.adFinishedDate = DateTime.UtcNow;
                db.ad.Add(ad);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(ad);
        }

        // GET: ads/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ad ad = await db.ad.FindAsync(id);
            if (ad == null)
            {
                return HttpNotFound();
            }
            return View(ad);
        }

        // POST: ads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idad,adTitle,adDescription,adMediaUrl,adArea,adPublishedDate,adPublishedDate,adMinor")] adModels ad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ad).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ad);
        }

        // GET: ads/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            adModels ad = await db.ad.FindAsync(id);
            if (ad == null)
            {
                return HttpNotFound();
            }
            return View(ad);
        }

        // POST: ads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            adModels ad = await db.ad.FindAsync(id);
            db.ad.Remove(ad);
            await db.SaveChangesAsync();
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
