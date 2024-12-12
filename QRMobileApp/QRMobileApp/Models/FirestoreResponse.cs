using System;
using System.Collections.Generic;
using System.Text;

namespace QRMobileApp.Models
{
    public class FirestoreResponse
    {
        public List<Document> Documents { get; set; } // Firestore'dan gelen belgelerin listesi

    }
}
