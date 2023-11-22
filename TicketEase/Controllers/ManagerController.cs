﻿using Microsoft.AspNetCore.Mvc;
using TicketEase.Application.DTO;
using TicketEase.Application.Interfaces.Services;
using TicketEase.Domain;

namespace TicketEase.Controllers
{
    [Route("api/managers")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerServices _managerService;
        public ManagerController(IManagerServices managerService)
        {
            _managerService = managerService;
        }
        [HttpGet("GetById")]
        public IActionResult GetManagersById(string id)
        {
            var response = _managerService.GetManagerById(id);
            return Ok(response);
        }
        [HttpPut("Edit")]
        public IActionResult EditManager(string id, EditManagerDto managerDTO)
        {
            var response = _managerService.EditManager(id, managerDTO);
            return Ok(response);
        }
        [HttpGet("GetAll")]
        public IActionResult GetAllManage(int page, int perPage)
        {
            var response = _managerService.GetAllManagerByPagination(page, perPage);
            return Ok(response);
        }

        [HttpPost("sendManagerInformation")]
        public async Task<IActionResult> SendManagerInformation(ManagerInfoCreateDto managerInfoCreateDto)
        {

            var response = await _managerService.SendManagerInformationToAdminAsync(managerInfoCreateDto);

            return Ok(response);
        }

        [HttpPut("updateProfile/{managerId}")]
        public async Task<IActionResult> UpdateManagerProfile(string managerId, [FromBody] UpdateManagerDto updateManagerDto)
        {

            var result = await _managerService.UpdateManagerProfileAsync(managerId, updateManagerDto);
            return Ok(new ApiResponse<bool>(true, "User updated successfully.", 200, true, null));

        }

        [HttpPut("deactivate/{id}")]
        public IActionResult DeactivateManager(string id)
        {
            var response = _managerService.DeactivateManager(id);
            if (response != null)
                return Ok(response);
            return NotFound();
        }

        [HttpPut("activate/{id}")]
        public IActionResult ActivateManager(string id)
        {
            var response = _managerService.ActivateManager(id);
            if (response != null)
                return Ok(response);
            return NotFound();
        }

    }
}

