using System.Data.Common;
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
            try
            {
                var student = _assignmentContext!.Students.Find(Id);
                _assignmentContext.Students.Remove(student!);
                _assignmentContext.SaveChanges();

                Console.WriteLine("Student deleted successfuly");

            }
            catch (System.Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void Update(int Id, Student Data)
        {
            try
            {
                var student = _assignmentContext!.Students.Find(Id);
                _assignmentContext.Students.Attach(student!);
                _assignmentContext.SaveChanges();


            }
            catch (System.Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateImage(int Id, Student data)
        {
            try
            {
                var student = _assignmentContext!.Students.Find(Id);
                _assignmentContext.Students.Attach(student!);
                _assignmentContext.SaveChanges();

                Console.WriteLine("Update successfully");
            }
            catch (System.Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}