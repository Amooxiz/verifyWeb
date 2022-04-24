using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using uwierzytelnianie.Models;
namespace uwierzytelnianie.Pages
{
    public class SavedInSessionModel : PageModel
    {
        public List<Person> userDataList = new List<Person>();
        public void OnGet()
        {
            //var Data = HttpContext.Session.GetString("Data");
            //if (Data != null)
            //    userDataList = JsonConvert.DeserializeObject<List<Person>>(Data);

            //HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(userDataList));
        }
    }
}
