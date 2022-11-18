using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CropDealWebAPI.Models;
using CropDealWebAPI.Dtos.Crop;
using AutoMapper;
using CropDealWebAPI.Service;
using Microsoft.AspNetCore.Authorization;

namespace CropDealWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CropsController : ControllerBase
    {
        private readonly CropService _Service;
        private readonly IMapper mapper;

        public CropsController(CropService service, IMapper mapper)
        {
            _Service = service;
            this.mapper = mapper;
        }

        // GET: api/Crops
        [Authorize(Roles = "Farmer")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCropDto>>> GetCrops()
        {

            try
            {

                var crops = await _Service.GetCrop();
                var cropsDto = mapper.Map<IEnumerable<GetCropDto>>(crops);
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

        // GET: api/Crops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCropDto>> GetCrop(int id)
        {
            try
            {

                var crop = await _Service.GetCropById(id);

                if (crop == null)
                {
                    return NotFound();
                }
                var cropDto = mapper.Map<GetCropDto>(crop);
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


        // POST: api/Crops
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
   
        [HttpPost]
        public async Task<ActionResult<CreateCropDto>> PostCrop(CreateCropDto cropDto)
        {
            try
            {
                var crop = mapper.Map<Crop>(cropDto);
                if (_Service == null)
                {
                    return Problem("Entity set 'CropDealContext.Crops'  is null.");
                }
                var res = await _Service.CreateCrop(crop);
                if (res == null)
                {
                    return BadRequest();
                }

                return CreatedAtAction("GetCrop", new { id = crop.CropId }, crop);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally { }
        }

        // DELETE: api/Crops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCrop(int id)
        {
            try
            {
                if (_Service == null)
                {
                    return NotFound();
                }
                var crops = await _Service.GetCropById(id);
                if (crops == null)
                {
                    return NotFound();
                }

                var result = _Service.DeleteCrop(crops);
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

        private bool CropExists(int id)
        {
            try
            {
                return _Service.CropExists(id);
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
