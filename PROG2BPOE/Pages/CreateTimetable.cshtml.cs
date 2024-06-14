using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PROG2BPOE.Data;
using PROG2BPOE.Models;

namespace PROG2BPOE.Pages
{
    public class CreateTimetableModel : PageModel
    {
        private readonly dbcontext db;
        public Records records { get; set; }
        //Connects to the database
        public CreateTimetableModel(dbcontext _db)
        {
            db = _db;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(Records records)
        {
            var user = HttpContext.Session.GetString("UserId");
            records.Username = user;
            //if (ModelState.IsValid) 
            //{ 
            //Adds the user input to the database
            await db.Timetable.AddAsync(records);
            // Saves the database
            await db.SaveChangesAsync();
            //Redirects the user to the Module list page
            TempData["Success"] = "Timetable record added successfully";
            return RedirectToPage("TimeTable");
            //}
            //Redirects the user back to the page
            //return Page();
        }
    }
}
