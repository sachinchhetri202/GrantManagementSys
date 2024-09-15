using Grant_Management_System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Grant_Management_System.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty] //
        public Credential credential { get; set; }

        public void OnGet()
        {
        }

        private readonly Grant_Management_SystemContext _context;

        public LoginModel(Grant_Management_SystemContext context)
        {
            _context = context;
        }

        public string ErrorMessage { get; set; }

        public IActionResult OnPost()
        {
            var user = _context.User
               .FirstOrDefault(u => u.Email == credential.Email && u.Password == credential.Password);

            if (user != null)
            {

                // Store user details in session
                //HttpContext.Session.SetString("UserEmail", user.Email);
                //HttpContext.Session.SetString("FacultyType", user.FacultyType);
                //HttpContext.Session.SetString("IsAdmin", user.IsAdmin.ToString());
                //HttpContext.Session.SetString("IsChair", user.IsChair.ToString());

                return RedirectToPage("/account/Dashboard");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid username and/or password.");
                ErrorMessage = "Invalid username and/or password.";
                return Page();
            }

            return Page();
        }


        public class Credential
        {
            [Required] //Validation
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }
            [Required] //Validation
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

    }

}
