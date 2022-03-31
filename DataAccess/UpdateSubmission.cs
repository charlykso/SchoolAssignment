using System.ComponentModel.DataAnnotations;

namespace SchoolAssignment.DataAccess
{
    public class UpdateSubmission
    {

        public int Score { get; set; } = 0;

        [MaxLength(50)]
        public string? Comment { get; set; }

        [MaxLength(10)]
        public string? Status { get; set; } = "Not Marked";

        [MaxLength(20)]
        public string? Date_Marked { get; set; }
    }
}