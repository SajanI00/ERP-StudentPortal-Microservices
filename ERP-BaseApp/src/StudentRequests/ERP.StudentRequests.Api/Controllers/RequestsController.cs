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
     
        public RequestsController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IRequestNotificationPublisherService requestService) : base(unitOfWork, mapper)
        {
            _requestService = requestService;
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
        [Route("Lecturers/{lecturerId:guid}")]
        public async Task<IActionResult> GetLecturerRequests(Guid lecturerId)
        {
            var lecturerRequests = await _unitOfWork.Requests.GetLecturerRequestAsync(lecturerId);

            if (lecturerRequests == null)
                return NotFound("Requests not found");

            var result = _mapper.Map<GetReqLetterResponse>(lecturerRequests);

            return Ok(result);

        }

        [HttpPost("")]
        public async Task<IActionResult> AddStudentRequest([FromBody] CreateReqLetterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

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

            //await _requestService.SendNotification(requestRecord);

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
