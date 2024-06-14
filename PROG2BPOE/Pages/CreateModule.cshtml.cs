using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PROG2BPOE.Data;
using PROG2BPOE.Models;

namespace PROG2BPOE.Pages
{
    public class CreateModuleModel : PageModel
    {
        private readonly dbcontext db;
        public Modules modules { get; set; }
        //Connects to the database
        public CreateModuleModel(dbcontext _db)
        {
            db = _db;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(Modules modules)
        {
            var user = HttpContext.Session.GetString("UserId");
            modules.Username = user;
            //if (ModelState.IsValid) 
            //{ 
            //Adds the user input to the database
            
            await db.Module.AddAsync(modules);
            // Saves the database
            await db.SaveChangesAsync();
            //Redirects the user to the Module list page
            TempData["success"] = "Module added successfully";
            return RedirectToPage("ModulePage");
            //}
            //Redirects the user back to the page
            //return Page();
        }
    }
}
