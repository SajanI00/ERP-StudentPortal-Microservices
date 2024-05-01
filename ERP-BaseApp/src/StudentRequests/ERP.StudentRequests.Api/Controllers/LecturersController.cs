using ERP.StudentRequests.Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ERP.StudentRequests.Core.DTOs.Request;
using ERP.StudentRequests.Core.DTOs.Response;
using ERP.StudentRequests.Core.Entity;

namespace ERP.StudentRequests.Api.Controllers
{
    public class LecturersController : BaseController
    {
        public LecturersController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        [Route("{lecturerId:guid}")]
        public async Task<IActionResult> GetLecturerMethod(Guid lecturerId)
        {
            var lecturer = await _unitOfWork.Lecturers.GetById(lecturerId);

            if (lecturer == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<GetLecturerResponse>(lecturer);

            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddLecturerMethod([FromBody] CreateLecturerRequest lecturer)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _mapper.Map<Lecturer>(lecturer);

            await _unitOfWork.Lecturers.Add(result);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetLecturerMethod), new { lecturerId = result.Id }, result);

        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateLecturerMethod([FromBody] UpdateLecturerRequest lecturer)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _mapper.Map<Lecturer>(lecturer);

            await _unitOfWork.Lecturers.Update(result);
            await _unitOfWork.CompleteAsync();

            return NoContent();

        }

        [HttpGet]
        public async Task<IActionResult> GetAllLecturersMethod()
        {
            var lecturer = await _unitOfWork.Lecturers.GetAll();

            return Ok(_mapper.Map<IEnumerable<GetLecturerResponse>>(lecturer));
        }

        [HttpDelete]
        [Route("{lecturerId:guid}")]
        public async Task<IActionResult> DeleteLecturerMethod(Guid lecturerId)
        {
            var lecturer = await _unitOfWork.Lecturers.GetById(lecturerId);

            if (lecturer == null)
            {
                return NotFound();
            }

            await _unitOfWork.Lecturers.Delete(lecturerId);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
