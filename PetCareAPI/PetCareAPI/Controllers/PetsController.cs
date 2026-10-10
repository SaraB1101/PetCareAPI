using Microsoft.AspNetCore.Mvc;
using PetCareAPI.DTOs.Pets;
using PetCareAPI.Services;

namespace PetCareAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPets()
        {
            var pets = await _petService.GetPetsAsync();
            return Ok(pets);
        }

        
        [HttpPost]
        public async Task<IActionResult> CreatePet(CreatePetDto createPetDto)
        {
            var pet = await _petService.CreatePetAsync(createPetDto);

            return CreatedAtAction(nameof(GetPet), new { id = pet.Id }, pet);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePet(int id, EditPetDto editPetDto)
        {
            var updated = await _petService.UpdatePetAsync(id, editPetDto);

            if (!updated)
            {
                return NotFound();
            }            

            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
            var deleted = await _petService.DeletePetAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return Ok();
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPet(int id)
        {
            var pet = await _petService.GetPetByIdAsync(id);

            if (pet == null)
            {
                return NotFound();
            }
            
            return Ok(pet);
        }
        

    }
}
