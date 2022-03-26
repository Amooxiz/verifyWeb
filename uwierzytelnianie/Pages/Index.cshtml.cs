﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using uwierzytelnianie.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace uwierzytelnianie.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public bool isValidated = false;


        [BindProperty]
        public InputPicker userData { get; set; }
        public List<InputPicker>? userDataList = new List<InputPicker>();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var Data2 = HttpContext.Session.GetString("Data2");
            if (Data2 != null)
                userDataList =
                JsonConvert.DeserializeObject<List<InputPicker>>(Data2);
        }

        public IActionResult OnPost()
        {
            var Data2 = HttpContext.Session.GetString("Data2");
            if (Data2 != null)
                userDataList =
                JsonConvert.DeserializeObject<List<InputPicker>>(Data2);
            if (ModelState.IsValid)
            {
                isValidated = true;
                userDataList.Add(userData);
                HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(userDataList));
                return Page();
            }
            isValidated = false;
            return Page();
        }

    }
}