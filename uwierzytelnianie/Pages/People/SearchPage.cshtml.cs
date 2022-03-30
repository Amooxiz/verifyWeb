using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using uwierzytelnianie.Data;
using uwierzytelnianie.Models;

namespace uwierzytelnianie.Pages.People
{
    public class SearchPageModel : PageModel
    {
        public PeopleRepository PeopleRepository { get; set; }
        public IEnumerable<Person> People { get; set;}
        public Person Person { get; set; }
        private readonly PeopleContext _context;
        [BindProperty(SupportsGet = true)]
        public string NameTerm { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SurnameTerm { get; set; }
        public SearchPageModel(PeopleContext context)
        {
            _context = context;
            this.PeopleRepository = new PeopleRepository(context);
        }
        public void OnGet()
        {
            People = PeopleRepository.Search(NameTerm, SurnameTerm);
        }
    }
}
