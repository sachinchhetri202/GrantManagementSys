using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Grant_Management_System.Data;
using Grant_Management_System.Models;

namespace Grant_Management_System.Pages.College
{
    public class EditModel : PageModel
    {
        private readonly Grant_Management_System.Data.Grant_Management_SystemContext _context;

        public EditModel(Grant_Management_System.Data.Grant_Management_SystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.College College { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var college = await _context.College.FirstOrDefaultAsync(m => m.ID == id);
            if (college == null)
            {
                return NotFound();
            }
            College = college;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(College).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollegeExists(College.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CollegeExists(int id)
        {
            return _context.College.Any(e => e.ID == id);
        }
    }
}
