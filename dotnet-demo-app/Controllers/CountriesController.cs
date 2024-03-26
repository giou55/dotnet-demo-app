using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace dotnet_demo_app.Controllers
{
    [Route("[controller]")]
    public class CountriesController : Controller
    {
        private readonly ICountriesService _countriesService;

        public CountriesController(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        [Route("[action]")]
        [Route("/")]
        public IActionResult Index()
        {
            List<Country> countries = _countriesService.GetAllCountries();
            return View(countries);
        }
    }
}
