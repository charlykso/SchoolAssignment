using System.Globalization;
using System.Linq;
using HomeWork.DataAccess;
using HomeWork.Models;
using HomeWork.Repo;
using HomeWork.Services;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _sStudent;

        public StudentController(IStudent sStudent)
        {
            _sStudent = sStudent;
        }

        [HttpGet]
        public ActionResult GetStudents()
        { 
            try
            {
                var stu = _sStudent!.GetStudents().ToList();
                if (stu != null)
                {
                    if (stu.Count() == 0)
                    {
                        return Ok("No Student has been registered yet!");
                    }
                    return Ok(stu);
                }

                return NotFound("No Student found");
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
            // return _sStudent!.GetStudents().ToList();
        }

        // [Route("get/{id}")]
        [HttpGet("{Id}")]
        public ActionResult<StudentModel> GetStudent(int Id)
        {
            try
            {
                var student = _sStudent.GetStudent(Id);

                if (student != null)
                {
                    return Ok(student);
                }

                return NotFound("Not Found");

                // var studentModel = new StudentModel{}
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost]
        [Route("create")]
        public ActionResult create([FromForm] UOrCStudentModel newStudent)
        {
            try
            {
                var guid = Guid.NewGuid();
                var filePath = Path.Combine("wwwroot", guid + ".jpg");
                if (newStudent.Image == null)
                {
                    var fileStream = new FileStream(filePath, FileMode.Create);
                    newStudent!.Image!.CopyTo(fileStream);
                }

                var myStudent = new Student();
                newStudent.ImageUrl = filePath;
                myStudent.ImageUrl = newStudent.ImageUrl;
                myStudent.FirstName = newStudent.FirstName;
                myStudent.LastName = newStudent.LastName;
                myStudent.DOB = newStudent.DOB;
                myStudent.Email = newStudent.Email;
                myStudent.Level = newStudent.Level;
                myStudent.ImageUrl = newStudent.ImageUrl;
                myStudent.Matric_no = newStudent.Matric_no;
                myStudent.Phone_no = newStudent.Phone_no;
                newStudent.Password = BCrypt.Net.BCrypt.HashPassword(newStudent.Password);
                myStudent.Password = newStudent.Password;
                myStudent.Created_at = DateTime.Now;

                _sStudent.Create(myStudent);

                return Ok(myStudent);
            }
            catch (System.Exception ex)
            {

                return Ok(ex.Message);
            }
            
        }


        [HttpPut]
        [Route("edit")]
        public ActionResult Edit([FromForm] UOrCStudentModel editStudent)
        {
            try
            {
                var guid = Guid.NewGuid();
                var filePath = Path.Combine("wwwroot", guid + ".jpg");
                if (newStudent.Image == null)
                {
                    var fileStream = new FileStream(filePath, FileMode.Create);
                    newStudent!.Image!.CopyTo(fileStream);
                }

                var myStudent = new Student();
                editStudent.ImageUrl = filePath;
                myStudent.ImageUrl = editStudent.ImageUrl;
                myStudent.FirstName = editStudent.FirstName;
                myStudent.LastName = editStudent.LastName;
                myStudent.DOB = editStudent.DOB;
                myStudent.Email = editStudent.Email;
                myStudent.Level = editStudent.Level;
                myStudent.ImageUrl = editStudent.ImageUrl;
                myStudent.Matric_no = editStudent.Matric_no;
                myStudent.Phone_no = editStudent.Phone_no;
                editStudent.Password = BCrypt.Net.BCrypt.HashPassword(newStudent.Password);
                myStudent.Password = editStudent.Password;
                // myStudent.Created_at = DateTime.Now;

                var sedit = _sStudent.Edit(myStudent);
                if (sedit == null)
                {
                    return NotFound("User not found");
                }

                return Ok(myStudent);
            }
            catch (System.Exception ex)
            {

                return Ok(ex.Message);
            }
            
        }

    }
}