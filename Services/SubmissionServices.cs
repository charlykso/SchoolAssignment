using System.Linq;
using HomeWork.Models;
using SchoolAssignment.Repo;

namespace SchoolAssignment.Services
{
    public class SubmissionServices : ISubmission
    {
        private AssignmentContext? _assignmentContext;

        public SubmissionServices(AssignmentContext assignmentContext)
        {
            _assignmentContext = assignmentContext;
        }

        public void Create(Submission Data)
        {
            try
            {
                _assignmentContext!.Submissions.Add(Data);
                _assignmentContext.SaveChanges();
            }
            catch (System.Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(int Id)
        {
            try
            {
                var subAssignment = _assignmentContext!.Submissions.Find(Id);
                _assignmentContext.Submissions.Remove(subAssignment!);
                _assignmentContext.SaveChanges();

                Console.WriteLine("Assignment delete successfuly");
            }
            catch (System.Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public Submission GetSubmission(int Id)
        {
            try
            {
                var assignment = _assignmentContext!.Submissions.Where(x => x.Id == Id).SingleOrDefault();
                if (assignment != null) 
                {
                    return assignment;
                }
                return null!;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null!;

            }
        }

        public IEnumerable<Submission> GetSubmissions()
        {
           try
           {
                var subAssignments = _assignmentContext!.Submissions!;
                if (subAssignments != null)
                {
                    return subAssignments;
                }
                return null!;
            }
           catch (System.Exception ex)
           {

                Console.WriteLine(ex.Message);
                return null!;
            } 
        }

        public void Update(int Id, Submission Data)
        {
            try
            {
                var subAssignment = _assignmentContext!.Submissions.Find(Id);
                _assignmentContext.Submissions.Attach(subAssignment!);
                _assignmentContext.SaveChanges();

                Console.WriteLine("Updated Successfuly");

            }
            catch (System.Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}