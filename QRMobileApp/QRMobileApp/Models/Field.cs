using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace QRMobileApp.Models
{
    public class Field
    {
        [JsonProperty("doubleValue")]
        public double? DoubleValue { get; set; } // Double değer (Fiyat)

        [JsonProperty("integerValue")]
        public string IntegerValue { get; set; } // Integer değer (Fiyat için alternatif)

        [JsonProperty("stringValue")]
        public string StringValue { get; set; } // String değer (Ürün adı)
    }
}
