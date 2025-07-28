using System.ComponentModel.DataAnnotations;

namespace CompanyApp.DTOs
{
    public class EmployeeCreateDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Department { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
