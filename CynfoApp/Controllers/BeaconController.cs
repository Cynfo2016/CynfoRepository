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

namespace CynfoApp.Controllers
{
    public class BeaconController : Controller
    {
        private DefaultConnectioncontext db = new DefaultConnectioncontext();

        // GET: Beacon
        public async Task<ActionResult> Index()
        {
            return View(await db.beacon.ToListAsync());
        }

        // GET: Beacon/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BeaconModels beacon = await db.beacon.FindAsync(id);
            if (beacon == null)
            {
                return HttpNotFound();
            }
            return View(beacon);
        }

        // GET: Beacon/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Beacon/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdBeacon,beaconAddress,beaconMajor,beaconMinor,Place_idPlace")] BeaconModels beacon/*, HttpPostedFileBase photo*/)
        {
            if (ModelState.IsValid)
            {
                db.beacon.Add(beacon);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(beacon);
        }

        public async Task<ActionResult> Edit(int? idBeacon)
        {
            if (idBeacon == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BeaconModels beacon = await db.beacon.FindAsync(idBeacon);
            if (beacon == null)
            {
                return HttpNotFound();
            }
            return View(beacon);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdBeacon,beaconAddress,beaconMajor,beaconMinor,Place_idPlace")] BeaconModels beacon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(beacon).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(beacon);
        }

        public async Task<ActionResult> Delete(int? idBeacon)
        {
            if (idBeacon == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BeaconModels beacon = await db.beacon.FindAsync(idBeacon);
            if (beacon == null)
            {
                return HttpNotFound();
            }
            return View(beacon);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BeaconModels beacon = await db.beacon.FindAsync(id);
            db.beacon.Remove(beacon);
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