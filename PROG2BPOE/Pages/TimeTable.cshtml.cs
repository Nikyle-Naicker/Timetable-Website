using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PROG2BPOE.Data;
using PROG2BPOE.Models;
using System.Reflection;

namespace PROG2BPOE.Pages
{
    public class TimeTableModel : PageModel
    {
        private readonly dbcontext db;
        public IEnumerable<Records> records { get; set; }
        public IEnumerable<Modules> modules { get; set; }
        public IEnumerable<Semesters> semester { get; set; }
        //Connects to the database
        public TimeTableModel(dbcontext _db)
        {
            db = _db;
        }
        public void OnGet()
        {
            var user = HttpContext.Session.GetString("UserId");
            if (user != null)
            {
                records = db.Timetable.Where(t => t.Username.Contains(user));
                
            }
            else
            {
                RedirectToPage("/Login"); 
            }
        }
    }
}
