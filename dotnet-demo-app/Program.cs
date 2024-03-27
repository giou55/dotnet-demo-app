using Microsoft.EntityFrameworkCore;
using Entities;
using Services;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.Add...
//builder.Environment...
//builder.Configuration...

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

// middleware
app.Use(async (context, next) => {
    await context.Response.WriteAsync("This is a middleware \n");
    await next(context);
});

app.UseRouting(); // enable routing

app.MapControllers();

app.Map("/", () => "Hello World!"); // it works for all HTTP methods

app.Map("files/{filename}.{extension}", async context => {
    string? filename = Convert.ToString(context.Request.RouteValues["filename"]);
    await context.Response.WriteAsync($"Filename is: {filename}");
});
    

app.MapGet("/example1", async (context) => await context.Response.WriteAsync("This is a get request"));

app.MapPost("/example2", async (context) => await context.Response.WriteAsync("This is a post request"));

// app.Run(async (context) => await context.Response.WriteAsync($"The path is: {context.Request.Path}"));

app.Run();
