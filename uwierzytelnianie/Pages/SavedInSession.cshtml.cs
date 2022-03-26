using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using uwierzytelnianie.Models;
namespace uwierzytelnianie.Pages
{
    public class SavedInSessionModel : PageModel
    {
        public List<InputPicker> userDataList = new List<InputPicker>();
        public void OnGet()
        {
            var Data = HttpContext.Session.GetString("Data");
            if (Data != null)
                userDataList = JsonConvert.DeserializeObject<List<InputPicker>>(Data);

            HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(userDataList));
        }
    }
}
