using Microsoft.AspNetCore.Mvc;
using PetCareAPI.Data;
using PetCareAPI.Models;
using Microsoft.EntityFrameworkCore;
using PetCareAPI.DTOs.Owners;
using PetCareAPI.DTOs.Pets;
using PetCareAPI.Services;

namespace PetCareAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerService _ownerService;
        public OwnersController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOwners()
        {
            var owners = await _ownerService.GetOwnersAsync();        

            return Ok(owners);
        }        
        
        [HttpPost]
        public async Task<IActionResult> CreateOwner(CreateOwnerDto createOwnerDto)
        {
            var ownerDto = await _ownerService.CreateOwnerAsync(createOwnerDto);

            return CreatedAtAction(nameof(GetOwner), new { id = ownerDto.Id }, ownerDto);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOwner(int id, EditOwnerDto editOwnerDto)
        {
            var updated = await _ownerService.UpdateOwnerAsync(id, editOwnerDto);
            if (!updated)
            {
                return NotFound();
            }

            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(int id)
        {
            var deleted = await _ownerService.DeleteOwnerAsync(id);

            if(!deleted)
            {
                return NotFound();
            }

            return Ok();
        }        

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOwner(int id)
        {
            var owner = await _ownerService.GetOwnerByIdAsync(id);
            if (owner == null)
            {
                return NotFound();
            }

            return Ok(owner);
        }
        
    }
}

