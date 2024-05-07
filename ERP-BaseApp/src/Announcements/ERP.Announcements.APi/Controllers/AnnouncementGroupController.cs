//using AutoMapper;
//using ERP.Announcements.Core.DTOs.Request;
//using ERP.Announcements.Core.DTOs.Response;
//using ERP.Announcements.Core.Entity;
//using ERP.Announcements.Core.Interfaces;
//using Microsoft.AspNetCore.Mvc;

//namespace ERP.Announcements.Api.Controllers
//{
//    public class AnnouncementGroupController : BaseController
//    {
//        public AnnouncementGroupController(
//            IUnitOfWork unitOfWork, 
//            IMapper mapper) : base(unitOfWork, mapper)
//        {
//        }

//        [HttpGet]
//        [Route("{announcementGroupId:guid}")]
//        public async Task<IActionResult> GetAnnouncementGroupMethod(Guid announcementGroupId)
//        {
//            var announcementGroup = await _unitOfWork.AnnouncementGroups.GetById(announcementGroupId);

//            if (announcementGroup == null)
//            {
//                return NotFound();
//            }

//            var result = _mapper.Map<GetAnnouncementGroupResponse>(announcementGroup);

//            return Ok(result);
//        }

//        [HttpPost("")]
//        public async Task<IActionResult> AddAnnouncementGroupMethod([FromBody] CreateAnnouncementGroupRequest announcementGroup)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest();

//            var result = _mapper.Map<AnnouncementGroup>(announcementGroup);

//            await _unitOfWork.AnnouncementGroups.Add(result);
//            await _unitOfWork.CompleteAsync();

//            return CreatedAtAction(nameof(GetAnnouncementGroupMethod), new { announcementGroupId = result.Id }, result);

//        }

//        [HttpPut("")]
//        public async Task<IActionResult> UpdateAnnouncementGroupMethod([FromBody] UpdateAnnouncementGroupRequest announcementGroup)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest();

//            var result = _mapper.Map<AnnouncementGroup>(announcementGroup);

//            await _unitOfWork.AnnouncementGroups.Update(result);
//            await _unitOfWork.CompleteAsync();

//            return NoContent();

//        }

//        [HttpGet]
//        public async Task<IActionResult> GetAllAnnouncementGroupsMethod()
//        {
//            var announcementGroup = await _unitOfWork.AnnouncementGroups.GetAll();

//            return Ok(_mapper.Map<IEnumerable<GetAnnouncementGroupResponse>>(announcementGroup));
//        }

//        [HttpDelete]
//        [Route("{announcementGroupId:guid}")]
//        public async Task<IActionResult> DeleteAnnouncementGroupMethod(Guid announcementGroupId)
//        {
//            var announcementGroup = await _unitOfWork.AnnouncementGroups.GetById(announcementGroupId);

//            if (announcementGroup == null)
//            {
//                return NotFound();
//            }

//            await _unitOfWork.AnnouncementGroups.Delete(announcementGroupId);
//            await _unitOfWork.CompleteAsync();

//            return NoContent();
//        }

//    }
//}
