﻿using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class Uzivatel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Jmeno { get; set; }
        [Required]
        public string Heslo { get; set; }
    }
}
