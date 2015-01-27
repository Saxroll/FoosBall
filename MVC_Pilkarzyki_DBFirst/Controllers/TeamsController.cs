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
    public class TeamsController : Controller
    {
        private FussballEntities db = new FussballEntities();

        // GET: Teams
        public ActionResult Index()
        {
            var teams = db.Teams.Include(t => t.Players).Include(t => t.Players1);
            return View(teams.OrderBy(t => t.Players.Nickname).ToList());
        }

        // GET: Teams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teams teams = db.Teams.Find(id);
            if (teams == null)
            {
                return HttpNotFound();
            }
            return View(teams);
        }

        // GET: Teams/Create
        public ActionResult Create()
        {
            ViewBag.GoalKeeperID = new SelectList(db.Players, "PlayerID", "Nickname");
            ViewBag.AttackerID = new SelectList(db.Players, "PlayerID", "Nickname");
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeamID,GoalKeeperID,AttackerID,TeamName,ModifiedDate")] Teams teams)
        {
            if (ModelState.IsValid)
            {
                teams.ModifiedDate = System.DateTime.Now;
                db.Teams.Add(teams);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GoalKeeperID = new SelectList(db.Players, "PlayerID", "Nickname", teams.GoalKeeperID);
            ViewBag.AttackerID = new SelectList(db.Players, "PlayerID", "Nickname", teams.AttackerID);
            return View(teams);
        }

        // GET: Teams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teams teams = db.Teams.Find(id);
            if (teams == null)
            {
                return HttpNotFound();
            }
            ViewBag.GoalKeeperID = new SelectList(db.Players, "PlayerID", "Nickname", teams.GoalKeeperID);
            ViewBag.AttackerID = new SelectList(db.Players, "PlayerID", "Nickname", teams.AttackerID);
            return View(teams);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeamID,GoalKeeperID,AttackerID,TeamName,ModifiedDate")] Teams teams)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teams).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GoalKeeperID = new SelectList(db.Players, "PlayerID", "Nickname", teams.GoalKeeperID);
            ViewBag.AttackerID = new SelectList(db.Players, "PlayerID", "Nickname", teams.AttackerID);
            return View(teams);
        }

        // GET: Teams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teams teams = db.Teams.Find(id);
            if (teams == null)
            {
                return HttpNotFound();
            }
            return View(teams);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teams teams = db.Teams.Find(id);
            db.Teams.Remove(teams);
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
