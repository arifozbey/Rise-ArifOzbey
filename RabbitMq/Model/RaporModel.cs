using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class RaporModel
    {
        public Guid Id { get; set; }

        public DateTimeOffset TalepTarihi { get; set; }

        public int Durumu { get; set; }
    }
}