using Entities;

namespace Services
{
    public class PersonsService : IPersonsService
    {
        private readonly PersonsDbContext _db;

        public PersonsService(PersonsDbContext personsDbContext) 
        { 
            _db = personsDbContext;
        }

        public List<Person> GetAllPersons() 
        {
            return _db.Persons.ToList();       
        }
    }
}