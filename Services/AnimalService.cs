using Microsoft.EntityFrameworkCore;
using TemplateForSasha.Data;
using TemplateForSasha.Models;

namespace TemplateForSasha.Services;

public class AnimalService
{
    private readonly DbImitation _context;

    public AnimalService(DbImitation context)
    {
        _context = context;
    }

    public async Task<List<Animal>> GetAnimals()
    {
        var animals = await _context.Animals.ToListAsync();
        return animals;
    }

    public async Task<Animal> GetAnimal(int id)
    {
        var animal = await _context.Animals.FirstOrDefaultAsync(a => a.Id == id);
        
        if (animal is null)
            throw new KeyNotFoundException();
        
        return animal;
    }

    public async Task<Animal> AddAnimal(Animal animal)
    {
        await _context.Animals.AddAsync(animal);
        return animal;
    }

    public async Task DeleteAnimal(int id)
    {
        var animal = await _context.Animals.FirstOrDefaultAsync(a => a.Id == id);
        
        if (animal is null)
            throw new KeyNotFoundException();
        
        _context.Animals.Remove(animal);
    }
}