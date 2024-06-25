using AutoMapper;
using ERP.StudentFeedback.Core.DTOs.Request;
using ERP.StudentFeedback.Core.DTOs.Response;
using ERP.StudentFeedback.Core.Entity;
using ERP.StudentFeedback.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.StudentFeedback.Api.Controllers
{
    public class FeedbackController : BaseController
    {
        public FeedbackController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

          private static readonly Guid FixedStudentId = new Guid("2d952392-c0f3-4359-b504-b36aa910bcb1");

        //[HttpGet]
        //[Route("Students/{studentId:guid}")]
        //public async Task<IActionResult> GetStudentFeedbacks(Guid studentId)
        //{
        //    var studentFeedbacks = await _unitOfWork.Feedbacks.GetStudentFeedbackAsync(studentId);

        //    if (studentFeedbacks == null || !studentFeedbacks.Any())
        //        return NotFound("Feedbacks not found");

        //    var result = _mapper.Map<IEnumerable<GetFeedbackResponse>>(studentFeedbacks);

        //    return Ok(result);

        //}


        //[HttpGet]
        //[Route("Students/Feedbacks")]
        //public async Task<IActionResult> GetOneStudentFeedbacks()
        //{
        //    var studentFeedbacks = await _unitOfWork.Feedbacks.GetStudentFeedbackAsync(FixedStudentId);

        //    if (studentFeedbacks == null || !studentFeedbacks.Any())
        //        return NotFound("Feedbacks not found");

        //    var result = _mapper.Map<IEnumerable<GetFeedbackResponse>>(studentFeedbacks);

        //    return Ok(result);
        //}


        [HttpGet]
        [Route("Lecturers/{lecturerId:guid}")]
        public async Task<IActionResult> GetLecturerFeedbacks(Guid lecturerId)
        {
            var lecturerFeedbacks = await _unitOfWork.Feedbacks.GetLecturerFeedbackAsync(lecturerId);

            if (lecturerFeedbacks == null)
                return NotFound("Feedbacks not found");

            var result = _mapper.Map<IEnumerable<GetFeedbackResponse>>(lecturerFeedbacks);

            return Ok(result);

        }

        [HttpPost("")]
        public async Task<IActionResult> AddFeedbackForOneStudent([FromBody] CreateFeedbackRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();


         //   request.StudentId = Guid.Parse("02e7781b-b278-4b12-aaca-3e203e6975be");


            var result = _mapper.Map<Feedback>(request);


            await _unitOfWork.Feedbacks.Add(result);
            await _unitOfWork.CompleteAsync();


            return CreatedAtAction(nameof(GetLecturerFeedbacks), new { lecturerId = result.LecturerId }, result);

        }


    }
}
