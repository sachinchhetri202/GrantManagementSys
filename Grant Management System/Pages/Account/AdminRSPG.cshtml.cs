using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Grant_Management_System.Pages.Account
{
    public class AdminRSPGModel : PageModel
    {
   
        public List<Member> Members { get; set; }

 
        [BindProperty]
        public string Name { get; set; }
            

        [BindProperty]
        public string Department { get; set; }

        [BindProperty]
        public string College { get; set; }

        [BindProperty]
        public string L { get; set; }

        [BindProperty]
        public string F { get; set; }

      
        public void OnGet()
        {
           // Example of the account table 
            Members = new List<Member>
            {
                new Member { Name = "John Doe", Department = "Computer Science", College = "Engineering", L = "L1", F = "F1" },
                new Member { Name = "Jane Smith", Department = "Physics", College = "Science", L = "L2", F = "F2" }
            };
        }
        // 
        public IActionResult OnPostAddMember()
        {
            if (!ModelState.IsValid)
            {
               
                return Page();
            }

            Members.Add(new Member
            {
                Name = Name,
                Department = Department,
                College = College,
                L = L,
                F = F
            });

            return RedirectToPage();
        }
    }

    public class Member
    {
        public required string Name { get; set; }
        public required string Department { get; set; }
        public required string College { get; set; }
        public required string L { get; set; }
        public required string F { get; set; }
    }
}
