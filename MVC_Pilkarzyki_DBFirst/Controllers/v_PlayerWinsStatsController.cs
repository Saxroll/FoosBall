using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Pilkarzyki_DBFirst.Models;

namespace MVC_Pilkarzyki_DBFirst.Views
{
    public class v_PlayerWinsStatsController : Controller
    {
        private FussballEntities db = new FussballEntities();

        // GET: v_PlayerWinsStats
        public ActionResult Index()
        {
            return View(db.v_PlayerWinsStats
                                            .OrderByDescending(d => d.WinsCount)
                                            .ThenBy(d => d.GamesPlayed)
                                            .ToList());
        }

        // GET: v_PlayerWinsStats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            v_PlayerWinsStats v_PlayerWinsStats = db.v_PlayerWinsStats.Find(id);
            if (v_PlayerWinsStats == null)
            {
                return HttpNotFound();
            }
            return View(v_PlayerWinsStats);
        }

        // GET: v_PlayerWinsStats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: v_PlayerWinsStats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlayerID,WinnerName,WinsCount,GamesPlayed,WinsPercentage")] v_PlayerWinsStats v_PlayerWinsStats)
        {
            if (ModelState.IsValid)
            {
                db.v_PlayerWinsStats.Add(v_PlayerWinsStats);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(v_PlayerWinsStats);
        }

        // GET: v_PlayerWinsStats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            v_PlayerWinsStats v_PlayerWinsStats = db.v_PlayerWinsStats.Find(id);
            if (v_PlayerWinsStats == null)
            {
                return HttpNotFound();
            }
            return View(v_PlayerWinsStats);
        }

        // POST: v_PlayerWinsStats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlayerID,WinnerName,WinsCount,GamesPlayed,WinsPercentage")] v_PlayerWinsStats v_PlayerWinsStats)
        {
            if (ModelState.IsValid)
            {
                db.Entry(v_PlayerWinsStats).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(v_PlayerWinsStats);
        }

        // GET: v_PlayerWinsStats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            v_PlayerWinsStats v_PlayerWinsStats = db.v_PlayerWinsStats.Find(id);
            if (v_PlayerWinsStats == null)
            {
                return HttpNotFound();
            }
            return View(v_PlayerWinsStats);
        }

        // POST: v_PlayerWinsStats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            v_PlayerWinsStats v_PlayerWinsStats = db.v_PlayerWinsStats.Find(id);
            db.v_PlayerWinsStats.Remove(v_PlayerWinsStats);
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
