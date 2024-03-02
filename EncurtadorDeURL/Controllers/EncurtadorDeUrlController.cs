using EncurtadorDeUrlLibrary.Models;
using EncurtadorDeUrlLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace EncurtadorDeURL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EncurtadorDeUrlController : ControllerBase
    {
        private readonly EncurtadorDeUrlService _encurtadorDeUrlService;
        private readonly IConfiguration _configuration;

        public EncurtadorDeUrlController(IConfiguration configuration, EncurtadorDeUrlService encurtadorDeUrlService)
        {
            _configuration = configuration;
            _encurtadorDeUrlService = encurtadorDeUrlService;
        }

        [HttpPost]
        public IActionResult PostEncurtadorUrl([FromBody] string url)
        {
            var encurtador = _encurtadorDeUrlService.Encurtar(url);
            _encurtadorDeUrlService.AddEncurtadorDeUrl(encurtador);
            return Ok(encurtador);
        }

        [HttpGet]
        public IActionResult GetEncurtadorUrl()
        {
            return Ok(_encurtadorDeUrlService.GetAll());
        }

        [HttpGet("{urlCurta}")]
        public IActionResult GetEncurtadorUrl(string urlCurta)
        {
            var encurtador = _encurtadorDeUrlService.GetEncurtadorDeUrl(urlCurta);
            if (encurtador == null)
            {
                return NotFound();
            }
            return Ok(encurtador);
        }

        //acessar o endereço através da url curta
        [HttpGet("acesso/{urlCurta}")]
        public IActionResult AcessarUrlCurta(string urlCurta)
        {
            var encurtador = _encurtadorDeUrlService.GetEncurtadorDeUrl(urlCurta);
            if (encurtador == null)
            {
                return NotFound();
            }
            return Redirect(encurtador.UrlOriginal);
        }

    }
}
