using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHouse.Api.Dtos.WaterBills;
using SmartHouse.Api.Middleware;
using SmartHouse.Core.Models;
using SmartHouse.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHouse.Api.Controllers.V1
{
    [Route("api/waterbills")]
    [ApiController]
    public class WaterBillController : BaseApiController
    {
        private readonly IWaterBillService waterBillService;

        public WaterBillController(IWaterBillService waterBillService, IMapper mapper) : base(mapper)
        {
            this.waterBillService = waterBillService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WaterBillDto>>> GetWaterBills()
        { 
            var bills = await waterBillService.GetAllAsync();
            return Ok(mapper.Map<IEnumerable<WaterBillDto>>(bills));
        }


        [HttpPost]
        public async Task<ActionResult> Create(CreateWaterBillDto waterBillDto)
        {
            var bill = mapper.Map<WaterBill>(waterBillDto);
            await waterBillService.CreateAsync(bill);
            return new JsonResult(new { message = "Water bill created successfully !" }) { StatusCode = StatusCodes.Status201Created };
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> Update(UpdateWaterBillDto waterBillDto)
        {
            var bill = mapper.Map<WaterBill>(waterBillDto);
            await waterBillService.UpdateAsync(bill);
            return new JsonResult(new { message = "Water bill updated successfully" }) { StatusCode = StatusCodes.Status200OK };
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WaterBillDto>> GetWaterBill(string id) 
        {
            var bill = await waterBillService.GetAsync(id);
            return Ok(mapper.Map<WaterBillDto>(bill));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string id) 
        {
            await waterBillService.DeleteAsync(id);
            return new JsonResult(new { message = "Water bill deleted successfully" }) { StatusCode = StatusCodes.Status200OK };
        }
    }
}
