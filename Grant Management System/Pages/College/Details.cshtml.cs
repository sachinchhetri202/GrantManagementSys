using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Grant_Management_System.Data;
using Grant_Management_System.Models;

namespace Grant_Management_System.Pages.College
{
    public class DetailsModel : PageModel
    {
        private readonly Grant_Management_System.Data.Grant_Management_SystemContext _context;

        public DetailsModel(Grant_Management_System.Data.Grant_Management_SystemContext context)
        {
            _context = context;
        }

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
            else
            {
                College = college;
            }
            return Page();
        }
    }
}
