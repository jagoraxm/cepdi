using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAppCepdi.Models;
using System.Text;

namespace WebAppCepdi.Controllers
{
    [Route("[controller]")]
    public class UploadFileController : Controller
    {
        private readonly ILogger<UploadFileController> _logger;

        public UploadFileController(ILogger<UploadFileController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> UploadFile(string uuid)
        {
            try
            {
                // Simulación de consumir un servicio SOA
                var client = new HttpClient();
                var content = new StringContent("{\"Id\": " + uuid + "}", Encoding.UTF8, "application/json");

                // Consumir el servicio SOA
                var response = await client.PostAsync("https://timbrador.cepdi.mx:8443/WSDemo/WS?WSDL", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    return Json(new { success = true, data = responseData });
                }
                else
                {
                    return Json(new { success = false, message = "Error al consumir el servicio SOA" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}