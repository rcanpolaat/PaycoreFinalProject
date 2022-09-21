using System;
using System.ComponentModel.DataAnnotations;
using FinalProject.Base;

namespace FinalProject.Dto
{
    public class CategoryDto
    {

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

    }
}
