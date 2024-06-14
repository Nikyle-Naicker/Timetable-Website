using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PROG2BPOE.Data;
using PROG2BPOE.Models;

namespace PROG2BPOE.Pages
{
    public class SemesterPageModel : PageModel
    {
        private readonly dbcontext db;
        public IEnumerable<Semesters> semester { get; set; }
        //Connects to the database
        public SemesterPageModel(dbcontext _db)
        {
            db = _db;
        }
        public void OnGet()
        {
            var user = HttpContext.Session.GetString("UserId");
            if (user == null)
            {
                
                RedirectToPage("Login");
            }
            else
            {
            //Gets all the data from the semester table in the database and stores it in the IEnumerable
            var guest = HttpContext.Session.GetString("");
                
                //semester = db.Semester
                semester = db.Semester.Where(s => s.Username.Contains(user));

            }
            
        }
    }
}
