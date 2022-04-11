using System.ComponentModel.DataAnnotations;
using HomeWork.Models;

namespace SchoolAssignment.DataAccess
{
    public class AssignmentModel
    {
        public int Id { get; set; }


        [Required]
        public string? Question { get; set; }

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

        public int? LecturerId { get; set; }
        public Lecturer? Lecturer { get; set; }
    }
}