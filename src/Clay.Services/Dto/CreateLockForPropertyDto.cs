using System.ComponentModel.DataAnnotations;

namespace Clay.WebApi
{
    public class CreateLockForPropertyDto
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public string Identifier { get; set; }
    }
}