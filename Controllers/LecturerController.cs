using HomeWork.Models;
using Microsoft.AspNetCore.Mvc;
using SchoolAssignment.DataAccess;
using SchoolAssignment.Repo;

namespace SchoolAssignment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LecturerController: ControllerBase
    {
        private readonly ILecturer? _sLecturer;

        public LecturerController(ILecturer sLecturer)
        {
            _sLecturer = sLecturer;
        }

        [HttpGet]
        [Route("getLecturers")]
        //api/lecturer/getlecturers
        public ActionResult GetLecturers()
        {
            try
            {
                var lecturers = _sLecturer!.GetLecturers().ToList();
                if (lecturers != null)  
                {
                    if (lecturers.Count() == 0)
                    {
                        return Ok("No Student has been registered yet!");
                    }
                    return Ok(lecturers);
                }
                return NotFound("No Lecturer found");
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetLecturer/{Id}")]
        //api/lecturer/getlecturer/id
        public ActionResult GetLecturer(int Id)
        {
            try
            {
                var lecturer = _sLecturer!.GetLecturer(Id);
                if (lecturer != null)
                {
                    return Ok(lecturer);
                }

                return NotFound("Not Found");
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        //api/lecturer/create
        public ActionResult create([FromForm] LecturerModel NewLecturer)
        {
            try
            {
                var guid = Guid.NewGuid();
                var filepath = Path.Combine("wwwroot", guid + ".jpg");
                if (NewLecturer.Image != null)
                {
                    var fileStream = new FileStream(filepath, FileMode.Create);
                    NewLecturer.Image.CopyTo(fileStream);
                }

                var lecturer = new Lecturer();
                lecturer.ImageUrl = filepath;
                lecturer.FirstName = NewLecturer.FirstName;
                lecturer.LastName = NewLecturer.LastName;
                lecturer.Email = NewLecturer.LastName;
                lecturer.CourseTitle = NewLecturer.CourseTitle;
                lecturer.CourseCode = NewLecturer.CourseCode;
                lecturer.Title = NewLecturer.Title;
                lecturer.Phone_no = NewLecturer.Phone_no;
                lecturer.Password = BCrypt.Net.BCrypt.HashPassword(NewLecturer.Password);
                lecturer.Created_at = DateTime.Now;

                _sLecturer!.Create(lecturer);

                return Ok(lecturer);

            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Edit/{Id}")]
        //api/lecturer/edit/id
        public ActionResult Edit(int Id, [FromForm] UpdateLecturer ULecturer)
        {
            try
            {
                if (Id <= 0)
                {
                    return BadRequest("invalid Id");
                }

                var lecturer = _sLecturer!.GetLecturer(Id);
                if (lecturer == null)
                {
                    return NotFound($"Lecturer with id {Id} not found");
                }

                lecturer.Title = ULecturer.Title;
                lecturer.FirstName = ULecturer.FirstName;
                lecturer.LastName = ULecturer.LastName;
                lecturer.Email = ULecturer.Email;
                lecturer.CourseCode = ULecturer.CourseCode;
                lecturer.CourseTitle = ULecturer.CourseTitle;
                lecturer.Phone_no = ULecturer.Phone_no;
                lecturer.Password = BCrypt.Net.BCrypt.HashPassword(ULecturer.Password);

                _sLecturer.Update(Id, lecturer);

                return Ok(lecturer);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        [Route("updateImage/{Id}")]
        //api/lecturer/updateImage/id
        public ActionResult UpdateImage(int Id, [FromForm] UpdateImage lecturerImage)
        {
            try
            {
                if (Id <= 0)
                {
                    return BadRequest("invalid Id");
                }

                var lecturer = _sLecturer!.GetLecturer(Id);
                if (lecturer == null)
                {
                    return NotFound($"Lecturer with id {Id} not found");
                }
                var guid = Guid.NewGuid();
                var filepath = Path.Combine("wwwroot", guid + ".jpg");
                if (lecturerImage.Image != null)
                {
                    var fileStream = new FileStream(filepath, FileMode.Create);
                    lecturerImage.Image.CopyTo(fileStream);
                }

                lecturerImage.ImageUrl = filepath;
                lecturer.Image = lecturerImage.Image;

                _sLecturer.UpdateImage(Id, lecturer);

                return Ok(lecturer);


            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{Id}")]
        //api/lecturer/delete/id
        public ActionResult delete(int Id)
        {
            try
            {
                var lecturer = _sLecturer!.GetLecturer(Id);
                if (lecturer is null)   
                {
                    return BadRequest($"No lecturer found with the id {Id}");
                }
                try
                {
                    _sLecturer.Delete(Id);
    
                    return Ok("Lecturer deleted successfully");
                }
                catch (System.Exception ex1)
                {

                    return BadRequest(ex1.Message);
                }
            }
            catch (System.Exception ex2)
            {

                return BadRequest(ex2.Message);
            }
        }
    }
}