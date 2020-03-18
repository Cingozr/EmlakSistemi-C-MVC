using EmlakSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmlakSistemi.EmlakYonetim.Yonetim
{
    public class UlasimYonetim
    {

        public static List<Ulasim> GetAll()
        {
            using (EmlakContext baglanti = new EmlakContext())
            {
                return baglanti.Ulasim.OrderBy(x => x.Ulasim_AD).ToList();
            }
        }

        public static Ulasim GetByID(int id)
        {
            using (EmlakContext baglanti = new EmlakContext())
            {
                return baglanti.Ulasim.Where(x => x.Ulasim_ID == id).FirstOrDefault();
            }
        }

        public static List<Ulasim> GetForUlasim(int id)
        {
            using (EmlakContext baglanti = new EmlakContext())
            {
                return baglanti.Ilanlar.Where(x => x.Ilan_ID == id).First().Ulasim.ToList();
            }
        }
    }
}