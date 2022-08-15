using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class ExcelModel
    {

        public string Konum { get; set; }

        public int RehberdekiKayitliKisiSayisi { get; set; }
        public int RehberdeKayitliTelefonSayisi { get; set; }
    }
}