using HomeWork.Models;
using Microsoft.AspNetCore.Mvc;
using SchoolAssignment.DataAccess;
using SchoolAssignment.Repo;

namespace SchoolAssignment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmission _sSubmission;
        public SubmissionController(ISubmission sSubmission)
        {
            _sSubmission = sSubmission;
        }

        [HttpGet("getAllSubmissions")]
        //api/submission/getAllSubmissions
        public ActionResult getSubmissions()
        {
            try
            {
                var sub = _sSubmission.GetSubmissions().ToList();
                if (sub != null)
                {
                    if (sub.Count() == 0)
                    {
                        return Ok("No assignment has been submitted yet");
                    }
                    return Ok(sub);
                }

                return NotFound("Noting Found!");
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id}")]
        //api/submission/id
        public ActionResult<SubmissionModel> getSubmission(int Id)
        {
            try
            {
                var sub = _sSubmission.GetSubmission(Id);
                if (sub != null)
                {
                    return Ok(sub);
                }
                return NotFound("Not Found");
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create")]
        //api/submission/create
        public ActionResult Create([FromForm] SubmissionModel Data)
        {
            try
            {
                var guid = Guid.NewGuid();
                var filePath = Path.Combine("wwwroot", guid + ".jpg");
                if (Data.AssingmentFile != null)
                {
                    var fileStream = new FileStream(filePath, FileMode.Create);
                    Data.AssingmentFile.CopyTo(fileStream);
                }

                var newData = new Submission();
                Data.AssingmentFileUrl = filePath;
                newData.AssingmentFileUrl = Data.AssingmentFileUrl;
                newData.Date_Submitted = DateTime.Now;

                _sSubmission.Create(newData);

                return Ok("Assignment submitted");
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Mark/{Id}")]
        //api/submission/mark/id
        public ActionResult Mark(int Id, [FromBody] UpdateSubmission data)
        {
            try
            {
                if (Id <= 0)
                {
                    return BadRequest("Invalid Id");
                }
                var sub = _sSubmission.GetSubmission(Id);
                if (sub == null)
                {
                    return NotFound("Not Found");
                }
                sub.Score = data.Score;
                sub.Comment = data.Comment;
                sub.Date_Marked = DateTime.Now.ToString();

                _sSubmission.Update(Id, sub);

                return Ok(sub);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete/{Id}")]
        //api/submission/delete/Id
        public ActionResult Delete(int Id)
        {
            try
            {
                var sub = _sSubmission.GetSubmission(Id);
                if (sub == null)
                {
                    return NotFound($"Assignment with the Id {Id} not found");
                }

                _sSubmission.Delete(Id);

                return Ok("Deleted Successfully!");
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}