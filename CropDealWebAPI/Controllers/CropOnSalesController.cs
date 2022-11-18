using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CropDealWebAPI.Models;
using CropDealWebAPI.Dtos.CropOnSale;
using AutoMapper;
using CropDealWebAPI.Service;
using Microsoft.AspNetCore.Authorization;

namespace CropDealWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CropOnSalesController : ControllerBase
    {
        private readonly CropOnSaleService _Service;

        private readonly IMapper mapper;

        public CropOnSalesController(CropOnSaleService service , IMapper mapper)
        {
            _Service = service;
            this.mapper = mapper;
        }

        // GET: api/CropOnSales
       [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCropOnSaleDto>>> GetCropOnSales()
        {
            try
            {

                var croponsale = await _Service.GetCropOnSale();
                var cropsDto = mapper.Map<IEnumerable<GetCropOnSaleDto>>(croponsale);
                return Ok(cropsDto);
            }
            catch (Exception ex)
            {
                throw;
            }

            finally
            {

            }
        }

        // GET: api/CropOnSales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCropOnSaleDto>> GetCropOnSale(int id)
        {
            try
            {

                var crop = await _Service.GetCropOnSaleById(id);

                if (crop == null)
                {
                    return NotFound();
                }
                var cropDto = mapper.Map<GetCropOnSaleDto>(crop);
                return cropDto;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            };
        }


        // POST: api/CropOnSales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Farmer")]
        [HttpPost]
        public async Task<ActionResult<CreateCropOnSaleDto>> PostCropOnSale(CreateCropOnSaleDto cropOnSale)
        {

            try
            {
                var crop = mapper.Map<CropOnSale>(cropOnSale);
                if (_Service == null)
                {
                    return Problem("Entity set 'CropDealContext.CropOnSales'  is null.");
                }
                var res = await _Service.CreateCropOnSale(crop);
                if (res == null)
                {
                    return BadRequest();
                }

                return CreatedAtAction("GetCropOnSales", new { id = crop.CropAdId }, crop);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally { }
        }

        // DELETE: api/CropOnSales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCropOnSale(int id)
        {
            try
            {
                if (_Service == null)
                {
                    return NotFound();
                }
                var crops = await _Service.GetCropOnSaleById(id);
                if (crops == null)
                {
                    return NotFound();
                }

                var result = _Service.DeleteCropOnSale(crops);
                if (result == null)
                {
                    return BadRequest();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
        }

        private bool CropOnSaleExists(int id)
        {
            try
            {
                return _Service.CropOnSaleExists(id);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
        }
    }
}
