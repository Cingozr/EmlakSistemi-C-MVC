using EmlakSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmlakSistemi.EmlakYonetim.Yonetim
{
    public class CepheYonetim
    {
        public static List<Cephe> GetAll()
        {
            using (EmlakContext baglanti = new EmlakContext())
            {
                return baglanti.Cephe.OrderBy(x => x.Cephe_AD).ToList();
            }
        }

        public static Cephe GetByID(int id)
        {
            using (EmlakContext baglanti = new EmlakContext())
            {
                return baglanti.Cephe.Where(x => x.Cephe_ID == id).FirstOrDefault();
            }
        }

        public static List<Cephe> GetForCephe(int id)
        {
            using (EmlakContext baglanti = new EmlakContext())
            {
                return baglanti.Ilanlar.Where(x => x.Ilan_ID == id).First().Cephe.ToList();
            }
        }
    }
}