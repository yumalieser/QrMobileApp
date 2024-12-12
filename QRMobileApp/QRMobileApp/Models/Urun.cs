using System;
using System.Collections.Generic;
using System.Text;

namespace QRMobileApp.Models
{
    public class Urun
    {
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public decimal Fiyat { get; set; }
        public string Aciklama { get; set; }
    }
}
