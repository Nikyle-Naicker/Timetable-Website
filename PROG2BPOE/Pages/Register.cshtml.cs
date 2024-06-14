using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PROG2BPOE.Data;
using PROG2BPOE.Models;
using System.Security.Cryptography;

namespace PROG2BPOE.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly dbcontext db;
        public Users user { get; set; }
        //Connects to the database
        public RegisterModel(dbcontext _db)
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
        public IActionResult OnPost(string Username, string Password)
        {
            

            // Check if the username is already taken
            if (db.Student.Any(u => u.Email ==Username))
            {
                ModelState.AddModelError("UsernameTaken", "The username is already taken.");
                return Page();
            }

            // Hash the password
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(Password);

            // Create a new user
            var newUser = new Users
            {
                Email = Username,
                Password = hashedPassword,
            };

            // Add the user to the database
            db.Student.Add(newUser);
            db.SaveChanges();
            TempData["success"] = "Registered successfully";
            // Redirect to login page or perform other actions
            return RedirectToPage("/Login");
        }

    }
}
