using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Threading.Tasks;

namespace BL.Sample.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DistributedCacheController : ControllerBase
    {
        private readonly IDistributedCache _distributedCache;

        public DistributedCacheController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _distributedCache.GetStringAsync("BLSampleKey");

                return Ok(result);
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            await _distributedCache.SetStringAsync("BLSampleKey", "Welcome To BonnyLand Framework");

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            await _distributedCache.RemoveAsync("BLSampleKey");

            return Ok();
        }
    }
}
