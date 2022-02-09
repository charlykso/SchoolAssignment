using System;
using HomeWork.Models;

namespace SchoolAssignment.Repo
{
    public interface ILecturer
    {
        public IEnumerable<Lecturer> GetLecturers();
        public Lecturer GetLecturer(int Id);
        public void Create(Lecturer NewLecturer);
        public void Update(int Id, Lecturer Data);

        public void UpdateImage(int Id, Lecturer Data);
        public void Delete(int Id);
    }
}