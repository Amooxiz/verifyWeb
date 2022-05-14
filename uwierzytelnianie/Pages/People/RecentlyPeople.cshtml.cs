using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using uwierzytelnianie.Data;
using uwierzytelnianie.Interfaces;
using uwierzytelnianie.Models;
using uwierzytelnianie.ViewModels;

namespace uwierzytelnianie.Pages
{
    [Authorize]
    public class RecentlyPeopleModel : PageModel
    {
        public ListPersonForListVM Ppl { get; set; }
        public PersonForListVM PersonVM { get; set; }
        private readonly IPersonService _personService;
        public RecentlyPeopleModel(IPersonService personService)
        {
            _personService = personService;
        }
        public void OnGet()
        {
            Ppl = _personService.GetAllEntries();
        }
    }
}
