using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace HomeWork.Models
{
    public class AssignmentContext : DbContext
    {
        public AssignmentContext(DbContextOptions<AssignmentContext> options) : base(options)
        {
            
        }

        public DbSet<Assignment> Assignments { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Lecturer> Lecturers { get; set; } = null!;
        public DbSet<Submission> Submissions { get; set; } = null!;
    }
}