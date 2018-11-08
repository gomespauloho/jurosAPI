using Microsoft.AspNetCore.Mvc;
using jurosAPI.Services;

namespace jurosAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get([FromQuery] double valorinicial, [FromQuery] int meses)
        {
            JurosService jurosService = new JurosService();

            return jurosService.CalcularJurosComposto(valorinicial, meses).ToString();
        }
    }
}