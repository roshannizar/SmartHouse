using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHouse.Api.Dtos.Rents;
using SmartHouse.Api.Middleware;
using SmartHouse.Core.Models;
using SmartHouse.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHouse.Api.Controllers.V1
{
    [Route("api/rents")]
    [ApiController]
    public class RentController : BaseApiController
    {
        private readonly IRentService rentService;

        public RentController(IRentService rentService,IMapper mapper) : base(mapper)
        {
            this.rentService = rentService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentDto>>> GetWaterBills()
        {
            var rents = await rentService.GetAllAsync();
            return Ok(mapper.Map<IEnumerable<RentDto>>(rents));
        }


        [HttpPost]
        public async Task<ActionResult> Create(CreateRentDto rentDto)
        {
            var bill = mapper.Map<Rent>(rentDto);
            await rentService.CreateAsync(bill);
            return new JsonResult(new { message = "Rent created successfully !" }) { StatusCode = StatusCodes.Status201Created };
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> Update(UpdateRentDto rentDto)
        {
            var rent = mapper.Map<Rent>(rentDto);
            await rentService.UpdateAsync(rent);
            return new JsonResult(new { message = "Rent updated successfully" }) { StatusCode = StatusCodes.Status200OK };
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RentDto>> GetWaterBill(string id)
        {
            var rent = await rentService.GetAsync(id);
            return Ok(mapper.Map<RentDto>(rent));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string id)
        {
            await rentService.DeleteAsync(id);
            return new JsonResult(new { message = "Rent deleted successfully" }) { StatusCode = StatusCodes.Status200OK };
        }
    }
}
