using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using uwierzytelnianie.Data;
using uwierzytelnianie.Models;

namespace uwierzytelnianie.Pages
{
    public class RecentlyPeopleModel : PageModel
    {
        public List<Person> People { get; set; }
        public Person Person { get; set; }
        private readonly PeopleContext _context;
        public RecentlyPeopleModel(PeopleContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            People = (_context.Person.Count() > 20) ?
                     (_context.Person.OrderByDescending(x => x.DateTime)).Take(20).ToList() :
                     _context.Person.OrderByDescending(x => x.DateTime).ToList();
        }
    }
}
