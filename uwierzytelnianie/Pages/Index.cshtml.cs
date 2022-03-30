using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using uwierzytelnianie.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using uwierzytelnianie.Data;

namespace uwierzytelnianie.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public bool isValidated = false;

        private readonly PeopleContext _context;


        [BindProperty]
        public Person Person { get; set; }
        public List<Person>? PeopleList = new List<Person>();

        public IndexModel(ILogger<IndexModel> logger, PeopleContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IList<Person> People { get; set; }
        public void OnGet()
        {
            People = _context.Person.ToList();
        }


        public IActionResult OnPost()
        {
            var Data = HttpContext.Session.GetString("Data");
            if (Data != null)
                PeopleList = JsonConvert.DeserializeObject<List<Person>>(Data);

            if (ModelState.IsValid)
            {
                Person.DateTime = DateTime.Now;
                Person.IsLeapYear();
                _context.Person.Add(Person);
                _context.SaveChanges();
                isValidated = true;
                PeopleList.Add(Person);
                HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(PeopleList));
                return Page();
            }
            isValidated = false;
            return Page();
        }

    }
}