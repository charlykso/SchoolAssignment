using System.ComponentModel.DataAnnotations;

namespace SchoolAssignment.DataAccess
{
    public class UpdateLecturer
    {
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

        [Required]
        [MaxLength(255)]
        public string? Password { get; set; }

        [Required]
        public DateTime Created_at { get; set; }
    }
}