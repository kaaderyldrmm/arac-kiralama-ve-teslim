using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental
{
    internal class Musteri
    {
        public int İd {  get; set; }
        public string Ad {  get; set; }
        public string Telefon {  get; set; }

        public Musteri(int id, string ad, string telefon)
        {
            İd = id;
            Ad= ad;
            Telefon = telefon;
        }
    }
}
