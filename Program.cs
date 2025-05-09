using Microsoft.EntityFrameworkCore;
using TemplateForSasha.Data;
using TemplateForSasha.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbImitation>(options =>
    options.UseInMemoryDatabase("MyFakeDb"),
    ServiceLifetime.Singleton);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<AnimalService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
