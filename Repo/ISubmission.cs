using System;
using HomeWork.Models;

namespace SchoolAssignment.Repo
{
    public interface ISubmission
    {
        public IEnumerable<Submission> GetSubmissions();
        public Submission GetSubmission(int Id);

        public void Create(Submission Data);
        public void Update(int Id, Submission Data);
        public void Delete(int Id);
    }
}