using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using uwierzytelnianie.Data;
using uwierzytelnianie.Models;

namespace uwierzytelnianie.Pages
{
    public class RecentlyPeopleModel : PageModel
    {
        public List<Person> People { get; set; }
        public List<Person> Recent20 { get; set; }
        private readonly PeopleContext _context;
        public RecentlyPeopleModel(PeopleContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            People = _context.Person.ToList();
           
            Recent20 = (People.Count > 20) ? People.GetRange(0, 20) : People.ToList();

            Recent20.Sort((x, y) => y.DateTime.CompareTo(x.DateTime));
        }
    }
}
