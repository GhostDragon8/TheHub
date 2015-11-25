using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheHub.Models;

namespace TheHub.Controllers
{
    public class MembersController : Controller
    {
        //private MemberDbContext db = new MemberDbContext();
        private IToDoRepository memberRepository;

        public MembersController()
        {
            this.memberRepository = new ToDoRepository(new MemberDbContext());
        }

        // GET: Members
        public ActionResult Index()
        {
            //var member = db.Member.Include(m => m.Profile);
            var member = memberRepository.GetAll();
            return View(member.ToList());
        }

        // GET: Members/Details/5

        public ViewResult Details(int id)
        {
            Member member = memberRepository.GetMemberByID(id);
            return View(member);
        }    

        /*
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Member.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }
        */

        // GET: Members/Create
        public ActionResult Create()
        {
           // ViewBag.MemberID = new SelectList(db.Profiles, "ProfID", "Bio");
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MemberID,HeroName,UserName,DateJoined,LastLogin,ProfileID")] Member member)
        {
            if (ModelState.IsValid)
            {
                //db.Member.Add(member);
                //db.SaveChanges();
                memberRepository.AddMember(member);
                memberRepository.Save();
                return RedirectToAction("Index");
            }

            //ViewBag.MemberID = new SelectList(db.Profiles, "ProfID", "Bio", member.MemberID);
            return View(member);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int memberId)
        {
            /*
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Member.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberID = new SelectList(db.Profiles, "ProfID", "Bio", member.MemberID);
            return View(member);
            */
            Member member = memberRepository.GetMemberByID(memberId);
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MemberID,HeroName,UserName,DateJoined,LastLogin,ProfileID")] Member member)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(member).State = EntityState.Modified;
                //db.SaveChanges();
                memberRepository.UpdateMember(member);
                memberRepository.Save();
                return RedirectToAction("Index");
            }
            //ViewBag.MemberID = new SelectList(db.Profiles, "ProfID", "Bio", member.MemberID);
            return View(member);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int memberId)
        {
            if (memberId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Member member = db.Member.Find(id);
            Member member = memberRepository.GetMemberByID(memberId);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int memberId)
        {
            //Member member = db.Member.Find(id);
            //db.Member.Remove(member);
            //db.SaveChanges();

            Member member = memberRepository.GetMemberByID(memberId);
            memberRepository.DeleteMember(memberId);
            memberRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                memberRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
