using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class KisiModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Adı is required.")]
        [StringLength(240, ErrorMessage = "Name cannot be longer than 240 characters.")]
        public string Adı { get; set; }

        [Required(ErrorMessage = "Soyadı is required.")]
        [StringLength(240, ErrorMessage = "Name cannot be longer than 240 characters.")]
        public string Soyadı { get; set; }

        [Required(ErrorMessage = "Firma is required.")]
        [StringLength(240, ErrorMessage = "Name cannot be longer than 240 characters.")]
        public string Firma { get; set; }

        public Guid KisiDetayID { get; set; }
    }
}