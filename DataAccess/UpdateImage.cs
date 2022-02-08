using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolAssignment.DataAccess
{
    public class UpdateImage
    {
        [NotMapped]
        public IFormFile? Image { get; set; }

        [MaxLength(100)]
        public string? ImageUrl { get; set; }
    }
}