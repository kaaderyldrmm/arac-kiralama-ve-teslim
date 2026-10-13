using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental
{
    internal class Arac
    {
        public int Id { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public bool MusaitMi { get; set; }
        private decimal gunlukFiyat;

        public decimal GunlukFiyat
        {
            get
            {
                return gunlukFiyat;
            }
            set
            {
                if (value >= 0)
                {
                    gunlukFiyat = value;
                }
                else
                {
                    throw new ArgumentException("Günlük fiyat negatif olamaz.");
                }

            }
        }
        public Arac(int id, string marka, string model, decimal fiyat, bool musaitMi)
        {
            Id = id;
            Marka = marka;
            Model = model;
            GunlukFiyat = fiyat;
            MusaitMi = musaitMi;
        }
        public void Kirala()
        {
            if (MusaitMi == false)
            {
                Console.WriteLine("bu araç zaten kirada");
                return;
            }
            MusaitMi = false;
            Console.WriteLine("Araç başarıyla kiralandı...");
        }
        public void TeslimEt()
        {
            if (MusaitMi == true)
            {
                Console.WriteLine("Bu araç zaten müsait");
                return;
            }
            MusaitMi = true;
            Console.WriteLine("Araç başarıyla teslim edildi...");
        }
    }
}

