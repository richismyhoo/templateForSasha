using Microsoft.EntityFrameworkCore;
using TemplateForSasha.Models;

namespace TemplateForSasha.Data;

public class DbImitation : DbContext
{
    public DbImitation(DbContextOptions<DbImitation> options) : base(options) { }
    
    public DbSet<Animal> Animals { get; set; }
}