using System.Collections;
using HomeWork.DataAccess;
using HomeWork.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork.Repo
{
    public interface IStudent
    {
        public IEnumerable<Student> GetStudents();
        public Student GetStudent(int Id);
        public void Create(Student NewStudent);
        public void Update(int Id, Student Data);
        public void Delete(int Id);
    }
}