using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using uwierzytelnianie.Data;
using uwierzytelnianie.Interfaces;
using uwierzytelnianie.Models;
using uwierzytelnianie.ViewModels;

namespace uwierzytelnianie.Pages.People
{
    public class SearchPageModel : PageModel
    {
        private readonly IPersonService _personService;
        public ListPersonForListVM Ppl { get; set;}
        public PersonForListVM PersonVM { get; set; }
        [BindProperty(SupportsGet = true)]
        public string NameTerm { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SurnameTerm { get; set; }
        public SearchPageModel(IPersonService personService)
        {
            _personService = personService;
        }
        public void OnGet()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            Ppl = _personService.GetSearchResults(NameTerm, SurnameTerm, claims.Value);
        }
    }
}
