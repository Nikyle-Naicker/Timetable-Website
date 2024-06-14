using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PROG2BPOE.Data;
using PROG2BPOE.Models;

namespace PROG2BPOE.Pages
{
    public class ModulePageModel : PageModel
    {
        private readonly dbcontext db;
        public IEnumerable<Modules> modules { get; set; }

        // Connects to the database
        public ModulePageModel(dbcontext _db)
        {
            db = _db;
        }
        public void OnGet()
        {
            if (HttpContext.Session.GetString("UserId") == null)
            {
                RedirectToPage("/Login");
            }
            else
            {
                //Gets all the data from the semester table in the database and stores it in the IEnumerable
                var user = HttpContext.Session.GetString("UserId");
                //semester = db.Semester
                modules = db.Module.Where(m => m.Username.Contains(user));
            }
            
        }
    }
}
