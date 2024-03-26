using Entities;

namespace Services
{
    public class CountriesService : ICountriesService
    {
        private readonly PersonsDbContext _db;

        public CountriesService(PersonsDbContext personsDbContext) 
        { 
            _db = personsDbContext;
        }

        public List<Country> GetAllCountries() 
        {
            return _db.Countries.ToList();       
        }
    }
}