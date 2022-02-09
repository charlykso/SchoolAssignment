using System;
using HomeWork.Models;
using SchoolAssignment.Repo;

namespace SchoolAssignment.Services
{
    public class LecturerServices : ILecturer
    {
        private readonly AssignmentContext? _assignmentContext;

        public LecturerServices(AssignmentContext assignmentContext)
        {
            _assignmentContext = assignmentContext;
        }
        public void Create(Lecturer NewLecturer)
        {
            try
            {
                _assignmentContext!.Lecturers.Add(NewLecturer);
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
                var lecturer = _assignmentContext!.Lecturers.Find(Id);
                _assignmentContext.Lecturers.Remove(lecturer!);
                _assignmentContext.SaveChanges();
            }
            catch (System.Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public Lecturer GetLecturer(int Id)
        {
            try
            {
                var lecturer = _assignmentContext!.Lecturers.Where(x => x.Id == Id).SingleOrDefault();
                if (lecturer is null)
                {
                    Console.WriteLine("No Student found");
                    return null!;
                }

                return lecturer;
            }
            catch (System.Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null!;
            }
        }

        public IEnumerable<Lecturer> GetLecturers()
        {
            try
            {
                var lecturers = _assignmentContext!.Lecturers;

                return lecturers;
            }
            catch (System.Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null!;
            }
        }

        public void Update(int Id, Lecturer Data)
        {
            try
            {
                var lecturer = _assignmentContext!.Lecturers.Find(Id);
                _assignmentContext.Lecturers.Attach(lecturer!);
                _assignmentContext.SaveChanges();
            }
            catch (System.Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateImage(int Id, Lecturer Data)
        {
            try
            {
                var lecturer = _assignmentContext!.Lecturers.Find(Id);
                _assignmentContext.Lecturers.Attach(lecturer!);
                _assignmentContext.SaveChanges();
            }
            catch (System.Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}