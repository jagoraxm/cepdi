using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPICepdi.Data;

namespace WebAPICepdi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<UsuariosController> _logger;
        private readonly DataContext _context;
        public LoginController(ILogger<UsuariosController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost("Authenticate")]
        public JsonResult Authenticate([FromBody] LoginRequest request)
        {
            // Busca al usuario con las credenciales proporcionadas
            var user = _context.Usuarios.FirstOrDefault(u => u.usuario == request.Username && u.password == request.Password);

            // Devuelve true si existe, de lo contrario false
            return new JsonResult(user != null);
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}