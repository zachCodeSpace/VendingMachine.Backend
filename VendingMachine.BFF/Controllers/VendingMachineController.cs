using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VendingMachine.BFF.Models;
using VendingMachine.BFF.Services.Interfaces;
using ZstdSharp.Unsafe;

namespace VendingMachine.BFF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendingMachineController : ControllerBase
    {
        private readonly IVendService _vendService;
        public VendingMachineController(IVendService vendService)
        {
            _vendService = vendService;
        }

        [HttpGet("GetSnackOptions")]
        public async Task<IActionResult> GetSnackOptions()
        {
            try
            {
                return Ok(await _vendService.GetSnacks());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("PurchaseSnack")]
        public async Task<IActionResult> PurchaseSnack([FromBody] PurchaseRequest purchase)
        {
            try
            {
                var result = await _vendService.PurchaseSnack(purchase.SnackId, purchase.AmountPaid);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
