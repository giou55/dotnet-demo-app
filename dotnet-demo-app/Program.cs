using Microsoft.EntityFrameworkCore;
using Entities;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.Add...
//builder.Environment
//builder.Configuration

//var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<PersonsDbContext>(options => {
    options.UseSqlServer(connectionString); 
});


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
