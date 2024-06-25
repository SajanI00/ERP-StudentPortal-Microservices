using AutoMapper;
using ERP.SiteHome.Core.DTOs.Request;
using ERP.SiteHome.Core.DTOs.Response;
using ERP.SiteHome.Core.Entity;
using ERP.SiteHome.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.SiteHome.Api.Controllers
{
    public class SemesterController : BaseController
    {
        public SemesterController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        [Route("{semesterId:guid}")]
        public async Task<IActionResult> GetSemesterDetailsMethod(Guid semesterId)
        {
            var semester = await _unitOfWork.Semesters.GetById(semesterId);

            if (semester == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<GetSemesterResponse>(semester);

            return Ok(result);
        }

        [HttpGet]
        [Route("Batches/{batchId:guid}")]
        public async Task<IActionResult> GetBatchSemesters(Guid batchId)
        {
            var semester = await _unitOfWork.Semesters.GetBatchSemesterAsync(batchId);

            if (semester == null || !semester.Any())
                return NotFound("Semesters not found");

            var result = _mapper.Map<IEnumerable<GetSemesterResponse>>(semester);

            return Ok(result);

        }

        [HttpPost("")]
        public async Task<IActionResult> AddBatchSemester([FromBody] CreateSemesterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _mapper.Map<Semester>(request);

            await _unitOfWork.Semesters.Add(result);
            await _unitOfWork.CompleteAsync();


            return CreatedAtAction(nameof(GetBatchSemesters), new { batchId = result.BatchId }, result);

        }
    }
}
