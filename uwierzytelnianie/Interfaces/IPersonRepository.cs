using uwierzytelnianie.Models;
using Microsoft.AspNetCore.Identity;

namespace uwierzytelnianie.Interfaces
{
    public interface IPersonRepository
    {
        public IQueryable<Person> GetAllPeople();
        public IQueryable<Person> GetAllPeopleFromToday();
        public IQueryable<Person> Search(string NameTerm, string SurnameTerm, string UserId);
        public IQueryable<Person> GetRecent20();
        public void AddEntryToDB(Person person);
        public IdentityUser GetUser(string UserId);
    }
}
