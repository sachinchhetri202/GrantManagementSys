using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace GrantApp.Pages.Account
{
    public class SignUpModel : PageModel
    {

        private const string PageName = "/Account/Login";
        private static bool adminExists = false;
        private static bool chairExists = false;

        [BindProperty]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [BindProperty]
        [Required]
        public string FirstName { get; set; }

        [BindProperty]
        [Required]
        public string LastName { get; set; }

        [BindProperty]
        [Required]
        public string WNumber { get; set; }

        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [BindProperty]
        public bool IsAdmin { get; set; }

        [BindProperty]
        public bool IsChair { get; set; }

        [BindProperty]
        [Required]
        public string FacultyType { get; set; }

        [BindProperty]
        public string Department { get; set; }

        public bool CanShowAdmin => !adminExists;

        // Handle the form submission
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); 
            }

            if (IsAdmin && Email != "grant.admin@weber.edu")
            {
                ModelState.AddModelError(string.Empty, "Admin email must be grant.admin@weber.edu.");
                return Page();
            }

           
            if (IsAdmin && adminExists)
            {
                ModelState.AddModelError(string.Empty, "Admin already exists.");
                return Page();
            }

            if (IsChair && chairExists)
            {
                ModelState.AddModelError(string.Empty, "Chair already exists.");
                return Page();
            }
            if (IsAdmin) adminExists = true;
            if (IsChair) chairExists = true;

            return RedirectToPage(PageName);
        }
    }
}
