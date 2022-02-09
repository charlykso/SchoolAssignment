using System.Globalization;
using System.Linq;
using HomeWork.DataAccess;
using HomeWork.Models;
using HomeWork.Repo;
using HomeWork.Services;
using Microsoft.AspNetCore.Mvc;
using SchoolAssignment.DataAccess;

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

        [HttpGet("getStudents")]
        //api/student/getStudents
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
        //api/student/getStudent/id
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
        //api/student/create
        public ActionResult create([FromForm] UOrCStudentModel newStudent)
        {
            try
            {
                var guid = Guid.NewGuid();
                var filePath = Path.Combine("wwwroot", guid + ".jpg");
                if (newStudent.Image != null)
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
        [Route("edit/{Id}")]
        //api/student/edit/id
        public ActionResult Edit( int Id, [FromForm] UpdateStudent editStudent)
        {
            try
            {
                if (Id <= 0)
                {
                    return BadRequest("invalid Id");
                }

                var myStudent = _sStudent.GetStudent(Id);

                if (myStudent == null)
                {
                    return NotFound($"Student with the user id {Id} not found");
                }


                myStudent.FirstName = editStudent.FirstName;
                myStudent.LastName = editStudent.LastName;
                myStudent.DOB = editStudent.DOB;
                myStudent.Email = editStudent.Email;
                myStudent.Level = editStudent.Level;
                myStudent.Matric_no = editStudent.Matric_no;
                myStudent.Phone_no = editStudent.Phone_no;
                editStudent.Password = BCrypt.Net.BCrypt.HashPassword(editStudent.Password);
                myStudent.Password = editStudent.Password;
                // myStudent.Created_at = DateTime.Now;

                _sStudent!.Update(Id, myStudent);

                return Ok(myStudent);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete("delete/{Id}")]
        //api/student/delete/id
        public ActionResult DeleteStudent(int Id)
        {
            try
            {
                var student = _sStudent.GetStudent(Id);
                if (student is null)
                {
                    return NotFound($"student with the id {Id} not found");
                }

                try
                {
                    _sStudent.Delete(Id);

                    return Ok("Student deleted sucessfully");
                }
                catch (System.Exception ex1)
                {

                    return BadRequest(ex1.Message);
                }
                
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPut("UpdateImage/{Id}")]
        //api/student/updateImage/id
        public ActionResult EditImage(int Id, [FromForm] UpdateImage stuImage)
        {
            try
            {
                if (Id <= 0)
                {
                    return BadRequest("invalid Id");
                }

                var myImgStudent = _sStudent.GetStudent(Id);

                if (myImgStudent == null)
                {
                    return NotFound($"Student with the user id {Id} not found");
                }

                var guid = Guid.NewGuid();
                var filePath = Path.Combine("wwwroot", guid + ".jpg");
                if (stuImage.Image != null)
                {
                    var fileStream = new FileStream(filePath, FileMode.Create);
                    stuImage!.Image!.CopyTo(fileStream);
                }

                stuImage.ImageUrl = filePath;
                myImgStudent.ImageUrl = stuImage.ImageUrl;
                

                _sStudent!.UpdateImage(Id, myImgStudent);

                var currentSt = _sStudent.GetStudent(Id);


                return Ok(currentSt);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}