using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ERP.StudentFeedback.Core.DTOs.Request;
using ERP.StudentFeedback.Core.DTOs.Response;
using ERP.StudentFeedback.Core.Entity;
using ERP.StudentFeedback.Core.Interfaces;

namespace ERP.StudentFeedback.Api.Controllers
{
    public class ModuleController : BaseController
    {
        public ModuleController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        [Route("{moduleId:guid}")]
        public async Task<IActionResult> GetModuleMethod(Guid moduleId)
        {
            var module = await _unitOfWork.Modules.GetById(moduleId);

            if (module == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<GetModuleResponse>(module);

            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddModuleMethod([FromBody] CreateModuleRequest module)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _mapper.Map<Module>(module);

            await _unitOfWork.Modules.Add(result);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetModuleMethod), new { moduleId = result.Id }, result);

        }


        [HttpGet]
        public async Task<IActionResult> GetAllModulesMethod()
        {
            var module = await _unitOfWork.Modules.GetAll();

            return Ok(_mapper.Map<IEnumerable<GetModuleResponse>>(module));
        }

        [HttpDelete]
        [Route("{moduleId:guid}")]
        public async Task<IActionResult> DeleteModuleMethod(Guid moduleId)
        {
            var module = await _unitOfWork.Modules.GetById(moduleId);

            if (module == null)
            {
                return NotFound();
            }

            await _unitOfWork.Modules.Delete(moduleId);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
