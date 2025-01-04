using System;

namespace IkiliAramaAgaci
{
    class Dugum
    {
        public int veri;
        public Dugum sol;
        public Dugum sag;

        public Dugum(int veri)
        {
            this.veri = veri;
            sol = null;
            sag = null;
        }
    }


    class Agac
    {
        private Dugum kok; // Ağacın kök düğümü

        public Agac()
        {
            kok = null;
        }

        // Ağaca eleman ekleme metodu
        public void Ekle(int veri)
        {
            kok = EkleRekursif(kok, veri);
        }

        // Rekürsif olarak ağaca eleman ekler
        private Dugum EkleRekursif(Dugum kok, int veri)
        {
            if (kok == null)
            {
                kok = new Dugum(veri);
                Console.WriteLine($"{veri} elemanı eklendi");
                return kok;
            }

            if (veri < kok.veri)
                kok.sol = EkleRekursif(kok.sol, veri); // Sol alt ağaçta ekleme
            else if (veri > kok.veri)
                kok.sag = EkleRekursif(kok.sag, veri); // Sağ alt ağaçta ekleme

            return kok;
        }

        // Ağacın içeriğinde eleman arama metodu
        public bool Ara(int veri)
        {
            return AraRekursif(kok, veri);
        }

        // Rekürsif olarak ağacın içeriğinde eleman arar
        private bool AraRekursif(Dugum kok, int veri)
        {
            if (kok == null)
                return false; // Düğüm boşsa false döner

            if (kok.veri == veri)
                return true; // Eleman bulunursa true döner

            if (veri < kok.veri)
                return AraRekursif(kok.sol, veri); // Sol alt ağaçta arama
            else
                return AraRekursif(kok.sag, veri); // Sağ alt ağaçta arama
        }

        // Ağacın düğümlerini in-order (kök ortada) yazdırma metodu
        public void InOrderYazdir()
        {
            InOrderYazdirRekursif(kok);
            Console.WriteLine();
        }

        // Rekürsif olarak ağacın düğümlerini in-order yazdırır
        private void InOrderYazdirRekursif(Dugum kok)
        {
            if (kok != null)
            {
                InOrderYazdirRekursif(kok.sol); // Sol alt ağacı yazdır
                Console.Write(kok.veri + " "); // Kök düğümü yazdır
                InOrderYazdirRekursif(kok.sag); // Sağ alt ağacı yazdır
            }
        }
        public void PostOrderYazdir()

        {
            postorderrekursif(kok); Console.WriteLine();

        }
        private void postorderrekursif(Dugum kok)
        {
            if (kok != null)
            {
                postorderrekursif(kok.sol); // Sol alt ağacı işlem
                postorderrekursif(kok.sag); // Sağ alt ağacı işlem
                Console.Write(kok.veri + " "); // Kök düğümü yazdır
            }
        }
        public void PreOrderYazdir()
        {
            preorderRekursif(kok); Console.WriteLine();

        }
        private void preorderRekursif(Dugum kok)
        {
            if (kok != null)
            {
                Console.Write(kok.veri + " "); // Kök düğümü yazdır
                preorderRekursif(kok.sol); // Sol alt ağacı işlem
                preorderRekursif(kok.sag); // Sağ alt ağacı işlem
            }
        }


        // Ağacın içeriğinde eleman silme metodu
        public void Sil(int veri)
        {
            kok = SilRekursif(kok, veri);
        }

        // Rekürsif olarak ağacın içeriğinde eleman siler
        private Dugum SilRekursif(Dugum kok, int veri)
        {
            if (kok == null)
                return kok;

            if (veri < kok.veri)
                kok.sol = SilRekursif(kok.sol, veri); // Sol alt ağaçta silme
            else if (veri > kok.veri)
                kok.sag = SilRekursif(kok.sag, veri); // Sağ alt ağaçta silme
            else
            {
                // Düğüm tek çocuklu veya çocuksuz
                if (kok.sol == null)
                    return kok.sag;
                else if (kok.sag == null)
                    return kok.sol;

                // Düğüm iki çocuklu
                kok.veri = MinDeger(kok.sag);
                kok.sag = SilRekursif(kok.sag, kok.veri);
            }

            return kok;
        }

        // Sağ alt ağacın minimum değerini bulur
        private int MinDeger(Dugum dugum)
        {
            int minv = dugum.veri;
            while (dugum.sol != null)
            {
                minv = dugum.sol.veri;
                dugum = dugum.sol;
            }
            return minv;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Agac agac = new Agac();
            bool devam = true;

            Console.WriteLine("Ağaç yapısına eleman eklemek için 1'e basın");
            Console.WriteLine("Ağaç yapısını yazdırmak için 2'ye basın");
            Console.WriteLine("Ağaç yapısındaki elemanları aramak için 3'e basın");
            Console.WriteLine("Ağaç yapısındaki elemanları silmek için 4'e basın");
            Console.WriteLine("Çıkmak için 0'a basın");

            while (devam)
            {
                int secim = Convert.ToInt32(Console.ReadLine());
                switch (secim)
                {
                    case 0:
                        Console.WriteLine("Sistem kapatılıyor");
                        devam = false;
                        break;
                    case 1:
                        Console.WriteLine("Ağaç yapısına eklemek istediğiniz değeri giriniz:");
                        int deger = Convert.ToInt32(Console.ReadLine());
                        agac.Ekle(deger);
                        break;
                    case 2:
                        Console.WriteLine("inorder şeklinde yazımı ");
                        agac.InOrderYazdir();
                        Console.WriteLine("postorder şeklinde yazımı ");
                        agac.PostOrderYazdir();
                        Console.WriteLine("preorder  şeklinde yazımı ");
                        agac.PreOrderYazdir();
                        break;
                    case 3:
                        Console.WriteLine("Aramak istediğiniz değeri giriniz:");
                        int aranan = Convert.ToInt32(Console.ReadLine());
                        bool bulundu = agac.Ara(aranan);
                        Console.WriteLine(bulundu ? $"{aranan} elemanı bulundu." : $"{aranan} elemanı bulunamadı.");
                        break;
                    case 4:
                        Console.WriteLine("Silmek istediğiniz değeri giriniz:");
                        int silinecek = Convert.ToInt32(Console.ReadLine());
                        agac.Sil(silinecek);
                        Console.WriteLine($"{silinecek} elemanı silindi.");
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim, lütfen tekrar deneyin.");
                        break;
                }
            }
        }
    }
}