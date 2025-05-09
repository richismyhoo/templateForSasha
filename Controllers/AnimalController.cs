using Microsoft.AspNetCore.Mvc;
using TemplateForSasha.Models;
using TemplateForSasha.Services;

namespace TemplateForSasha.Controllers;

[ApiController]
[Route("/api/animals")]
public class AnimalController : ControllerBase
{
    private readonly AnimalService _animalService;

    public AnimalController(AnimalService animalService)
    {
        _animalService = animalService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Animal>>> GetAnimals()
    {
        var animals = await _animalService.GetAnimals(); 
        return Ok(animals);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Animal>> GetAnimal(int id)
    {
        try
        {
            var animal = await _animalService.GetAnimal(id);
            return Ok(animal);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpPost]
    public async Task<ActionResult<Animal>> PostAnimal(Animal animal)
    {
        var newAnimal = await _animalService.AddAnimal(animal);
        return StatusCode(201, newAnimal);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAnimal(int id)
    {
        try
        {
            await _animalService.DeleteAnimal(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }
}