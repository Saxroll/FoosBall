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
    public class ScoresController : Controller
    {
        private FussballEntities db = new FussballEntities();

        // GET: Scores
        public ActionResult Index()
        {
            var scores = db.Scores
                                    .Include(s => s.Teams)
                                    .Include(s => s.Teams1)
                                    .OrderByDescending(s => s.ModifiedDate);
            
            return View(scores.ToList());
        }

        // GET: Scores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scores scores = db.Scores.Find(id);
            if (scores == null)
            {
                return HttpNotFound();
            }
            return View(scores);
        }

        // GET: Scores/Create
        public ActionResult Create()
        {
            ViewBag.FirstTeamID = new SelectList(db.Teams.OrderBy(t => t.TeamName), "TeamID", "TeamName");
            ViewBag.SecondTeamID = new SelectList(db.Teams.OrderBy(t => t.TeamName), "TeamID", "TeamName");
            return View();
        }

        // POST: Scores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ScoreID,FirstTeamID,SecondTeamID,FirstTeamScore,SecondTeamScore,ModifiedDate")] Scores scores)
        {
            if (ModelState.IsValid)
            {
                scores.ModifiedDate = System.DateTime.Now;
                db.Scores.Add(scores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FirstTeamID = new SelectList(db.Teams.OrderBy(t => t.TeamName), "TeamID", "TeamName", scores.FirstTeamID);
            ViewBag.SecondTeamID = new SelectList(db.Teams.OrderBy(t => t.TeamName), "TeamID", "TeamName", scores.SecondTeamID);
            return View(scores);
        }

        // GET: Scores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scores scores = db.Scores.Find(id);
            if (scores == null)
            {
                return HttpNotFound();
            }
            ViewBag.FirstTeamID = new SelectList(db.Teams, "TeamID", "TeamName", scores.FirstTeamID);
            ViewBag.SecondTeamID = new SelectList(db.Teams, "TeamID", "TeamName", scores.SecondTeamID);
            return View(scores);
        }

        // POST: Scores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ScoreID,FirstTeamID,SecondTeamID,FirstTeamScore,SecondTeamScore,ModifiedDate")] Scores scores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FirstTeamID = new SelectList(db.Teams, "TeamID", "TeamName", scores.FirstTeamID);
            ViewBag.SecondTeamID = new SelectList(db.Teams, "TeamID", "TeamName", scores.SecondTeamID);
            return View(scores);
        }

        // GET: Scores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scores scores = db.Scores.Find(id);
            if (scores == null)
            {
                return HttpNotFound();
            }
            return View(scores);
        }

        // POST: Scores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Scores scores = db.Scores.Find(id);
            db.Scores.Remove(scores);
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
