using Microsoft.EntityFrameworkCore;
using Entities;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.Add...
//builder.Environment
//builder.Configuration

builder.Services.AddDbContext<PersonsDbContext>(options => {
    options.UseSqlServer(); 
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
