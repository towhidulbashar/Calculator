using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Calculator.Resource;
using Calculator.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CalculateController : ControllerBase
    {
        private readonly ICalculationHistoryService calculationHistoryService;

        public CalculateController(ICalculationHistoryService calculationHistoryService)
        {
            this.calculationHistoryService = calculationHistoryService;
        }
        [HttpPost("sum")]
        public async Task<IActionResult> Sum([FromBody] SumResource sumResource)
        {
            try
            {
                string result = calculationHistoryService.GetSum(sumResource.FirstNumber, sumResource.SecondNumber);
                await calculationHistoryService.SaveAsync(sumResource, result);
                return Ok(result);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }



        [HttpGet("summation-result")]
        public async Task<IActionResult> GetSummationResult()
        {
            try
            {
                var result = await calculationHistoryService.GetSummationResult();
                return Ok(result);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}