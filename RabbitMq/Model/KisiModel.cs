using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class KisiDetayModels
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Adı is required.")]
        [StringLength(240, ErrorMessage = "Name cannot be longer than 240 characters.")]
        public string Adi { get; set; }

        [Required(ErrorMessage = "Soyadı is required.")]
        [StringLength(240, ErrorMessage = "Name cannot be longer than 240 characters.")]
        public string Soyadi { get; set; }

        [Required(ErrorMessage = "Firma is required.")]
        [StringLength(240, ErrorMessage = "Name cannot be longer than 240 characters.")]
        public string Firma { get; set; }

    }
}