using uwierzytelnianie.Models;
using uwierzytelnianie.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace uwierzytelnianie.Interfaces
{
    public interface IPersonService
    {
        public ListPersonForListVM GetAllEntries();
        public ListPersonForListVM GetEntriesFromToday();
        public ListPersonForListVM GetSearchResults(string NameTerm, string SurnameTerm, string UserId);
        public ListPersonForListVM GetRecent20People();
        public void AddEntry(Person person);
        public AppUser GetUser(string UserId);
    }
}
