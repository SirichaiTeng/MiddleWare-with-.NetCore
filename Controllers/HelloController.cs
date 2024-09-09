using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiddleWare_with_.NetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {

        [HttpGet]
        [Route("getHello")]
        public IActionResult GetHello()
        {
            string result = "hello";
            return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(result));
        }
    }
}
