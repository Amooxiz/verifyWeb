using uwierzytelnianie.Data;
using uwierzytelnianie.Interfaces;
using uwierzytelnianie.Models;
using Microsoft.AspNetCore.Identity;

namespace uwierzytelnianie.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PeopleContext _context;
        public PersonRepository(PeopleContext context)
        {
            _context = context;
        }
        public IQueryable<Person> GetAllPeople()
        {
            return _context.Person;
        }
        public IQueryable<Person> GetAllPeopleFromToday()
        {
            return _context.Person.Where(x => x.DateTime.Date == DateTime.Today);
        }
        public IQueryable<Person> Search(string NameTerm, string SurnameTerm, string UserId)
        {
            if (string.IsNullOrEmpty(NameTerm) && string.IsNullOrEmpty(SurnameTerm))
            {
                return _context.Person.Where(o => o.AppUser.Id == UserId).OrderByDescending(o => o.DateTime);
            }
            else if (string.IsNullOrEmpty(NameTerm))
            {
                return _context.Person.Where(o => o.Surname.StartsWith(SurnameTerm) && o.AppUser.Id == UserId).OrderByDescending(o => o.DateTime);
            }
            else if (string.IsNullOrEmpty(SurnameTerm))
            {
                return _context.Person.Where(o => o.Name.StartsWith(NameTerm) && o.AppUser.Id == UserId).OrderByDescending(o => o.DateTime);
            }
            else
            {
                return _context.Person.Where(o => (o.Name.StartsWith(NameTerm) &&
                    o.Surname.StartsWith(SurnameTerm)) && o.AppUser.Id == UserId).OrderByDescending(o => o.DateTime);
            }
        }
        public IQueryable<Person> GetRecent20()
        {
            return (_context.Person.Count() > 20) ?
                     (_context.Person.OrderByDescending(x => x.DateTime)).Take(20) :
                     _context.Person.OrderByDescending(x => x.DateTime);
        }
        public void AddEntryToDB(Person person)
        {
            _context.Person.Add(person);
            _context.SaveChanges();
        }
        
        public IdentityUser GetUser(string UserId)
        {
            return _context.Users.Find(UserId);
        }
    }
}
