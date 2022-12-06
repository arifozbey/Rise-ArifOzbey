using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class RaporSonucDTO
    {
        public Guid Id { get; set; }

        public string Konum { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Firma { get; set; }
        public int RehberdekiKayitliKisiSayisi { get; set; }
        public int RehberdeKayitliTelefonSayisi { get; set; }
    }
}