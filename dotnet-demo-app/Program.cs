using Microsoft.EntityFrameworkCore;
using Entities;
using Services;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.Add...
//builder.Environment
//builder.Configuration

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICountriesService, CountriesService>();
builder.Services.AddScoped<IPersonsService, PersonsService>();

//var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<PersonsDbContext>(options => {
    options.UseSqlServer(connectionString); 
});


var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
