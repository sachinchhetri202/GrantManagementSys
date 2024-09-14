using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Grant_Management_System.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string WNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [BindProperty]
        public bool IsAdmin { get; set; }

        public bool IsChair { get; set; }

        [Required]
        public string FacultyType { get; set; }

        public string Department { get; set; }
    }
}
