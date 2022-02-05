using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeWork.DataAccess
{
    public class UOrCStudentModel
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

        [NotMapped]
        public IFormFile? Image { get; set; }

        [MaxLength(100)]
        public string? ImageUrl { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Password { get; set; }
    }
}