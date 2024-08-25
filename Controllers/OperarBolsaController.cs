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

        [HttpPost]
        public IActionResult Operar(OperarBolsa operadorBolsa)
        {
            if (ModelState.IsValid)
            {
                decimal comision = operadorBolsa.MontoAbonar <= 300 ? 1m : 3m;
                decimal totalIGV = 0m;
                decimal totalMonto = 0m;

                List<InstrumentoDetalle> detalles = new List<InstrumentoDetalle>();

                if (operadorBolsa.Instrumento != null)
                {
                    foreach (var instrumento in operadorBolsa.Instrumento)
                    {
                        decimal monto = 0m;
                        if (instrumento == "S&P 500")
                        {
                            monto = 500m;
                        }
                        else if (instrumento == "Dow Jones")
                        {
                            monto = 300m;
                        }
                        else if (instrumento == "Bonos US")
                        {
                            monto = 120m;
                        }

                        var igv = monto * 0.18m;
                        totalMonto += monto;
                        totalIGV += igv;

                        detalles.Add(new InstrumentoDetalle { Nombre = instrumento, IGV = igv, Monto = monto });
                    }
                }

                decimal total = totalMonto + totalIGV + comision;

                ViewBag.Detalles = detalles;
                ViewBag.Comision = comision;
                ViewBag.Total = total;

                return View("Index");
            }

            return View(operadorBolsa);
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

        public List<string>? Instrumento { get; set; }

        public decimal? MontoAbonar { get; set;}

    }

    public class InstrumentoDetalle
    {
        public string? Nombre { get; set; }
        public decimal? IGV { get; set; }
        public decimal? Monto { get; set; }
    }
}