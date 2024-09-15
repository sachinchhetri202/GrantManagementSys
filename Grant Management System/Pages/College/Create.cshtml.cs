using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Grant_Management_System.Data;
using Grant_Management_System.Models;
using Grant_Management_System.Pages;
using Microsoft.EntityFrameworkCore;

namespace Grant_Management_System.Pages.College
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
            return Page();
        }

        [BindProperty]
        public Models.College College { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.College.Add(College);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
