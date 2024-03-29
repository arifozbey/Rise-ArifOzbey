﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class KisiDetayModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "TelefonNo is required.")]
        [StringLength(40, ErrorMessage = "TelefonNo cannot be longer than 40 characters.")]
        public string TelefonNo { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [StringLength(240, ErrorMessage = "Email cannot be longer than 240 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Konum is required.")]
        [StringLength(240, ErrorMessage = "Konum cannot be longer than 240 characters.")]
        public string Konum { get; set; }

        [Required(ErrorMessage = "Icerik is required.")]
        [StringLength(140, ErrorMessage = "Icerik cannot be longer than 140 characters.")]
        public string Icerik { get; set; }
        public Guid KisiID { get; set; }

    }
}