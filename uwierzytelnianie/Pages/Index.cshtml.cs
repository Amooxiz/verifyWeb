using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using uwierzytelnianie.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using uwierzytelnianie.Data;
using uwierzytelnianie.Interfaces;
using uwierzytelnianie.ViewModels;

namespace uwierzytelnianie.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public bool isValidated = false;
        [BindProperty]
        public Person Person { get; set; }
        private readonly IPersonService _personService;
        public PersonForListVM PersonVM { get; set; }
        public ListPersonForListVM Ppl { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IPersonService service)
        {
            _logger = logger;
            _personService = service;
        }
        public void OnGet()
        {
            Ppl = _personService.GetEntriesFromToday();
        }


        public IActionResult OnPost()
        {
            //var Data = HttpContext.Session.GetString("Data");
            //if (Data != null)
            //    PeopleList = JsonConvert.DeserializeObject<List<Person>>(Data);

            if (ModelState.IsValid)
            {
                Person.DateTime = DateTime.Now;
                Person.IsLeapYear();
                _personService.AddEntry(Person);
                isValidated = true;
                Ppl = _personService.GetEntriesFromToday();
                //PeopleList.Add(Person);
                //HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(PeopleList));
                return Page();
            }
            isValidated = false;
            return Page();
        }

    }
}