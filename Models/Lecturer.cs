using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeWork.Models
{
    public class Lecturer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string? Title { get; set; }

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
        [MaxLength(10)]
        public string? CourseCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string? CourseTitle { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Password { get; set; }

        [Required]
        public DateTime Created_at { get; set; }

        public ICollection<Assignment>? Assignments { get; set; }

    }
}