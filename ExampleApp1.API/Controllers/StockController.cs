using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ExampleApp1.API.Entity;
using ExampleApp1.API.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExampleApp1.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;


        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStock()
        {

            return Ok(await _stockService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddStock(Stock stock)
        {
            await _stockService.AddAsync(stock);
            return Ok();
        }


        [HttpGet("[action]")]

        public async Task<IActionResult> GetUserByIdStock()
        {
            
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

            var userStocks= await _stockService.Where(x => x.UserId == userIdClaim.Value);

            return Ok(userStocks);
        }
    }
}
