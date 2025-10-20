using CleanCity.Models;
using Microsoft.AspNetCore.Mvc;
using TodoApp_Restructuring_Backend.Repositories.Implementations;

namespace TodoApp_Restructuring_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CleanCityController : ControllerBase
    {
        private readonly CleanCityRepository _repository;

        public CleanCityController(CleanCityRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddLocation([FromBody] LocationEntry location)
        {
            int result = await _repository.AddLocationAsync(location);
            return result > 0 ? Ok("Location added successfully") : BadRequest("Failed to add location");
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllLocations()
        {
            var list = await _repository.GetAllLocationsAsync();
            return Ok(list);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetLocationById(Guid id)
        {
            var location = await _repository.GetLocationByIdAsync(id);
            if (location == null)
                return NotFound($"❌ No location found for ID: {id}");
            return Ok(location);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateLocation([FromBody] LocationEntry location)
        {
            location.UpdatedAt = DateTime.UtcNow;
            int result = await _repository.UpdateLocationAsync(location);
            return result > 0 ? Ok("✅ Location updated successfully") : NotFound("❌ Location not found or not updated");
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteLocation(Guid id)
        {
            int result = await _repository.DeleteLocationAsync(id);
            return result > 0 ? Ok("✅ Location deleted successfully") : NotFound("❌ Location not found");
        }
    }
}
