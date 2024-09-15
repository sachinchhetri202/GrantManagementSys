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
    public class IndexModel : PageModel
    {
        private readonly Grant_Management_System.Data.Grant_Management_SystemContext _context;

        public IndexModel(Grant_Management_System.Data.Grant_Management_SystemContext context)
        {
            _context = context;
        }

        public IList<Models.College> College { get; set; } = default!;

        public async Task OnGetAsync()
        {
            College = await _context.College.ToListAsync();
            //College = await _context.College
            //    .Include(c => c.Dean).ToListAsync();
        }
    }
}
