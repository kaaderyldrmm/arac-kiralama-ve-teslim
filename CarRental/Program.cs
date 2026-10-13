using CarRental;
using System.ComponentModel;

int[] Aracİd = {1,2,3,4,5,6,7,8,9,10,11 };
string[] AracMarka = { "Volsawagen", "Mercesedes", "Opel", "Audi", "Volvo", "Hyundai", "Ford", "Fiat", "Honda", "Renault" };
string[] AracModel = { "PASSAT", "A200", "ASTRA", "Q3", "XC90", "i30", "FİESTA", "EGEA", "CİVİC", "CLİO" };
decimal[] AracFiyat = { 2000m, 3200m, 1350m, 2580m, 3300m, 1330m, 1200m, 2000m, 2100m, 1980m };

Arac[] araclar = new Arac[10];
for (int i = 0; i < araclar.Length; i++)
{
    araclar[i] = new Arac(Aracİd[i], AracMarka[i], AracModel[i], AracFiyat[i],true);
}

AracKiralamaSirketi sirket = new AracKiralamaSirketi("KONTROL ARAÇ KİRALAMA");
bool calis = true;
while (calis)
{
    Console.WriteLine($"\n============= {sirket.SirketAd.ToUpper()} SİSTEMİ =============\n");
    Console.WriteLine("1. Araçları Listele");
    Console.WriteLine("2. Müsait Araçları Göster");
    Console.WriteLine("3. Müşteri Ekle");
    Console.WriteLine("4. Araç Kirala");
    Console.WriteLine("5. Araç Teslim Et");
    Console.WriteLine("6. Aktif Kiralamaları Göster");
    Console.WriteLine("7. Rapor");
    Console.WriteLine("8. Çıkış Yap");
    Console.Write("\nseçiminiz: ");

    int secim = Convert.ToInt32(Console.ReadLine());
    switch (secim)
    {
        case 1:
            Console.WriteLine("\n---------------------------------- ARAÇ LİSTESİ -------------------------------------\n");
            Console.WriteLine($"\t{"ID",-5} {"MARKA",-15} {"MODEL",-12} {"GÜNLÜK FİYAT(TL)",-21} {"DURUM",-11}");
            Console.WriteLine("-------------------------------------------------------------------------------------");

            for (int i = 0; i < araclar.Length; i++)
            {
                string durum = araclar[i].MusaitMi ? " MÜSAİT " : " KİRADA ";
                Console.WriteLine($"\t{araclar[i].Id,-5} " + $"{araclar[i].Marka,-15} " + $"{araclar[i].Model,-12} " + $"{araclar[i].GunlukFiyat,-21:N2}" + $"{durum,-11}\n");
            }


            break;

        case 2:
            Console.WriteLine("------------------------------ MÜSAİT ARAÇLAR ---------------------------------------\n");
            Console.WriteLine($"\t{"ID",-5} {"MARKA",-15} {"MODEL",-12} {"GÜNLÜK FİYAT(TL)",-21} {"DURUM",-11}");
            Console.WriteLine("-------------------------------------------------------------------------------------");
            int a = 0;
            foreach (Arac arac in araclar)
            {
                if (arac.MusaitMi == true)
                {
                    string durum = "müsait";

                    Console.WriteLine($"\t{arac.Id,-5} {arac.Marka,-15} {arac.Model,-12} {arac.GunlukFiyat,-21} {durum,-11}");
                    a++;
                }
            }
            if (a == 0)
            {
                Console.WriteLine("Müsait araç bulunmamaktadır.");
            }
            break;
        case 3:
            Console.WriteLine("\n--------- YENİ MÜŞTERİ EKLEYİN ----------\n");
            Console.Write("Müşteri ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Müşteri ad: ");
            string yeniMusteri = Console.ReadLine();
            Console.Write("Müşteri Telefon: ");
            string telefon = Console.ReadLine();

            Musteri musteri = new Musteri(id, yeniMusteri, telefon);
            sirket.Musteriler.Add(musteri);
            Console.WriteLine("Müsteri başarıyla eklendi...");

            break;

        case 4:
            Console.WriteLine("\n------------------------------ MÜSAİT ARAÇLAR ---------------------------------------\n");
            Console.WriteLine($"\t{"ID",-5} {"MARKA",-15} {"MODEL",-12} {"GÜNLÜK FİYAT(TL)",-21} {"DURUM",-11}");
            Console.WriteLine("-------------------------------------------------------------------------------------");
            int b = 0;
            foreach (Arac arac in araclar)
            {
                if (arac.MusaitMi == true)
                {
                    string durum = "müsait";

                    Console.WriteLine($"\t{arac.Id,-5} {arac.Marka,-15} {arac.Model,-12} {arac.GunlukFiyat,-21} {durum,-11}");
                    b++;
                }
            }
            if (b == 0)
            {
                Console.WriteLine("MÜSAİT ARAÇ BULUNMAMAKTA!..");
            }
            else
            {

                Console.Write("\nKiralamak istediğiniz aracın ID numarasını giriniz: ");
                int aracİd = Convert.ToInt32(Console.ReadLine());

                Arac secilenArac = null;
                foreach (Arac arac in araclar)
                {
                    if (arac.Id == aracİd)
                    {
                        secilenArac = arac;
                        break;
                    }
                }
                if (secilenArac == null)
                {
                    Console.WriteLine("Bu ID'ye ait araç bulunamadı");
                }
                else
                {
                    Console.Write("Müsteri ID: ");
                    int musterİd = Convert.ToInt32(Console.ReadLine());

                    Musteri bulunanMusteri = null;
                    foreach (Musteri KayitliMusteri in sirket.Musteriler)
                    {
                        if (KayitliMusteri.İd == musterİd)
                        {
                            bulunanMusteri = KayitliMusteri;
                            break;
                        }
                    }
                    if (bulunanMusteri == null)
                    {
                        Console.WriteLine("Bu ID'ye sahip müşteri bulunamadı!..");
                    }
                    else
                    {
                        Console.Write("Kiralanacak gün sayısı: ");
                        int gun = Convert.ToInt32(Console.ReadLine());

                        if (gun < 0)
                        {
                            Console.WriteLine("Gün sayısı yanlış girildi");
                        }
                        else
                        {
                            decimal toplamUcret = secilenArac.GunlukFiyat * gun;
                            Kiralama yeniKiralama = new Kiralama(bulunanMusteri, secilenArac, gun, toplamUcret,true);
                            sirket.Kiralamalar.Add(yeniKiralama);

                            Console.WriteLine("\n--------- KİRALAMA BİLGİLERİ ----------\n");
                            Console.WriteLine($"Müşteri: {bulunanMusteri.Ad}");
                            Console.WriteLine($"Araç: {secilenArac.Marka} - {secilenArac.Model}");
                            Console.WriteLine($"Günlük Fiyat: {secilenArac.GunlukFiyat}");
                            Console.WriteLine($"Kiralama Süresi: {gun} gün");
                            Console.WriteLine($"Toplam Ücret: {toplamUcret:N2}TL");

                            secilenArac.Kirala();
                        }

                    }
                }

            }
            break;
        case 5:
            Console.WriteLine("\n------------ ARAÇ TESLİM İŞLEMİ ------------\n");

            Console.Write("Teslim edilecek araç ID numarası: ");
            int aracId = Convert.ToInt32(Console.ReadLine());

            Arac TeslimEdiecekArac = null;
            foreach (Arac arac in araclar)
            {
                if (arac.Id == aracId)
                {
                    TeslimEdiecekArac = arac;
                    break;
                }
            }
            if (TeslimEdiecekArac == null)
            {
                Console.WriteLine("Girilen ID numarasına ait araç bulunamadı");
            }
            else if (TeslimEdiecekArac.MusaitMi == true)
            {
                Console.WriteLine("Bu araç teslim edilemez, zaten müsait");
            }
            else
            {

                Console.WriteLine($"{TeslimEdiecekArac.Marka} - {TeslimEdiecekArac.Model} başarıyla teslim edildi!..");
                TeslimEdiecekArac.TeslimEt();
            }

            break;
        case 6:

            Console.WriteLine("\n---------------- KİRADAKİ ARAÇLAR ----------------\n");
            Console.WriteLine($"{"ID",-5} {"MARKA",-15} {"MODEL",-12} {"GÜNLÜK FİYAT(TL)",-20}");
            Console.WriteLine("---------------------------------------------------");

            int kiradakiAracSayisi = 0;

            foreach (Arac arac in araclar)
            {
                if (arac.MusaitMi == false)
                {
                    Console.WriteLine(
                        $"{arac.Id,-5} {arac.Marka,-15} {arac.Model,-12} {arac.GunlukFiyat,-20:N2}");

                    kiradakiAracSayisi++;
                }
            }

            if (kiradakiAracSayisi == 0)
            {
                Console.WriteLine("Şu anda kirada olan araç bulunmamaktadır.");
            }

            Console.WriteLine($"\nKiradaki toplam araç sayısı: {kiradakiAracSayisi}");

            break;

        case 7:

            Console.WriteLine("\n------------ ARAÇ KİRALAMA GÜN SONU RAPORU -------------\n");

            Console.WriteLine($"Toplam araç sayısı: {araclar.Length}");

            int m = 0;
            foreach (Arac arac in araclar)
            {
                if (arac.MusaitMi == true)
                {
                    m++;
                }
            }
            Console.WriteLine($"Müsait Araç Sayısı: {m}");

            int k = 0;
            foreach (Arac arac in araclar)
            {
                if (arac.MusaitMi == false)
                {
                    k++;
                }
            }
            Console.WriteLine($"Kiralanmış Araç Sayısı: {k}");
            Console.WriteLine($"Toplam Müşteri Sayısı: {sirket.Musteriler.Count}");
            Console.WriteLine($"Toplam Kiralama Sayısı: {sirket.Kiralamalar.Count}");

            decimal toplam = 0;

            foreach (Kiralama kiralama in sirket.Kiralamalar)
            {
                toplam += kiralama.ToplamOdeme;
            }
            Console.WriteLine($"Toplam Kazanılan Para: {toplam:N2}");


            Arac enPahaliarac = araclar[0];
            foreach (Arac arac in araclar)
            {
                if (arac.GunlukFiyat > enPahaliarac.GunlukFiyat)
                {
                    enPahaliarac = arac;
                }
            }
            Console.WriteLine($"En Pahalı Günlük Kiralama Ücretine Sahip Araç: {enPahaliarac.Marka} - {enPahaliarac.Model} - {enPahaliarac.GunlukFiyat} TL ");

            if (sirket.Kiralamalar.Count > 0)
            {
                Kiralama enUzunGun = sirket.Kiralamalar[0];
                foreach (Kiralama kiralama in sirket.Kiralamalar)
                {
                    if (kiralama.GunSayısı > enUzunGun.GunSayısı)
                    {
                        enUzunGun = kiralama;
                    }
                }
                Console.WriteLine($"En Uzun Süre Kiralanan Araç: {enUzunGun.Arac.Marka} {enUzunGun.Arac.Model} - {enUzunGun.GunSayısı} gün");
            }
            else
            {
                Console.WriteLine("Henüz Kiralama Kaydı Bulunmamaktadır.");
            }
    
            break;

                    case 8:
                        calis = false;
                        Console.WriteLine("ÇIKIŞ YAPILIYOR...");
                        break;

                    default:
                        Console.WriteLine("Geçersiz seçim!..");
                        break;
                    }
                    if (calis)
                    {
                        Console.WriteLine("\nİlerlemek için bir tuşa basın");
                        Console.ReadKey();
                    }
                }
Console.ReadKey();