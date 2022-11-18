using AutoMapper;
using CropDealWebAPI.Dtos.Viewcrops;
using CropDealWebAPI.Models;
using CropDealWebAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CropDealWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewCropController : ControllerBase
    {
        private readonly ViewCropService _Service;


        public ViewCropController(ViewCropService service, IMapper mapper)
        {

            _Service = service;

        }

        [Authorize(Roles = "Dealer")]

        [HttpGet]
        public List<ViewCrop> GetCrops()
        {
            return _Service.ViewCrops();

        }

        [Authorize(Roles = "Farmer")]

        [HttpPost]
        public List<ViewCropDto> FarmerCrops(UserId id)
        {
            var res = _Service.ViewFarmerCrops(id);


            List<ViewCropDto> list = new List<ViewCropDto>();
            foreach (var item in res)

            {
                ViewCropDto dto = new ViewCropDto();

                dto.CropAdId = item.CropAdId;
                dto.CropImage = item.CropImage;
                dto.CropPrice = item.CropPrice;
                dto.CropQty = item.CropQty;
                dto.CropType = item.CropType;
                dto.CropName = item.CropName;
                list.Add(dto);
            }


            return list;


        }
    }
}
