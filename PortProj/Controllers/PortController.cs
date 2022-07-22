using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortProj.Models;
using PortProj.Repository;

namespace PortProj.Controllers
{
    [Route("api/Port")]
    [ApiController]
    public class PortController : ControllerBase
    {
        private readonly IPortRepository _portRepository;
        public PortController(IPortRepository portRepository)
        {
            _portRepository = portRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllAvlSlots()
        {
            var slots = await _portRepository.GetAvalSlotsAsync();
            return Ok(slots);
        }
        [HttpPost("")]
        public async Task<IActionResult> AddUser([FromBody] UsersModel userModel)
        {
            var user = await _portRepository.AddUserAsync(userModel);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSlot([FromBody] SlotsModel slotsModel, [FromRoute] int id)
        {
            await _portRepository.UpdateSlot(id, slotsModel);
            return Ok();
        }

    }
}
