using uwierzytelnianie.Models;

namespace uwierzytelnianie.Interfaces
{
    public interface IPersonRepository
    {
        public IQueryable<Person> GetAllPeople();
        public IQueryable<Person> GetAllPeopleFromToday();
        public IQueryable<Person> Search(string NameTerm, string SurnameTerm);
        public IQueryable<Person> GetRecent20();
        public void AddEntryToDB(Person person);
    }
}
