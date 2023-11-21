
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UrlShortener.Data;
using UrlShortener.Services;
using Microsoft.AspNetCore.Authorization;

namespace UrlShortener.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class URLController : ControllerBase
    {
        private readonly UrlShortenerContext _context;
        private readonly UrlServices _services;
        public URLController(UrlShortenerContext context, UrlServices services)
        {
            _context = context;
            _services = services;
        }

        [HttpPost]
        public IActionResult POSTURL([FromBody] string URLUser, [FromQuery] string? Categoria)
        {

            int IdUser = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);



            if (URLUser.Length > 6) //codigo para ver si es mayor a 6 digitos
            {
                if (_context.URLs.Any(u => u.UrlLong == URLUser))    //codigo para ver si esta en la base de datos
                {

                    int contador = _services.SumarContador(URLUser);
                    return Ok(contador);

                }
                else
                {

                    string ShortURL = _services.CrearShortUrl(URLUser);
                    _services.GuardarURL(URLUser, ShortURL, Categoria, IdUser);

                    return Ok(ShortURL);
                }

            }
            else
            {
                if (_context.URLs.Any(u => u.UrlShort == URLUser))
                {
                    string URLLong = _services.GetURLLongForShort(URLUser);
                    int contador = _services.SumarContador(URLUser);
                    return Ok(URLLong);
                }
                else return BadRequest("La URL no se encuentra en la  base de datos.");
            }


        }

        [HttpGet]

        public IActionResult GetURL()
        {
            return Ok(_context.URLs.ToList());
        }


        [HttpGet("Urls-por-Usuario")]
        public IActionResult GetURLporUsuario()
        {
            int IdUser = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);



            return Ok(_services.GetUrlsPorUsuario(IdUser));
        }
    }
}
