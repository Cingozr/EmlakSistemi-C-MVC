using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmlakSistemi.Models;
using System.Web.Security;
using System.Threading;

namespace EmlakSistemi.Areas.FirmaPanel.Controllers
{
    public class SozlesmelersController : Controller
    {
        private EmlakContext db = new EmlakContext();

        // GET: FirmaPanel/Sozlesmelers
        public ActionResult Index()
        {           

            if (User.IsInRole("Admin"))
            {
                var AdminListe = db.Sozlesmeler
                    .Include(s => s.SozlesmeTuru)
                    .OrderBy(x => x.Sozlesme_ID);
                return View(AdminListe.ToList());
            }
            else
            {
                Guid Kullanici = (Guid)Membership.GetUser().ProviderUserKey;
                var FirmaListe = db.Sozlesmeler.Where(i => i.UserId == Kullanici)
                    .Include(s => s.SozlesmeTuru)
                    .Include(s => s.aspnet_Users)
                    .OrderBy(x => x.Sozlesme_ID);
                return View(FirmaListe.ToList());
            }
        }

        // GET: FirmaPanel/Sozlesmelers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sozlesmeler sozlesmeler = db.Sozlesmeler.Find(id);
            if (sozlesmeler == null)
            {
                return HttpNotFound();
            }
            return View(sozlesmeler);
        }

        // GET: FirmaPanel/Sozlesmelers/Create
        public ActionResult Create()
        {
            ViewBag.Sozlemetur_ID = new SelectList(db.SozlesmeTuru, "Sozlesmetur_ID", "Sozlesmetur_AD");
            return View();
        }

        // POST: FirmaPanel/Sozlesmelers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sozlesme_ID,Sozlesme_BASLIK,Sozlesme_ACIKLAMA,Sozlesme_BASTARIH,Sozlesme_BITTARIH,Sozlesme_KISIAD,Sozlesme_KISISOYAD,Mahalle_ID,Sozlesme_KAPINO,Sozlesme_PAFTANO,Sozlesme_ADANO,Sozlesme_PARSELNO,Sozlemetur_ID,UserId,Sozlesme_NO")] Sozlesmeler sozlesmeler)
        {
            if (ModelState.IsValid)
            {
                Random rastgele = new Random();
                sozlesmeler.Sozlesme_NO=rastgele.Next(1, 999999999);
                sozlesmeler.UserId = (Guid)Membership.GetUser().ProviderUserKey;
                db.Sozlesmeler.Add(sozlesmeler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.Sozlemetur_ID = new SelectList(db.SozlesmeTuru, "Sozlesmetur_ID", "Sozlesmetur_AD", sozlesmeler.Sozlemetur_ID);
            return View(sozlesmeler);
        }

        // GET: FirmaPanel/Sozlesmelers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sozlesmeler sozlesmeler = db.Sozlesmeler.Find(id);
            if (sozlesmeler == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.aspnet_Users, "UserId", "UserName", sozlesmeler.UserId);
            ViewBag.Sozlemetur_ID = new SelectList(db.SozlesmeTuru, "Sozlesmetur_ID", "Sozlesmetur_AD", sozlesmeler.Sozlemetur_ID);
            return View(sozlesmeler);
        }

        // POST: FirmaPanel/Sozlesmelers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sozlesme_ID,Sozlesme_BASLIK,Sozlesme_ACIKLAMA,Sozlesme_BASTARIH,Sozlesme_BITTARIH,Sozlesme_KISIAD,Sozlesme_KISISOYAD,Mahalle_ID,Sozlesme_KAPINO,Sozlesme_PAFTANO,Sozlesme_ADANO,Sozlesme_PARSELNO,Sozlemetur_ID,UserId,Sozlesme_NO")] Sozlesmeler sozlesmeler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sozlesmeler).State = EntityState.Modified;
                db.SaveChanges();
                Thread.Sleep(3000);
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.aspnet_Users, "UserId", "UserName", sozlesmeler.UserId);
            ViewBag.Sozlemetur_ID = new SelectList(db.SozlesmeTuru, "Sozlesmetur_ID", "Sozlesmetur_AD", sozlesmeler.Sozlemetur_ID);
            return View(sozlesmeler);
        }

        // GET: FirmaPanel/Sozlesmelers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sozlesmeler sozlesmeler = db.Sozlesmeler.Find(id);
            if (sozlesmeler == null)
            {
                return HttpNotFound();
            }
            return View(sozlesmeler);
        }

        // POST: FirmaPanel/Sozlesmelers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sozlesmeler sozlesmeler = db.Sozlesmeler.Find(id);
            db.Sozlesmeler.Remove(sozlesmeler);
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
