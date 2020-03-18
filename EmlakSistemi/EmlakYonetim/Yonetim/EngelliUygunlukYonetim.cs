using EmlakSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmlakSistemi.EmlakYonetim.Yonetim
{
    public class EngelliUygunlukYonetim
    {

        public static List<EngelliUygunluk> GetAll()
        {
            using (EmlakContext baglanti = new EmlakContext())
            {
                return baglanti.EngelliUygunluk.OrderBy(x => x.EngelliUygunluk_AD).ToList();
            }
        }

        public static EngelliUygunluk GetByID(int id)
        {
            using (EmlakContext baglanti = new EmlakContext())
            {
                return baglanti.EngelliUygunluk.Where(x => x.EngelliUygunluk_ID == id).FirstOrDefault();
            }
        }

        public static List<EngelliUygunluk> GetForEngelliUygunluk(int id)
        {
            using (EmlakContext baglanti = new EmlakContext())
            {
                return baglanti.Ilanlar.Where(x => x.Ilan_ID == id).First().EngelliUygunluk.ToList();
            }
        }
    }
}