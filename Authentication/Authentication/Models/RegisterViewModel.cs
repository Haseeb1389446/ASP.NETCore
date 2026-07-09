using System.ComponentModel.DataAnnotations;

namespace Authentication.Models
{
    public class RegisterViewModel
    {
        public string? Name { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
