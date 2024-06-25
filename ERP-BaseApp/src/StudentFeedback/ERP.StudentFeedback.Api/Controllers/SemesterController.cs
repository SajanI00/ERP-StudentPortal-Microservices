using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ERP.StudentFeedback.Core.DTOs.Request;
using ERP.StudentFeedback.Core.DTOs.Response;
using ERP.StudentFeedback.Core.Entity;
using ERP.StudentFeedback.Core.Interfaces;

namespace ERP.StudentFeedback.Api.Controllers
{
    public class SemesterController : BaseController
    {
        public SemesterController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        [Route("{semesterId:guid}")]
        public async Task<IActionResult> GetSemesterMethod(Guid semesterId)
        {
            var semester = await _unitOfWork.Semesters.GetById(semesterId);

            if (semester == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<GetSemesterResponse>(semester);

            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddSemesterMethod([FromBody] CreateSemesterRequest semester)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _mapper.Map<Semester>(semester);

            await _unitOfWork.Semesters.Add(result);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetSemesterMethod), new { semesterId = result.Id }, result);

        }


        [HttpGet]
        public async Task<IActionResult> GetAllSemestersMethod()
        {
            var semester = await _unitOfWork.Semesters.GetAll();

            return Ok(_mapper.Map<IEnumerable<GetSemesterResponse>>(semester));
        }

    }
}
