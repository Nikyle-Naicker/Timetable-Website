using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PROG2BPOE.Data;
using PROG2BPOE.Models;

namespace PROG2BPOE.Pages
{
    public class CreateSemesterModel : PageModel
    {
        private readonly dbcontext db;
        //Gets and sets the user details from the front-end
        public Semesters semester { get; set; }
        //Connects to the database
        public CreateSemesterModel(dbcontext _db)
        {
            db = _db;
        }
        public void OnGet()
        {
            
        }
        public async Task<IActionResult> OnPost(Semesters semester)
        {

            var user = HttpContext.Session.GetString("UserId");
            semester.Username = user;
            //if (ModelState.IsValid)
            //{
                //Adds the data to the database
                await db.Semester.AddAsync(semester);
                //Saves the data to the database
                await db.SaveChangesAsync();
            //Redirects the user to the Semester list Page
            TempData["success"] = "Semester added successfully";
            return RedirectToPage("SemesterPage");
            //}
            //return Page();
        }
    }
}
