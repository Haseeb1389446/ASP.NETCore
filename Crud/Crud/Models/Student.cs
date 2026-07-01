using System.ComponentModel.DataAnnotations;

namespace Crud.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Class { get; set; }

        [Required]
        public string? Image { get; set; }
    }
}
