using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAppCepdi.Controllers
{
    [Route("[controller]")]
    public class MedicamentosController : Controller
    {
        private readonly ILogger<MedicamentosController> _logger;

        public MedicamentosController(ILogger<MedicamentosController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}