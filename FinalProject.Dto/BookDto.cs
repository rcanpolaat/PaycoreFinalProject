using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FinalProject.Base;

namespace FinalProject.Dto
{
    public class BookDto
    {

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public string CategoryId { get; set; }

        [Required]
        [MaxLength(10)]
        public string Color { get; set; }

        [Required]
        [MaxLength(30)]
        public string Brand { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public bool IsOfferable { get; set; }

        [Required]
        public bool IsSold { get; set; }

    }
}
