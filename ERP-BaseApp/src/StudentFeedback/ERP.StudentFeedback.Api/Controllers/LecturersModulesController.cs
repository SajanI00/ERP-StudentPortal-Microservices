using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ERP.StudentFeedback.Core.DTOs.Request;
using ERP.StudentFeedback.Core.DTOs.Response;
using ERP.StudentFeedback.Core.Entity;
using ERP.StudentFeedback.Core.Interfaces;

namespace ERP.StudentFeedback.Api.Controllers
{
    public class LecturersModulesController : BaseController
    {
        public LecturersModulesController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        [Route("{lecturersModulesId:guid}")]
        public async Task<IActionResult> GetLecturersModulesMethod(Guid lecturersModulesId)
        {
            var lecturersModules = await _unitOfWork.LecturersModules.GetById(lecturersModulesId);

            if (lecturersModules == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<GetLecturersModulesResponse>(lecturersModules);

            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddLecturersModulesMethod([FromBody] CreateLecturersModulesRequest lecturersModules)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _mapper.Map<LecturersModules>(lecturersModules);

            await _unitOfWork.LecturersModules.Add(result);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetLecturersModulesMethod), new { lecturersModulesId = result.Id }, result);

        }


        [HttpGet]
        [Route("Lecturers/{lecturerId:guid}")]
        public async Task<IActionResult> GetOneLecturerModules(Guid lecturerId)
        {

            var lecturersModules = await _unitOfWork.LecturersModules.GetOneLecturersModulesAsync(lecturerId);

            if (lecturersModules == null || !lecturersModules.Any())
                return NotFound("Modules not assigned for the lecturer");

            var moduleResponses = new List<GetModuleResponse>();

            foreach (var lecturerModule in lecturersModules)
            {
                var module = await _unitOfWork.Modules.GetById(lecturerModule.ModuleId);

                if (module == null)
                    continue; 

                var moduleResponse = _mapper.Map<GetModuleResponse>(module);
                moduleResponses.Add(moduleResponse);
            }

            if (!moduleResponses.Any())
                return NotFound("Modules not found");

            return Ok(moduleResponses);


        }

        [HttpGet]
        public async Task<IActionResult> GetAllLecturersModulesMethod()
        {
            var lecturersModules = await _unitOfWork.LecturersModules.GetAll();

            return Ok(_mapper.Map<IEnumerable<GetLecturersModulesResponse>>(lecturersModules));
        }


    }
}
