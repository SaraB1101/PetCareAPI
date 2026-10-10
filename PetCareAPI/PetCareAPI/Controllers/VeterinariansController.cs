using Microsoft.AspNetCore.Mvc;
using PetCareAPI.Services;
using PetCareAPI.DTOs.Veterinarians;

namespace PetCareAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeterinariansController : ControllerBase
    {
        public readonly IVeterinarianService _veterinarianService;
        public VeterinariansController(IVeterinarianService veterinarianService)
        {
            _veterinarianService = veterinarianService;
        }

        [HttpGet]
        public async Task<IActionResult> GetVeterinarians()
        {
            var veterinarians = await _veterinarianService.GetVeterinariansAsync();
            return Ok(veterinarians);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateVeterinarian(CreateVeterinarianDto createVeterinarianDto)
        {
            var veterinarian = await _veterinarianService.CreateVeterinarianAsync(createVeterinarianDto);
            return CreatedAtAction(nameof(GetVeterinarian), new { id = veterinarian.Id }, veterinarian);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVeterinarian(int id, EditVeterinarianDto editVeterinarianDto)
        {
            var success = await _veterinarianService.UpdateVeterinarianAsync(id, editVeterinarianDto);
            if (!success)
            {
                return NotFound();
            }
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVeterinarian(int id)
        {
            var success = await _veterinarianService.DeleteVeterinarianAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVeterinarian(int id)
        {
            var veterinarian = await _veterinarianService.GetVeterinarianByIdAsync(id);
            if (veterinarian == null)
            {
                return NotFound();
            }
            return Ok(veterinarian);
        }
    }
}
