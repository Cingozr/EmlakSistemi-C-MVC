using DevExpress.Web.Mvc;
using EmlakSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity;

namespace EmlakSistemi.Areas.FirmaPanel.Controllers
{
    [Authorize]
    public class AnasayfaController : Controller
    {
        // GET: FirmaPanel/Anasayfa
        private readonly EmlakContext baglanti = new EmlakContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Modal()
        {
            return View();
        }

        public ActionResult Formhazir()
        {
            return View();
        }

        public ActionResult Tumilanlar()
        {
            

            if (User.IsInRole("Admin"))
            {
                var AdminListe = baglanti.Ilanlar
                    .Include(i => i.AnaKategori)
                    .Include(i => i.AnaKategori.AltKategori)
                    .Include(i => i.AnaKategori.AltKategori.Kategoriler)
                    .Include(i => i.aspnet_Users)
                    .Include(i => i.BinaYasBilgisi)
                    .Include(i => i.DurumBilgisi)
                    .Include(i => i.IsıtmaBilgisi)
                    .Include(i => i.KatBilgisi)
                    .Include(i => i.Lokasyon)
                    .Include(i => i.Mahalle)
                    .Include(i => i.Mahalle.ilceler)
                    .Include(i => i.Mahalle.ilceler.iller)
                    .Include(i => i.OdaBilgisi).OrderBy(x=>x.Ilan_ID);
                return View(AdminListe.ToList());
            }
            else
            {
                Guid Kullanici = (Guid)Membership.GetUser().ProviderUserKey;
                var  Firmaliste = baglanti.Ilanlar
                    .Include(i => i.AnaKategori)
                    .Include(i => i.AnaKategori.AltKategori)
                    .Include(i => i.aspnet_Users)
                    .Include(i => i.BinaYasBilgisi)
                    .Include(i => i.DurumBilgisi)
                    .Include(i => i.IsıtmaBilgisi)
                    .Include(i => i.KatBilgisi)
                    .Include(i => i.Lokasyon)
                    .Include(i => i.Mahalle)
                    .Include(i => i.Mahalle.ilceler)
                    .Include(i => i.Mahalle.ilceler.iller)
                    .Include(i => i.OdaBilgisi);
                return View(Firmaliste.ToList());
            }          
            
        }

        public ActionResult FirmaProfil()
        {
            return View();
        }

        public ActionResult FirmaSil()
        {

            return View();
        }

        public ActionResult Mesaj()
        {
            return View();
        }

        public ActionResult Ajanda()
        {
            return View();
        }

        public ActionResult TumFirmalar()
        {
            MembershipUserCollection Firmalar = Membership.GetAllUsers();
            return View(Firmalar);
        }
        public ActionResult Roller()
        {
            List<string> Roller = Roles.GetAllRoles().ToList();
            return View(Roller);
        }

        public ActionResult RolEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RolEkle(string Rol_AD)
        {
            Roles.CreateRole(Rol_AD);
            return RedirectToAction("Roller");
        }

        public ActionResult RolAta()
        {
            ViewBag.Roller = Roles.GetAllRoles().ToList();
            ViewBag.Firmalar = Membership.GetAllUsers();
            return View();
        }

        [HttpPost]
        public ActionResult RolAta(string Kullanici_TAMAD, string Rol_AD)
        {
            Roles.AddUserToRole(Kullanici_TAMAD, Rol_AD);
            return RedirectToAction("TumFirmalar");

        }

        [HttpPost]
        public string UyeRolleri(string Kullanici_TAMAD)
        {
            List<string> Roller = Roles.GetRolesForUser(Kullanici_TAMAD).ToList();
            string Rol = "";
            foreach (string r in Roller)
            {
                Rol += r + "-";
            }
            Rol = Rol.Remove(Rol.Length - 1, 1);
            return Rol;
        }       

        public ActionResult TumOzellikler()
        {
            return View();
        }

        public ActionResult Mesajlar()
        {
            return View(baglanti.Mesaj.ToList());
        }

    }

}