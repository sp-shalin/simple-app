using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class WebUser
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
