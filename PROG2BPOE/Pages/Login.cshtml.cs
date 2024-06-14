using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PROG2BPOE.Data;
using PROG2BPOE.Models;
using PROG2BPOE.Pages.Shared;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography;

namespace PROG2BPOE.Pages
{
    public class LoginModel : PageModel
    {
        private readonly dbcontext db;
        //Gets and sets the user details from the front-end
        public Users User { get; set; }

        //Connects to the database
        public LoginModel(dbcontext _db)
        {
            db = _db;
        }
        public void OnGet()
        {
        }
        [BindProperty] 
        public string Username { get; set; }

        [BindProperty] 
        public string Password { get; set; }

        public IActionResult OnPost()
        {
            var user = db.Student.SingleOrDefault(u => u.Email == Username);

            if (user == null || !user.VerifyPassword(Password))
            {
                // Authentication failed
                ModelState.AddModelError("LoginFailed", "Invalid username or password.");
                return Page();
            }

            // Authentication succeeded
            HttpContext.Session.SetString("UserId", Username);
            TempData["success"] = "Login successful";
            return RedirectToPage("/Index");
        }
    }
}
