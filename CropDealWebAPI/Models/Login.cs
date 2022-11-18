using System.ComponentModel.DataAnnotations;

namespace CropDealWebAPI.Models
{
    public class Login
    {
        [Required]
        public string Role { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
