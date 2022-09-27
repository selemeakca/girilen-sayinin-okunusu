using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write("Sayıyı Girin:");
            decimal sayi = Convert.ToDecimal(Console.ReadLine());            
            Console.WriteLine(sayi);
            Console.WriteLine(yaziyaCevir(sayi)); 
        }
            public static  string yaziyaCevir(decimal tutar)
            {
                string girilen = tutar.ToString("F2").Replace('.', ','); 
                string gelensayi = girilen.Substring(0, girilen.IndexOf(',')); 
               
                string yazi = "";

                string[] birler = { "", "BİR", "İKİ", "Üç", "DÖRT", "BEŞ", "ALTI", "YEDİ", "SEKİZ", "DOKUZ" };
                string[] onlar = { "", "ON", "YİRMİ", "OTUZ", "KIRK", "ELLİ", "ALTMIŞ", "YETMİŞ", "SEKSEN", "DOKSAN" };
                string[] binler = { "KATRİLYON", "TRİLYON", "MİLYAR", "MİLYON", "BİN", "" }; //KATRİLYON'un önüne ekleme yapılarak artırabilir.

                int grupSayisi = 6; //sayıdaki 3'lü grup sayısı. katrilyon içi 6. (1.234,00 daki grup sayısı 2'dir.)
                                    //KATRİLYON'un başına ekleyeceğiniz her değer için grup sayısını artırınız.

                gelensayi = gelensayi.PadLeft(grupSayisi * 3, '0'); //sayının soluna '0' eklenerek sayı 'grup sayısı x 3' basakmaklı yapılıyor.            

                string grupDegeri;

                for (int i = 0; i < grupSayisi * 3; i += 3) //sayı 3'erli gruplar halinde ele alınıyor.
                {
                    grupDegeri = "";

                    if (gelensayi.Substring(i, 1) != "0")
                        grupDegeri += birler[Convert.ToInt32(gelensayi.Substring(i, 1))] + "YÜZ"; //yüzler                

                    if (grupDegeri == "BİRYÜZ") //biryüz düzeltiliyor.
                        grupDegeri = "YÜZ";

                    grupDegeri += onlar[Convert.ToInt32(gelensayi.Substring(i + 1, 1))]; //onlar

                    grupDegeri += birler[Convert.ToInt32(gelensayi.Substring(i + 2, 1))]; //birler                

                    if (grupDegeri != "") //binler
                        grupDegeri += binler[i / 3];

                    if (grupDegeri == "BİRBİN") //birbin düzeltiliyor.
                        grupDegeri = "BİN";

                    yazi += grupDegeri;
                }

                if (yazi != "")
                    yazi += " ";

                int yaziUzunlugu = yazi.Length;              

                if (yazi.Length > yaziUzunlugu)
                    yazi += " ";
                else
                    yazi += "";

                return yazi;
            }
        }
    }


