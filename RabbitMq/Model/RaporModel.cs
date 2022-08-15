using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class RaporModel
    {
        public Guid Id { get; set; }

        public DateTimeOffset TalepTarihi { get; set; }
        public string Konum { get; set; }

        public int Durumu { get; set; }
        public string Dosyapath { get; set; }//dosya yolu
    }
}