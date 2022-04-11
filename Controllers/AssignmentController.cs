using HomeWork.Models;
using Microsoft.AspNetCore.Mvc;
using SchoolAssignment.DataAccess;
using SchoolAssignment.Repo;

namespace SchoolAssignment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignment? _sAssignment;

        public AssignmentController(IAssignment sAssignment)
        {
            _sAssignment = sAssignment;
        }


        [HttpGet]
        [Route("GetAssignments")]
        //api/assignment/GetAssignments
        public ActionResult GetAssignments()
        {
            try
            {
                var assignments = _sAssignment!.GetAssignments().ToList();
                if (assignments != null)
                {
                    if (assignments.Count() == 0)
                    {
                        return Ok("No Assignment yet!");
                    }
                    return Ok(assignments);
                }
                return NotFound("No Assignmrnt found");
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAssignment/{Id}")]
        //api/Assignment/GetAssignment/Id
        public ActionResult<AssignmentModel> GetAssignment(int Id)
        {
            try
            {
                var assignment = _sAssignment!.GetAssignment(Id);
                if (assignment != null)
                {
                    return Ok(assignment);
                }

                return NotFound("Not Found");
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Create")]
        //api/assignment/create
        public ActionResult create([FromBody] CorUAssignmentModel NewAssignmnet)
        {
            try
            {
                var assignment = new Assignment();
                assignment.Question = NewAssignmnet.Question;
                assignment.Level = NewAssignmnet.Level;
                assignment.DueDate = NewAssignmnet.DueDate;
                assignment.Created_at = DateTime.Now;
                assignment.TotalMark = NewAssignmnet.TotalMark;
                // assignment.Lecturer = NewAssignmnet.Lecturer;
                assignment.LecturerId = NewAssignmnet.LecturerId;

                _sAssignment!.CreateAssignment(assignment);

                return Ok(assignment);

            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Edit/{Id}")]
        //api/assignment/edit/Id
        public ActionResult Edit(int Id, [FromBody] CorUAssignmentModel EditAssignment)
        {
            
            try
            {
                if (Id <= 0)
                {
                    return BadRequest("invalid Id");
                }
                var assignment = _sAssignment!.GetAssignment(Id);
                if (assignment == null)
                {
                    return NotFound($"Assignment with id {Id} not found");
                }

                assignment.Question = EditAssignment.Question;
                assignment.Level = EditAssignment.Level;
                assignment.DueDate = EditAssignment.DueDate;
                assignment.TotalMark = EditAssignment.TotalMark;
                assignment.LecturerId = EditAssignment.LecturerId;

                _sAssignment.UpdateAssignment(Id, assignment);

                return Ok(assignment);

            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete/{Id}")]
        //api/assignment/Delete/Id
        public ActionResult Delete(int Id)
        {
            try
            {
                var assignment = _sAssignment!.GetAssignment(Id);
                if (assignment is null)
                {
                    return NotFound($"Assignment with the id {Id} not found");
                }
                _sAssignment.DeleteAssignment(Id);

                return Ok("Assignment deleted successfully");
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}