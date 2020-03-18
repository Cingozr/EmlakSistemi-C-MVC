using EmlakSistemi.EmlakYonetim.Yonetim;
using EmlakSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EmlakSistemi.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        #region Model Bağlantısı
            private readonly EmlakContext baglanti = new EmlakContext();
        #endregion

        //Deneme Mesaj Olacakmı ki jkhkj
        #region Giriş Sayfası GET
        public ActionResult Giris()
            {
                return View();
            }
        #endregion

        #region Giriş Sayfası POST
        [HttpPost]
        public ActionResult GirisYap(FirmaYonetimi FirmaModel, string BeniHatirla)
        {
            bool Sonuc = Membership.ValidateUser(FirmaModel.Firma_TAMAD, FirmaModel.Firma_PAROLA);
            if (Sonuc)
            {
                if (BeniHatirla == "on")
                {
                    FormsAuthentication.RedirectFromLoginPage(FirmaModel.Firma_TAMAD, true);
                }
                else
                {
                    FormsAuthentication.RedirectFromLoginPage(FirmaModel.Firma_TAMAD, false);
                }
                Session["Firma_TAMAD"] = FirmaModel.Firma_TAMAD.ToString();
                return RedirectToAction("Index", "Anasayfa", new { area = "FirmaPanel" });
                

            }
            else
            {
                ViewBag.Mesaj = "Kullanıcı Adı veya Parola Hatalı!";
                return View();
            }

        }
        #endregion

        #region Kayıt Ol GET
        public ActionResult KayitOl()
        {
            return View();
        }
        #endregion

        #region KayıtOl POST
        [HttpPost]
        public ActionResult KayitOl(FirmaYonetimi FirmaModel)
        {
            MembershipCreateStatus Durum;
            Membership.CreateUser(
                FirmaModel.Firma_TAMAD,
                FirmaModel.Firma_PAROLA,
                FirmaModel.Firma_EMAIL,
                FirmaModel.Gizli_SORU,
                FirmaModel.Gizli_CEVAP, true, out Durum);
            string Mesaj = "";
            switch (Durum)
            {
                case MembershipCreateStatus.Success:

                    break;
                case MembershipCreateStatus.InvalidUserName:
                    Mesaj += "Kullanılmış Kullanıcı Adı";
                    break;
                case MembershipCreateStatus.InvalidPassword:
                    Mesaj += "Hatalı Parola Girdiniz";
                    break;
                case MembershipCreateStatus.InvalidQuestion:
                    Mesaj += "Hatalı Gizli Soru Girdiniz";
                    break;
                case MembershipCreateStatus.InvalidAnswer:
                    Mesaj += "Hatalı Gizli Cevap Girdiniz";
                    break;
                case MembershipCreateStatus.InvalidEmail:
                    Mesaj += "Hatalı E-Mail Girdiniz";
                    break;
                case MembershipCreateStatus.DuplicateUserName:
                    Mesaj += "Geçersiz Kullanıcı Adı Girdiniz | Daha Önce Kayıtlı Kullanıcı Adı";
                    break;
                case MembershipCreateStatus.DuplicateEmail:
                    Mesaj += "Geçersiz E-Mail Girdiniz";
                    break;
                case MembershipCreateStatus.UserRejected:
                    Mesaj += "Geçersiz Kullanıcı Geri-Dönüş";
                    break;
                case MembershipCreateStatus.InvalidProviderUserKey:
                    Mesaj += "Geçersiz Kullanıcı Key ";
                    break;
                case MembershipCreateStatus.DuplicateProviderUserKey:
                    Mesaj += "Geçersiz Kullanıcı Key ";
                    break;
                case MembershipCreateStatus.ProviderError:
                    Mesaj += "Hatalı Üye Yönetim Sağlayıcısı";
                    break;
                default:
                    break;

            }
            ViewBag.Mesaj = Mesaj;
            if (Durum == MembershipCreateStatus.Success)
            {
                return RedirectToAction("Index", "Anasayfa", new { area = "FirmaPanel" });
            }
            else
            {
                return View();
            }
        }
        #endregion

        #region Çıkış Yapma
        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Giris","Uye");
        }
        #endregion

        #region Parolamı Unuttum GET
        public ActionResult ParolamiUnuttum()
        {
            return View();
        }
        #endregion

        #region Parolamı Unuttum POST
        [HttpPost]
        public ActionResult ParolamiUnuttum(FirmaYonetimi FirmaModel)
        {
            MembershipUser Firma = Membership.GetUser(FirmaModel.Firma_TAMAD);
            if (Firma.PasswordQuestion == FirmaModel.Gizli_SORU)
            {
                string ParolaSifirla = Firma.ResetPassword(FirmaModel.Gizli_CEVAP);
                Firma.ChangePassword(ParolaSifirla, FirmaModel.Firma_PAROLA);
                return RedirectToAction("Index", "Anasayfa", new { area = "FirmaPanel" });

            }
            else
            {
                ViewBag.Mesaj = "Girilen Bilgiler Yanlıştır ! ";
                return View();
            }


        }
        #endregion

    }
}