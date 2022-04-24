using uwierzytelnianie.Models;
using uwierzytelnianie.ViewModels;

namespace uwierzytelnianie.Interfaces
{
    public interface IPersonService
    {
        public ListPersonForListVM GetAllEntries();
        public ListPersonForListVM GetEntriesFromToday();
        public ListPersonForListVM GetSearchResults(string NameTerm, string SurnameTerm);
        public ListPersonForListVM GetRecent20People();
        public void AddEntry(Person person);
    }
}
