using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ERP.StudentFeedback.Core.DTOs.Request;
using ERP.StudentFeedback.Core.DTOs.Response;
using ERP.StudentFeedback.Core.Entity;
using ERP.StudentFeedback.Core.Interfaces;

namespace ERP.StudentFeedback.Api.Controllers
{
    public class LecturersSemestersController : BaseController
    {
        public LecturersSemestersController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        [Route("{lecturersSemestersId:guid}")]
        public async Task<IActionResult> GetLecturersSemestersMethod(Guid lecturersSemestersId)
        {
            var lecturersSemesters = await _unitOfWork.LecturersSemesters.GetById(lecturersSemestersId);

            if (lecturersSemesters == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<GetLecturersSemestersResponse>(lecturersSemesters);

            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddLecturersSemestersMethod([FromBody] CreateLecturersSemestersRequest lecturersSemesters)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _mapper.Map<LecturersSemesters>(lecturersSemesters);

            await _unitOfWork.LecturersSemesters.Add(result);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetLecturersSemestersMethod), new { lecturersSemestersId = result.Id }, result);

        }

        [HttpGet]
        [Route("Lecturers/{lecturerId:guid}")]
        public async Task<IActionResult> GetOneLecturerSemesters(Guid lecturerId)
        {

            var lecturersSemesters = await _unitOfWork.LecturersSemesters.GetOneLecturersSemestersAsync(lecturerId);

            if (lecturersSemesters == null || !lecturersSemesters.Any())
                return NotFound("Semesters not assigned for the lecturer");

            var semesterResponses = new List<GetSemesterResponse>();

            foreach (var lecturerSemester in lecturersSemesters)
            {
                var semester = await _unitOfWork.Semesters.GetById(lecturerSemester.SemesterId);

                if (semester == null)
                    continue;

                var semesterResponse = _mapper.Map<GetSemesterResponse>(semester);
                semesterResponses.Add(semesterResponse);
            }

            if (!semesterResponses.Any())
                return NotFound("Semesters not found");

            return Ok(semesterResponses);


        }

        [HttpGet]
        public async Task<IActionResult> GetAllLecturersSemestersMethod()
        {
            var lecturersSemesters = await _unitOfWork.LecturersSemesters.GetAll();

            return Ok(_mapper.Map<IEnumerable<GetLecturersSemestersResponse>>(lecturersSemesters));
        }
    }
}
