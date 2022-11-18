using AutoMapper;
using CropDealWebAPI.Dtos.Crop;
using CropDealWebAPI.Dtos.CropOnSale;
using CropDealWebAPI.Dtos.UserProfile;
using CropDealWebAPI.Models;

namespace CropDealWebAPI.Configurations
{
    public class MapperConfig: Profile
    {
        public MapperConfig()
        {
            CreateMap<CreateUserDto, UserProfile>().ReverseMap();
            CreateMap<UpdateUserDto, UserProfile>().ReverseMap();
            CreateMap<GetUserDto, UserProfile>().ReverseMap();
            CreateMap<GetCropDto, Crop>().ReverseMap();
            CreateMap<CreateCropDto, Crop>().ReverseMap();
            CreateMap<CreateCropOnSaleDto, CropOnSale>().ReverseMap();
            CreateMap<GetCropOnSaleDto, CropOnSale>().ReverseMap();

        }
    }
}
