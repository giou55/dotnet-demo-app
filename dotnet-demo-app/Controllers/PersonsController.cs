using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace dotnet_demo_app.Controllers
{
    [Route("[controller]")]
    public class PersonsController : Controller
    {
        private readonly IPersonsService _personsService;

        public PersonsController(IPersonsService personsService)
        {
            _personsService = personsService;
        }

        [Route("[action]")]
        [Route("/")]
        public IActionResult Index()
        {
            List<Person> persons = _personsService.GetAllPersons();
            return View(persons);
        }
    }
}
