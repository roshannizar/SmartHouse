using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHouse.Api.Dtos.Garbages;
using SmartHouse.Api.Middleware;
using SmartHouse.Core.Models;
using SmartHouse.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHouse.Api.Controllers.V1
{
    [Route("api/garbages")]
    [ApiController]
    public class GarbageController : BaseApiController
    {
        private readonly IGarbageService garbageService;

        public GarbageController(IMapper mapper,IGarbageService garbageService) : base(mapper)
        {
            this.garbageService = garbageService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GarbageDto>>> GetGarbages()
        {
            var garbages = await garbageService.GetAllAsync();
            return Ok(mapper.Map<IEnumerable<GarbageDto>>(garbages));
        }


        [HttpPost]
        public async Task<ActionResult> Create(CreateGarbageDto garbageDto)
        {
            var garbage = mapper.Map<Garbage>(garbageDto);
            await garbageService.CreateAsync(garbage);
            return new JsonResult(new { message = "Garbage created successfully !" }) { StatusCode = StatusCodes.Status201Created };
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> Update(UpdateGarbageDto garbageDto)
        {
            var garbage = mapper.Map<Garbage>(garbageDto);
            await garbageService.UpdateAsync(garbage);
            return new JsonResult(new { message = "Garbage updated successfully" }) { StatusCode = StatusCodes.Status200OK };
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GarbageDto>> GetGarbage(string id)
        {
            var garbage = await garbageService.GetAsync(id);
            return Ok(mapper.Map<GarbageDto>(garbage));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string id)
        {
            await garbageService.DeleteAsync(id);
            return new JsonResult(new { message = "Rent deleted successfully" }) { StatusCode = StatusCodes.Status200OK };
        }
    }
}
