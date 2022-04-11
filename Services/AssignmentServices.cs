using HomeWork.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolAssignment.Repo;

namespace SchoolAssignment.Services
{
    public class AssignmentServices : IAssignment
    {
        private readonly AssignmentContext? _assignmentContext;
        public AssignmentServices(AssignmentContext assignmentContext)
        {
            _assignmentContext = assignmentContext;
        }
        public void CreateAssignment(Assignment NewAssignment)
        {
            try
            {
                var assignment = _assignmentContext!.Assignments.Add(NewAssignment);
                _assignmentContext.SaveChanges();
            }
            catch (System.Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteAssignment(int Id)
        {
            try
            {
                var assignment = _assignmentContext!.Assignments.Find(Id);
                _assignmentContext.Assignments.Remove(assignment!);
                _assignmentContext.SaveChanges();
            }
            catch (System.Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public Assignment GetAssignment(int Id)
        {
            try
            {
                var assignment = _assignmentContext!.Assignments.Where(x => x.Id == Id).SingleOrDefault();
                if (assignment is null)
                {
                    Console.WriteLine("No lecruer found");
                    return null!;
                }

                return assignment;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null!;
            }
        }

        public IEnumerable<Assignment> GetAssignments()
        {
            try
            {
                var assignment = _assignmentContext!.Assignments!
                .Include(ass => ass!.Lecturer)
                .Include(ass => ass!.Submitted_Assignment);

                var assignments = assignment!.ThenInclude(ass => ass.Students);

                if (assignments is null)
                {
                    Console.WriteLine("No Assignment found");
                    return null!;
                }

                return assignments;
            }
            catch (System.Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null!;
            }
        }

        public void UpdateAssignment(int Id, Assignment EditAssignment)
        {
            try
            {
                var assignment = _assignmentContext!.Assignments.Find(Id);
                if (assignment is null)
                {
                    Console.WriteLine($"No assignment with id {Id} found");
                }
                _assignmentContext.Assignments.Attach(assignment!);
                _assignmentContext.SaveChanges();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}