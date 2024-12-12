using System;
using System.Collections.Generic;
using System.Text;

namespace QRMobileApp.Models
{
    public class Document
    {
        public string Name { get; set; } // Belge adı (Firestore'daki belge referansı)
        public Fields Fields { get; set; } // Belge içindeki alanlar
    }
}
