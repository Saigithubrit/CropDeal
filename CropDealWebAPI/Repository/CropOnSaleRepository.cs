using CropDealWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CropDealWebAPI.Repository
{
    public class CropOnSaleRepository : IRepository<CropOnSale, int>
    {
        CropDealContext _context;
        ExceptionRepositry _exception;
        public CropOnSaleRepository(CropDealContext context, ExceptionRepositry exception)
        {
            _context = context;
            _exception = exception;

        }


        #region PostCropOnSale
        /// <summary>
        /// this method is used by farmers to put their  crops on Sale
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<int> CreateAsync(CropOnSale item)
        {
            try
            {
                _context.CropOnSales.Add(item);
                await _context.SaveChangesAsync();
                var response = StatusCodes.Status201Created;
                return response;
            }
            catch (Exception ex)
            {
                string causedAt = "Error casued At cropOnSaleRepository in  CreateAsync";
                _exception.AddException(ex, causedAt);
            }


            finally
            {

            }
            return 404;
        }
        #endregion

        #region DeleteCrops
        /// <summary>
        /// this method is used to delete crops on sale
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>

        public async Task<int> DeleteAsync(CropOnSale item)
        {
            try
            {
                _context.CropOnSales.Remove(item);
                await _context.SaveChangesAsync();
                var response = StatusCodes.Status200OK;
                return response;
            }
            catch (Exception ex)
            {
                string causedAt = "Error casued At CropOnSaleRepository in  DeleteAsync";
                _exception.AddException(ex, causedAt);
            }


            finally
            {

            }
            return 404;
        }
        #endregion

        #region CropExists
        /// <summary>
        /// Used check wheather crops Exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Exists(int id)
        {
            try
            {
                return (_context.CropOnSales?.Any(e => e.CropAdId == id)).GetValueOrDefault();
            }
            catch (Exception ex)
            {
                string causedAt = "Error casued At cropOnSaleRepository in  Exists";
                _exception.AddException(ex, causedAt);

            }
            finally
            {

            }
            return false;
        }
        #endregion

        #region GetAllCrops
        /// <summary>
        /// this method is used to get all crops
        /// </summary>
        /// <returns></returns>

        public async Task<IEnumerable<CropOnSale>> GetAsync()
        {
            try
            {
                return await _context.CropOnSales.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                string causedAt = "Error casued At cropOnSaleRepository in  GetAsync";
                _exception.AddException(ex, causedAt);

            }
            finally
            {

            }
            return null;
        }
        #endregion

        #region GetCropsbyId
        /// <summary>
        /// this method is used to get crops by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CropOnSale> GetIdAsync(int id)
        {
            try
            {
                return await _context.CropOnSales
                     .AsNoTracking()
                     .FirstOrDefaultAsync(c => c.CropAdId == id);
            }
            catch (Exception ex)
            {

                string causedAt = "Error casued At cropOnSaleRepository in  GetIdAsync";
                _exception.AddException(ex, causedAt);

                return null;
            }
            finally
            {

            }
        }
        #endregion

        #region UpdateCrops
        /// <summary>
        /// update crops 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>

        public async Task<int> UpdateAsync(CropOnSale item)
        {
            try
            {
                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                var response = StatusCodes.Status200OK;
                return response;
            }
            catch (Exception ex)
            {
                string causedAt = "Error casued At cropOnSaleRepository in  UpdateAsync";
                _exception.AddException(ex, causedAt);
                return 404;
            }

            finally
            {

            }
        }
        #endregion
    }
}
