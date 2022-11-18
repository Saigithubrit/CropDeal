using System.ComponentModel.DataAnnotations;

namespace CropDealWebAPI.Dtos.UserProfile
{
    public class CreateUserDto
    {
       [Required]
        public string UserName { get; set; }
        [Required]
        public string UserAddress { get; set; }
        [Required]
        public string UserPhnumber { get; set; }
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public string UserPassword { get; set; }
        [Required]
        public int UserAccnumber { get; set; }
        [Required]
        public string UserIfsc { get; set; }
        [Required]
        public string UserBankName { get; set; }
        [Required]
        public string UserType { get; set; }
     
        
    }
}
