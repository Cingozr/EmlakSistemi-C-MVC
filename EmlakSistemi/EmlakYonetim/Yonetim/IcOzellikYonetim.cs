using EmlakSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmlakSistemi.EmlakYonetim.Yonetim
{
    public static class IcOzellikYonetim
    {
        public static List<IcOzellik> GetAll()
        {
            using (EmlakContext baglanti = new EmlakContext())
            {
                return baglanti.IcOzellik.OrderBy(x => x.IcOzellik_AD).ToList();
            }
        }

        public static IcOzellik GetByID(int id)
        {
            using (EmlakContext baglanti = new EmlakContext())
            {
                return baglanti.IcOzellik.Where(x => x.IcOzellik_ID == id).First();
            }
        }

        public static List<IcOzellik> GetForIC(int id)
        {
            using (EmlakContext baglanti = new EmlakContext())
            {
                return baglanti.Ilanlar.Where(x => x.Ilan_ID == id).First().IcOzellik.ToList();
            }
        }
    }
}