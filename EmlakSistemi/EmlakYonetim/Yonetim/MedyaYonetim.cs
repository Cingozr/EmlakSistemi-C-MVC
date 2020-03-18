using EmlakSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmlakSistemi.EmlakYonetim.Yonetim
{
    public class MedyaYonetim
    {
        public static List<Medya> GetAll()
        {
            using (EmlakContext baglanti = new EmlakContext())
            {
                return baglanti.Medya.OrderBy(x => x.Medya_AD).ToList();
            }
        }

        public static Medya GetByID(int id)
        {
            using (EmlakContext baglanti = new EmlakContext())
            {
                return baglanti.Medya.Where(x => x.Medya_ID == id).FirstOrDefault();
            }
        }

        public static List<Medya> GetForCephe(int id)
        {
            using (EmlakContext baglanti = new EmlakContext())
            {
                return baglanti.Ilanlar.Where(x => x.Ilan_ID == id).First().Medya.ToList();
            }
        }
    }
}