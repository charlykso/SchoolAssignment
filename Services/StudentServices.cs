using HomeWork.DataAccess;
using HomeWork.Models;
using HomeWork.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace HomeWork.Services
{
    
    public class StudentServices : IStudent
    {

        private AssignmentContext? _assignmentContext;

        public StudentServices(AssignmentContext assignmentContext)
        {
            _assignmentContext = assignmentContext;
        }

        public IEnumerable<Student> GetStudents()
        {
            try
            {
                var student = _assignmentContext!.Students!;

                return student;
            }
            catch (System.Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null!;
            }
            // return _assignmentContext!.Students!;

        }

        public Student GetStudent(int Id)
        {
            try
            {
                var student = _assignmentContext!.Students.Where(x => x.Id == Id).SingleOrDefault();

                if (student != null)
                {
                    return student;
                }

                return null!;
            }
            catch (System.Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null!;
            }
        }

        public void Create(Student NewStudent)
        {
            try
            {
                _assignmentContext!.Students.Add(NewStudent);
                _assignmentContext.SaveChanges();
            }
            catch (System.Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
           
            // throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Student Data)
        {
            throw new NotImplementedException();
        }
    }
}