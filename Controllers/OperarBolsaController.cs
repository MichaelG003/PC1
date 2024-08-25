using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PC1.Controllers
{
   
    public class OperarBolsaController : Controller
    {
        private readonly ILogger<OperarBolsaController> _logger;

        public OperarBolsaController(ILogger<OperarBolsaController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

    }

    public class OperarBolsa
    {
        public string? NombreApellido {get; set;}

        public string? Correo {get; set;}

        public DateTime? FecOp { get; set; }

        public string? Instrumento { get; set; }

        public decimal? MontoAbonar { get; set;}

    }
}