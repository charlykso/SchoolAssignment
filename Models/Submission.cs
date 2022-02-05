using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeWork.Models
{
    public class Submission
    {
        public int Id { get; set; }

        [NotMapped]
        public IFormFile? AssingmentFile { get; set; }

        [MaxLength(100)]
        public string? AssingmentFileUrl { get; set; }

        [MaxLength(10)]
        public string? DueDate { get; set; }

        [MaxLength(10)]
        public int Score { get; set; } = 0;

        [MaxLength(50)]
        public string? Comment { get; set; }

        [MaxLength(10)]
        public string? Status { get; set; } = "Not Marked";

        [MaxLength(20)]
        public string? Date_Marked { get; set; }

        public DateTime Date_Submitted { get; set; }

        public Assignment? Assignments { get; set; }

        public Student? Students { get; set; }
    }
}