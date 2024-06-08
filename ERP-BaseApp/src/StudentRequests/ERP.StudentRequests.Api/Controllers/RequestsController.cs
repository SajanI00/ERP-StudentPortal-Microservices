using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ERP.StudentRequests.Core.Interfaces;
using ERP.StudentRequests.Core.DTOs.Request;
using ERP.StudentRequests.Core.DTOs.Response;
using ERP.StudentRequests.Core.Entity;
using ERP.StudentRequests.Api.Services.Publishers.Interfaces;
using ERP.StudentRequests.Core.Contracts;

namespace ERP.StudentRequests.Api.Controllers
{
    public class RequestsController : BaseController
    {

        public readonly IRequestNotificationPublisherService _requestService;
        private static readonly Guid FixedStudentId = new Guid("292dcf28-b173-4619-a509-3ac83c576c38");


        public RequestsController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IRequestNotificationPublisherService requestService) : base(unitOfWork, mapper)
        {
            _requestService = requestService;
        }

        [HttpGet]
        [Route("{requestId:guid}")]
        public async Task<IActionResult> GetReqDetailsMethod(Guid requestId)
        {
            var request = await _unitOfWork.Requests.GetById(requestId);

            if (request == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<GetReqLetterResponse>(request);

            return Ok(result);
        }

        [HttpGet]
        [Route("Students/{studentId:guid}")]
        public async Task<IActionResult> GetStudentRequests(Guid studentId)
        {
            var studentRequests = await _unitOfWork.Requests.GetStudentRequestAsync(studentId);

            if (studentRequests == null || !studentRequests.Any())
                return NotFound("Requests not found");

            var result = _mapper.Map<IEnumerable<GetReqLetterResponse>>(studentRequests);

            return Ok(result);

        }

        [HttpGet]
        [Route("Students/Requests")]
        public async Task<IActionResult> GetOneStudentRequests()
        {
            var studentRequests = await _unitOfWork.Requests.GetStudentRequestAsync(FixedStudentId);

            if (studentRequests == null || !studentRequests.Any())
                return NotFound("Requests not found");

            var result = _mapper.Map<IEnumerable<GetReqLetterResponse>>(studentRequests);

            return Ok(result);
        }


        [HttpGet]
        [Route("Lecturers/{lecturerId:guid}")]
        public async Task<IActionResult> GetLecturerRequests(Guid lecturerId)
        {
            var lecturerRequests = await _unitOfWork.Requests.GetLecturerRequestAsync(lecturerId);

            if (lecturerRequests == null)
                return NotFound("Requests not found");

            var result = _mapper.Map<GetReqLetterResponse>(lecturerRequests);

            return Ok(result);

        }

        //[HttpPost("")]
        //public async Task<IActionResult> AddStudentRequest([FromBody] CreateReqLetterRequest request)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest();

        //    var result = _mapper.Map<Request>(request);

        //    await _unitOfWork.Requests.Add(result);
        //    await _unitOfWork.CompleteAsync();

        //    RequestCreatedNotificationRecord requestRecord = new RequestCreatedNotificationRecord
        //       (RequestId: result.Id,
        //        Topic: result.Topic,
        //        AddedDate: result.AddedDate,
        //        StudentName: result.StudentName,
        //        LecturerName: result.LecturerName
        //       );

        //    await _requestService.SendNotification(requestRecord);

        //    return CreatedAtAction(nameof(GetStudentRequests), new { studentId = result.StudentId }, result);

        //}

        // create request
        [HttpPost("")]
        public async Task<IActionResult> AddRequestForOneStudent([FromBody] CreateReqLetterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            request.StudentId = Guid.Parse("292dcf28-b173-4619-a509-3ac83c576c38");
            
            var student = await _unitOfWork.Students.GetById(request.StudentId);
            if (student == null)
            {
                return NotFound($"Student with ID {request.StudentId} not found.");
            }

            request.StudentName = student.Name;
            request.StudentRegNo = student.RegNo;


            var result = _mapper.Map<Request>(request);

            await _unitOfWork.Requests.Add(result);
            await _unitOfWork.CompleteAsync();

            RequestCreatedNotificationRecord requestRecord = new RequestCreatedNotificationRecord
               (RequestId: result.Id,
                Topic: result.Topic,
                AddedDate: result.AddedDate,
                StudentName: result.StudentName,
                LecturerName: result.LecturerName
               );

            await _requestService.SendNotification(requestRecord);

            return CreatedAtAction(nameof(GetStudentRequests), new { studentId = result.StudentId }, result);

        }


        [HttpPut("")]
        public async Task<IActionResult> UpdateStudentRequestMethod([FromBody] UpdateReqLetterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _mapper.Map<Request>(request);

            await _unitOfWork.Requests.Update(result);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
