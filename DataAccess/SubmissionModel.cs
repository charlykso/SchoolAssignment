using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HomeWork.Models;

namespace SchoolAssignment.DataAccess
{
    public class SubmissionModel
    {
        public int Id { get; set; }

        [NotMapped]
        public IFormFile? AssingmentFile { get; set; }

        [MaxLength(100)]
        public string? AssingmentFileUrl { get; set; }

        public DateTime Date_Submitted { get; set; }

        public Student? Students { get; set; }
        public int? StudentId { get; set; }
        public int? AssignmentId { get; set; }

    }
}