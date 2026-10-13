using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental
{
    internal class Kiralama
    {
        public Musteri Musteri { get; set; }
        public Arac Arac { get; set; }
        public int GunSayısı { get; set; }
        public decimal ToplamOdeme { get; set; }
        public bool AktifMi { get; set; }

        public Kiralama(Musteri musteri, Arac arac, int gunSayisi, decimal toplamUcret, bool aktifMi)
        {
            Musteri = musteri;
            Arac = arac;
            GunSayısı = gunSayisi;
            ToplamOdeme = toplamUcret;
            AktifMi = true;

        }
    }
}
