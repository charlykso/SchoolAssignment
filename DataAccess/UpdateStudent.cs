using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolAssignment.DataAccess
{
    public class UpdateStudent
    {
        [Required]
        [MaxLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string? LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Email { get; set; }

        [Required]
        [MaxLength(15)]
        public string? Phone_no { get; set; }

        [Required]
        [MaxLength(20)]
        public string? DOB { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Matric_no { get; set; }

        [Required]
        [MaxLength(10)]
        public string? Level { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Password { get; set; }
    }
}