using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Grant_Management_System.Data;
using Grant_Management_System.Models;

namespace Grant_Management_System.Pages.Departments
{
    public class CreateModel : PageModel
    {
        private readonly Grant_Management_System.Data.Grant_Management_SystemContext _context;

        public CreateModel(Grant_Management_System.Data.Grant_Management_SystemContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            // Populate the dropdown with colleges from the database
            /*
            ViewBag.CollegeList = _context.Colleges
                .Select(c => new SelectListItem
                {
                    Value = c.CollegeId.ToString(),
                    Text = c.CollegeName
                }).ToList();
            */
            return Page();
        }

        [BindProperty]
        public Department Department { get; set; } = default!;


        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Department.Add(Department);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
