namespace CropDealWebAPI.Dtos.UserProfile
{
    public class GetUserDto:BaseUserDto
    {
      
        public string UserName { get; set; }
       
        public string UserAddress { get; set; }
   
        public string UserPhnumber { get; set; }
      
        public string UserEmail { get; set; }
  
        public string UserPassword { get; set; }
      
        public int UserAccnumber { get; set; }
       
        public string UserIfsc { get; set; }
   
        public string UserBankName { get; set; }
 
        public string UserType { get; set; }

        public string? UserStatus { get; set; }

    }
}
