using uwierzytelnianie.Interfaces;
using uwierzytelnianie.Models;
using uwierzytelnianie.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace uwierzytelnianie.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepo;
        public PersonService(IPersonRepository personRepo)
        {
            _personRepo = personRepo;
        }
        public ListPersonForListVM GetAllEntries()
        {
            var people = _personRepo.GetAllPeople();
            ListPersonForListVM result = new ListPersonForListVM();
            result.People = new List<PersonForListVM>();
            foreach (var person in people)
            {
                var pVM = new PersonForListVM()
                {
                    Id = person.Id,
                    FullName = person.Name + " " + person.Surname,
                    JoinDate = $"{person.DateTime.Day}.{person.DateTime.Month}.{person.DateTime.Year}",
                    Year = person.Year
                };
                result.People.Add(pVM);
            }
            result.Count = result.People.Count;
            return result;
        }
        public ListPersonForListVM GetEntriesFromToday()
        {
            var people = _personRepo.GetAllPeopleFromToday();
            ListPersonForListVM result = new ListPersonForListVM();
            result.People = new List<PersonForListVM>();
            foreach (var person in people)
            {
                var pVM = new PersonForListVM()
                {
                    Id = person.Id,
                    FullName = person.Name + " " + person.Surname,
                    JoinDate = $"{person.DateTime.Day}.{person.DateTime.Month}.{person.DateTime.Year}",
                    Year = person.Year
                };
                result.People.Add(pVM);
            }
            result.Count = result.People.Count;
            return result;
        }
        public ListPersonForListVM GetSearchResults(string NameTerm, string SurnameTerm, string UserId)
        {
            var people = _personRepo.Search(NameTerm, SurnameTerm, UserId);
            ListPersonForListVM result = new ListPersonForListVM();
            result.People = new List<PersonForListVM>();
            foreach (var person in people)
            {
                var pVM = new PersonForListVM()
                {
                    Id = person.Id,
                    FullName = person.Name + " " + person.Surname,
                    JoinDate = $"{person.DateTime.Day}.{person.DateTime.Month}.{person.DateTime.Year}",
                    Year = person.Year
                };
                result.People.Add(pVM);
            }
            result.Count = result.People.Count;
            return result;
        }
        public ListPersonForListVM GetRecent20People()
        {
            var people = _personRepo.GetRecent20();
            ListPersonForListVM result = new ListPersonForListVM();
            result.People = new List<PersonForListVM>();
            foreach (var person in people)
            {
                var pVM = new PersonForListVM()
                {
                    Id = person.Id,
                    FullName = person.Name + " " + person.Surname,
                    JoinDate = $"{person.DateTime.Day}.{person.DateTime.Month}.{person.DateTime.Year}",
                    Year = person.Year
                };
                result.People.Add(pVM);
            }
            result.Count = result.People.Count;
            return result;
        }
        public void AddEntry(Person person)
        {
            _personRepo.AddEntryToDB(person);
        }

        public AppUser GetUser(string UserId)
        {
            return (AppUser)_personRepo.GetUser(UserId);
        }
    }
}
