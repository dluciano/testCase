using System.ComponentModel.DataAnnotations;

namespace Clay.WebApi
{
    public class CreatePropertyDto
    {
        [Required]
        public string Name { get; set; }
    }
}