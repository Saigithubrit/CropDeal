using CropDealWebAPI.Dtos;
using CropDealWebAPI.Models;

namespace CropDealWebAPI.Repository
{
    public class ViewCrops : IViewCropRepository
    {
        CropDealContext _context;
        ExceptionRepositry _exception;
        public ViewCrops(CropDealContext context, ExceptionRepositry exception)
        {
            _context = context;
            _exception = exception;
        }

        #region ViewCropsAd
        /// <summary>
        /// this method is used to view the crops posted by the famers
        /// </summary>
        /// <returns></returns>
        public List<ViewCrop> ViewCropsAsync()
        {
            try
            {

                var query = (from a in _context.CropOnSales
                             join b in _context.Crops on a.CropId equals b.CropId
                             join c in _context.UserProfiles on a.FarmerId equals c.UserId
                             select new ViewCrop()
                             {
                                 CropAdId = a.CropAdId,
                                 CropName = a.CropName,
                                 CropType = a.CropType,
                                 CropQty = a.CropQty,
                                 CropPrice = a.CropPrice,
                                 FarmerId = a.FarmerId,
                                 CropImage = b.CropImage,
                                 FarmerAddress = c.UserAddress,
                                 FarmerName = c.UserName,
                                 FarmerPhnumber = c.UserPhnumber
                             });

                List<ViewCrop> list1 = query.ToList();


                return list1;
            }
            catch (Exception ex)
            {
                string causedAt = "Error casued At View crops in  ViewCropsAsync";
                _exception.AddException(ex, causedAt);

                return null;
            }
            finally
            {

            }


        }
        #endregion


        #region ViewFarmerCrops
        /// <summary>
        /// this method is used to view the crops posted by the famers
        /// </summary>
        /// <returns></returns>


        public List<ViewCrop> ViewFarmerCropsAsync(UserId id)
        {
            try
            {

                var query = (from a in _context.CropOnSales
                             where id.Id == a.FarmerId
                             join b in _context.Crops on a.CropId equals b.CropId

                             select new ViewCrop()
                             {
                                 CropAdId = a.CropAdId,
                                 CropName = a.CropName,
                                 CropType = a.CropType,
                                 CropQty = a.CropQty,
                                 CropPrice = a.CropPrice,
                                 CropImage = b.CropImage,

                             });

                List<ViewCrop> list1 = query.ToList();


                return list1;
            }
            catch (Exception ex)
            {
                string causedAt = "Error casued At View crops in  ViewFarmerCropsAsync";
                _exception.AddException(ex, causedAt);
                return null;
            }
            finally
            {

            }


        }
        #endregion

    }
}
