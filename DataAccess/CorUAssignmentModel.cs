using System.ComponentModel.DataAnnotations;
using HomeWork.Models;

namespace SchoolAssignment.DataAccess
{
    public class CorUAssignmentModel
    {
 

        [Required]
        public string? Question { get; set; }

        [Required]
        public int Level { get; set; }

        [Required]
        public int TotalMark { get; set; }

        [Required]
        [MaxLength(10)]
        public string? DueDate { get; set; }

        public Lecturer? Lecturer { get; set; }
    }
}