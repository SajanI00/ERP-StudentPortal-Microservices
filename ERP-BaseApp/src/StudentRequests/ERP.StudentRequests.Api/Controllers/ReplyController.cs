using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ERP.StudentRequests.Core.Interfaces;
using ERP.StudentRequests.Core.DTOs.Request;
using ERP.StudentRequests.Core.DTOs.Response;
using ERP.StudentRequests.Core.Entity;


namespace ERP.StudentRequests.Api.Controllers
{
    public class ReplyController : BaseController
    {
        private static readonly Guid FixedStudentId = new Guid("292dcf28-b173-4619-a509-3ac83c576c38");

        public ReplyController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }



        //create reply
        [HttpPost("Student")]
        public async Task<IActionResult> CreateReplyByStudent([FromBody] CreateReplyRequest replyRequest)
        {

            var request = await _unitOfWork.Requests.GetById(replyRequest.RequestId);
            if (request == null)
            {
                return NotFound("Request not found");
            }

            replyRequest.StudentId = request.StudentId;
            replyRequest.LecturerId = request.LecturerId;


            var student = await _unitOfWork.Students.GetById(replyRequest.StudentId);
            if (student == null)
            {
                return NotFound($"Student with ID {replyRequest.StudentId} not found.");
            }

            replyRequest.SenderName = student.Name;

            var reply = _mapper.Map<Reply>(replyRequest);

            await _unitOfWork.Replies.Add(reply);
            await _unitOfWork.CompleteAsync();

            return Ok(reply);

        }

        [HttpPost("Lecturer")]
        public async Task<IActionResult> CreateReplyByLecturer([FromBody] CreateReplyRequest replyRequest)
        {

            var request = await _unitOfWork.Requests.GetById(replyRequest.RequestId);
            if (request == null)
            {
                return NotFound("Request not found");
            }

            replyRequest.StudentId = request.StudentId;
            replyRequest.LecturerId = request.LecturerId;


            var lecturer = await _unitOfWork.Lecturers.GetById(replyRequest.LecturerId);
            if (lecturer == null)
            {
                return NotFound($"Lecturer with ID {replyRequest.LecturerId} not found.");
            }

            replyRequest.SenderName = lecturer.Name;

            var reply = _mapper.Map<Reply>(replyRequest);

            await _unitOfWork.Replies.Add(reply);
            await _unitOfWork.CompleteAsync();

            return Ok(reply);

        }


        [HttpGet]
        [Route("{replyId:guid}")]
        public async Task<IActionResult> GetReplyDetailsMethod(Guid replyId)
        {
            var reply = await _unitOfWork.Replies.GetById(replyId);

            if (reply == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<GetReplyResponse>(reply);

            return Ok(result);
        }


        [HttpGet]
        [Route("Students/Replies")]
        public async Task<IActionResult> GetOneStudentReplies()
        {
            var studentReplies = await _unitOfWork.Replies.GetStudentReplyAsync(FixedStudentId);

            if (studentReplies == null || !studentReplies.Any())
                return NotFound("Replies not found");

            var result = _mapper.Map<IEnumerable<GetReplyResponse>>(studentReplies);

            return Ok(result);
        }

        [HttpGet]
        [Route("Students/{studentId:guid}")]
        public async Task<IActionResult> GetStudentReplies(Guid studentId)
        {
            var studentReplies = await _unitOfWork.Replies.GetStudentReplyAsync(studentId);

            if (studentReplies == null || !studentReplies.Any())
                return NotFound("Replies not found");

            var result = _mapper.Map<IEnumerable<GetReplyResponse>>(studentReplies);

            return Ok(result);
        }

        [HttpGet]
        [Route("Requests/{requestId:guid}")]
        public async Task<IActionResult> GetRequestReplies(Guid requestId)
        {
            var requestReplies = await _unitOfWork.Replies.GetRequestReplyAsync(requestId);

            if (requestReplies == null || !requestReplies.Any())
                return NotFound("Replies not found");

            var result = _mapper.Map<IEnumerable<GetReplyResponse>>(requestReplies);

            return Ok(result);
        }

    }
}
