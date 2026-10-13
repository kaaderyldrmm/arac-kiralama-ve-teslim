using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental
{
    internal class AracKiralamaSirketi
    {
        public string SirketAd {  get; set; }
        public List<Arac> Araclar { get; set; } = new List<Arac>();
        public List<Musteri> Musteriler {  get; set; }= new List<Musteri>();
        public List<Kiralama> Kiralamalar { get; set; }=new List<Kiralama>();

        public AracKiralamaSirketi(string sirketAd)
        {
           SirketAd = sirketAd;

        }
        public AracKiralamaSirketi(string sirketAd,List<Arac> araclar, List<Musteri> musteriler, List<Kiralama> kiralamalar)
        {
            SirketAd = sirketAd;
            Araclar = araclar;
            Musteriler = musteriler;
            Kiralamalar = kiralamalar;
        }
    }
}
