using System.Threading.Tasks;
using DecomposeNumber.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace DecomposeNumber.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumberController : ControllerBase
    {
        private readonly INumberService _numberService;

        public NumberController(INumberService numberService)
        {
            _numberService = numberService;
        }
        
        [HttpGet("Details/{number:int}")]
        public async Task<IActionResult> Get([FromRoute] int number)
        {
            return await _numberService.GetDetails(number);
        }
    }
}