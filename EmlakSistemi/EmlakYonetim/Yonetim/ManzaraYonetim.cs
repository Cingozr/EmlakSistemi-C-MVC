using EmlakSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmlakSistemi.EmlakYonetim.Yonetim
{
    public class ManzaraYonetim
    {
        public static List<Manzara> GetAll()
        {
            using (EmlakContext baglanti = new EmlakContext())
            {
                return baglanti.Manzara.OrderBy(x => x.Manzara_AD).ToList();
            }
        }

        public static Manzara GetByID(int id)
        {
            using (EmlakContext baglanti = new EmlakContext())
            {
                return baglanti.Manzara.Where(x => x.Manzara_ID == id).FirstOrDefault();
            }
        }

        public static List<Manzara> GetForManzara(int id)
        {
            using (EmlakContext baglanti = new EmlakContext())
            {
                return baglanti.Ilanlar.Where(x => x.Ilan_ID == id).First().Manzara.ToList();
            }
        }
    }
}