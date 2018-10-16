using System.ComponentModel.DataAnnotations;

namespace Clay.WebApi
{
    public class CreatePropertyViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}