using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHouse.Api.Dtos.Utilities;
using SmartHouse.Api.Middleware;
using SmartHouse.Core.Models;
using SmartHouse.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHouse.Api.Controllers.V1
{
    [Route("api/v1/utilities")]
    [ApiController]
    public class UtilityController : BaseApiController
    {
        private readonly IUtilitiesService utilitiesService;

        public UtilityController(IUtilitiesService utilitiesService,IMapper mapper) : base(mapper)
        {
            this.utilitiesService = utilitiesService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UtilityDto>>> GetUtilities()
        {
            var utilities = await utilitiesService.GetAllAsync();
            return Ok(mapper.Map<IEnumerable<UtilityDto>>(utilities));
        }


        [HttpPost]
        public async Task<ActionResult> Create(CreateUtilityDto utilityDto)
        {
            var utility = mapper.Map<Utility>(utilityDto);
            await utilitiesService.CreateAsync(utility);
            return new JsonResult(new { message = "Utility created successfully !" }) { StatusCode = StatusCodes.Status201Created };
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> Update(UpdateUtilityDto utilityDto)
        {
            var utility = mapper.Map<Utility>(utilityDto);
            await utilitiesService.UpdateAsync(utility);
            return new JsonResult(new { message = "Utility updated successfully" }) { StatusCode = StatusCodes.Status200OK };
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UtilityDto>> GetGarbage(string id)
        {
            var utility = await utilitiesService.GetAsync(id);
            return Ok(mapper.Map<UtilityDto>(utility));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string id)
        {
            await utilitiesService.DeleteAsync(id);
            return new JsonResult(new { message = "Utility deleted successfully" }) { StatusCode = StatusCodes.Status200OK };
        }


    }
}
