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
    public class v_TeamWinsStatsController : Controller
    {
        private FussballEntities db = new FussballEntities();

        // GET: v_TeamWinsStats
        public ActionResult Index()
        {
            return View(db.v_TeamWinsStats
                                            .OrderByDescending(d => d.WinsCount)
                                            .ThenBy(d => d.PlayedGamesCount)
                                            .ToList());
        }

        // GET: v_TeamWinsStats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            v_TeamWinsStats v_TeamWinsStats = db.v_TeamWinsStats.Find(id);
            if (v_TeamWinsStats == null)
            {
                return HttpNotFound();
            }
            return View(v_TeamWinsStats);
        }

        // GET: v_TeamWinsStats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: v_TeamWinsStats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeamID,WinningTeamName,WinsCount,PlayedGamesCount,PercentageOfWins")] v_TeamWinsStats v_TeamWinsStats)
        {
            if (ModelState.IsValid)
            {
                db.v_TeamWinsStats.Add(v_TeamWinsStats);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(v_TeamWinsStats);
        }

        // GET: v_TeamWinsStats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            v_TeamWinsStats v_TeamWinsStats = db.v_TeamWinsStats.Find(id);
            if (v_TeamWinsStats == null)
            {
                return HttpNotFound();
            }
            return View(v_TeamWinsStats);
        }

        // POST: v_TeamWinsStats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeamID,WinningTeamName,WinsCount,PlayedGamesCount,PercentageOfWins")] v_TeamWinsStats v_TeamWinsStats)
        {
            if (ModelState.IsValid)
            {
                db.Entry(v_TeamWinsStats).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(v_TeamWinsStats);
        }

        // GET: v_TeamWinsStats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            v_TeamWinsStats v_TeamWinsStats = db.v_TeamWinsStats.Find(id);
            if (v_TeamWinsStats == null)
            {
                return HttpNotFound();
            }
            return View(v_TeamWinsStats);
        }

        // POST: v_TeamWinsStats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            v_TeamWinsStats v_TeamWinsStats = db.v_TeamWinsStats.Find(id);
            db.v_TeamWinsStats.Remove(v_TeamWinsStats);
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
