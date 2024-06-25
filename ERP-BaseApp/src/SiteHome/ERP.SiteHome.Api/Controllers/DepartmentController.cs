using AutoMapper;
using ERP.SiteHome.Core.DTOs.Request;
using ERP.SiteHome.Core.DTOs.Response;
using ERP.SiteHome.Core.Entity;
using ERP.SiteHome.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace ERP.SiteHome.Api.Controllers
{
    public class DepartmentController : BaseController
    {
        public DepartmentController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        [HttpGet]
        [Route("{departmentId:guid}")]
        public async Task<IActionResult> GetDepartmentMethod(Guid departmentId)
        {
            var department = await _unitOfWork.Departments.GetById(departmentId);

            if (department == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<GetDepartmentResponse>(department);

            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddDepartmentMethod([FromBody] CreateDepartmentRequest department)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            var result = _mapper.Map<Department>(department);

            await _unitOfWork.Departments.Add(result);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetDepartmentMethod), new { departmentId = result.Id }, result);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartmentsMethod()
        {
            var department = await _unitOfWork.Departments.GetAll();

            return Ok(_mapper.Map<IEnumerable<GetDepartmentResponse>>(department));
        }

        [HttpDelete]
        [Route("{departmentId:guid}")]
        public async Task<IActionResult> DeleteDepartmentMethod(Guid departmentId)
        {
            var department = await _unitOfWork.Departments.GetById(departmentId);

            if (department == null)
            {
                return NotFound();
            }

            await _unitOfWork.Departments.Delete(departmentId);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }




    }
}
