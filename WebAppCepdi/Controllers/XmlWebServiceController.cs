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
    public class XmlWebServiceController : Controller
    {
        private readonly ILogger<XmlWebServiceController> _logger;

        public XmlWebServiceController(ILogger<XmlWebServiceController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        
    }
}