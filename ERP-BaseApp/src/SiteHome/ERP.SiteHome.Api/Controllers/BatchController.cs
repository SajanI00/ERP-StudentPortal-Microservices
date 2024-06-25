using AutoMapper;
using ERP.SiteHome.Core.DTOs.Request;
using ERP.SiteHome.Core.DTOs.Response;
using ERP.SiteHome.Core.Entity;
using ERP.SiteHome.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.SiteHome.Api.Controllers
{
    public class BatchController : BaseController
    {
        public BatchController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        [Route("{batchId:guid}")]
        public async Task<IActionResult> GetBatchDetailsMethod(Guid batchId)
        {
            var batch = await _unitOfWork.Batches.GetById(batchId);

            if (batch == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<GetBatchResponse>(batch);

            return Ok(result);
        }

        [HttpGet]
        [Route("Departments/{departmentId:guid}")]
        public async Task<IActionResult> GetDepartmentBatches(Guid departmentId)
        {
            var batch = await _unitOfWork.Batches.GetDepartmentBatchAsync(departmentId);

            if (batch == null || !batch.Any())
                return NotFound("Batches not found");

            var result = _mapper.Map<IEnumerable<GetBatchResponse>>(batch);

            return Ok(result);

        }

        [HttpPost("")]
        public async Task<IActionResult> AddDepartmentBatch([FromBody] CreateBatchRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _mapper.Map<Batch>(request);

            await _unitOfWork.Batches.Add(result);
            await _unitOfWork.CompleteAsync();


            return CreatedAtAction(nameof(GetDepartmentBatches), new { departmentId = result.DepartmentId }, result);

        }
    }
}
