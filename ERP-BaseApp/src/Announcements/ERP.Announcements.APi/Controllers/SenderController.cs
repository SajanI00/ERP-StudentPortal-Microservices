using AutoMapper;
using ERP.Announcements.Core.DTOs.Request;
using ERP.Announcements.Core.DTOs.Response;
using ERP.Announcements.Core.Entity;
using ERP.Announcements.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Announcements.Api.Controllers
{
    public class SenderController : BaseController
    {
        public SenderController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        [Route("{senderId:guid}")]
        public async Task<IActionResult> GetSenderMethod(Guid senderId)
        {
            var sender = await _unitOfWork.Senders.GetById(senderId);

            if (sender == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<GetSenderResponse>(sender);

            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddSenderMethod([FromBody] CreateSenderRequest sender)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _mapper.Map<Sender>(sender);

            await _unitOfWork.Senders.Add(result);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetSenderMethod), new { senderId = result.Id }, result);

        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateSenderMethod([FromBody] UpdateSenderRequest sender)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _mapper.Map<Sender>(sender);

            await _unitOfWork.Senders.Update(result);
            await _unitOfWork.CompleteAsync();

            return NoContent();

        }

        [HttpGet]
        public async Task<IActionResult> GetAllSendersMethod()
        {
            var sender = await _unitOfWork.Senders.GetAll();

            return Ok(_mapper.Map<IEnumerable<GetSenderResponse>>(sender));
        }

        [HttpDelete]
        [Route("{senderId:guid}")]
        public async Task<IActionResult> DeleteSenderMethod(Guid senderId)
        {
            var sender = await _unitOfWork.Senders.GetById(senderId);

            if (sender == null)
            {
                return NotFound();
            }

            await _unitOfWork.Senders.Delete(senderId);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
