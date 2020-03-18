using EmlakSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmlakSistemi.EmlakYonetim.Yonetim
{
    public class DisOzellikYonetim
    {
        public static List<DisOzellik> GetAll()
        {
            using (EmlakContext baglanti = new EmlakContext())
            {
                return baglanti.DisOzellik.OrderBy(x => x.DisOzellik_AD).ToList();
            }
        }

        public static DisOzellik GetByID(int id)
        {
            using (EmlakContext baglanti = new EmlakContext())
            {
                return baglanti.DisOzellik.Where(x => x.DisOzellik_ID == id).FirstOrDefault();
            }
        }

        public static List<DisOzellik> GetForDis(int id)
        {
            using (EmlakContext baglanti = new EmlakContext())
            {
                return baglanti.Ilanlar.Where(x => x.Ilan_ID == id).First().DisOzellik.ToList();
            }
        }
    }
}