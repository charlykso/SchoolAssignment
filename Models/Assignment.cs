using System.ComponentModel.DataAnnotations;

namespace HomeWork.Models
{
    public class Assignment
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string? CourseCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string? CourseTitle { get; set; }

        [Required]
        [MaxLength(10)]
        public int Level { get; set; }

        [Required]
        [MaxLength(3)]
        public int TotalMark { get; set; }

        [Required]
        [MaxLength(10)]
        public string? DueDate { get; set; }

        [Required]
        public DateTime Created_at { get; set; }

        public Lecturer? Lecturer { get; set; }
        public ICollection<Submission>? Submitted_Assignment { get; set; }
    }
}