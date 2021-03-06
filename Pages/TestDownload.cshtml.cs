﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotNetRazor.Pages
{
    public class TestDownloadModel : PageModel
    {
        [BindProperty]
        public int SleepTime { get; set; } = 5000;

        [BindProperty]
        public string Nonce { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            System.Threading.Thread.Sleep(SleepTime);

            Response.Headers["Content-disposition"] = "Attachment; filename=\"Flintstones.csv\"";
            Response.Cookies.Append($"Download-nonce-{Nonce}", Nonce);
            return new ContentResult()
            {
                Content = "FirstName,LastName,Age\nFred,Flintstone,35\nBarney,Rubble,35\nWilma,Flintstone,33\nBetty,Rubble,33",
                ContentType = "text/csv"
            };
        }
    }
}
