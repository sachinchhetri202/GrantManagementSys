using System.ComponentModel.DataAnnotations;

namespace Grant_Management_System.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Department Name")]
        public string? DepartmentName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Department Chair")]
        public string? DepartmentChair { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Department Location")]
        public string? DepartmentLocation { get; set; }
    }
}
