using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using uwierzytelnianie.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using uwierzytelnianie.Data;
using uwierzytelnianie.Interfaces;
using uwierzytelnianie.ViewModels;
using System.Security.Claims;

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
            
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claims.Value == null)
                return Page();

            if (ModelState.IsValid)
            {
                Person.AppUser = _personService.GetUser(claims.Value);
                Person.DateTime = DateTime.Now;
                Person.IsLeapYear();
                _personService.AddEntry(Person);
                isValidated = true;
                Ppl = _personService.GetEntriesFromToday();
                return Page();
            }
            isValidated = false;
            return Page();
        }

    }
}