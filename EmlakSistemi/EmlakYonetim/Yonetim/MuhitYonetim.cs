using EmlakSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmlakSistemi.EmlakYonetim.Yonetim
{
    public class MuhitYonetim
    {

        public static List<Muhit> GetAll()
        {
            using (EmlakContext baglanti = new EmlakContext())
            {
                return baglanti.Muhit.OrderBy(x => x.Muhit_AD).ToList();
            }
        }

        public static Muhit GetByID(int id)
        {
            using (EmlakContext baglanti = new EmlakContext())
            {
                return baglanti.Muhit.Where(x => x.Muhit_ID == id).FirstOrDefault();
            }
        }

        public static List<Muhit> GetForMuhit(int id)
        {
            using (EmlakContext baglanti = new EmlakContext())
            {
                return baglanti.Ilanlar.Where(x => x.Ilan_ID == id).First().Muhit.ToList();
            }
        }
    }
}