using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kütüphane.Models
{
    public class KitaplarModel
    {
        public int KitapNo { get; set; }
        public string KitapAdi { get; set; }
        public string Yayinevi { get; set; }
        public string SayfaSayisi { get; set; }
        public string BasimTarihi { get; set; }
        public string YazarAdi { get; set; }

    }
}