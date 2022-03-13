using System.ComponentModel.DataAnnotations;

namespace SchoolAssignment.DataAccess
{
    public class CorUAssignmentModel
    {
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
    }
}