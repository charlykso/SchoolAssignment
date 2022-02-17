using HomeWork.Models;

namespace SchoolAssignment.Repo
{
    public interface IAssignment
    {
        public IEnumerable<Assignment> GetAssignments();
        public Assignment GetAssignment(int Id);
        public void CreateAssignment(Assignment NewAssignment);
        public void UpdateAssignment(int Id, Assignment EditAssignment);
        public void DeleteAssignment(int Id);

    }
}