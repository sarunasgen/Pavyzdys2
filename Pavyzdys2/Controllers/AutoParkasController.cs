using AutoParkas.Core.Contracts;
using AutoParkas.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Pavyzdys2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutoParkasController : ControllerBase
    {
        private readonly IAutoNuoma _autoParkasService;
        public AutoParkasController(IAutoNuoma autoParkasService)
        {
            _autoParkasService = autoParkasService;
        }
        [HttpGet("GautiVisusAuto")]
        public IActionResult GautiVisusAuto()
        {
            return Ok(_autoParkasService.GautiVisusAutomobilius());
        }
        [HttpGet("GautiVisusKlientus")]
        public IActionResult GautiVisusKlientus()
        {
            return Ok(_autoParkasService.GautiVisusKlientus());
        }
        [HttpPost("PridetiKlienta")]
        public IActionResult PridetiKlienta(Klientas klientas)
        {
            _autoParkasService.PridetiKlienta(klientas);
            return Ok("Klientas sekmingai pridetas");
        }
        [HttpPost("PridetiAutomobili")]
        public IActionResult PridetiAutomobili(Automobilis automobilis)
        {
            _autoParkasService.PridetiAutomobili(automobilis);
            return Ok("Automobilis sekmingai pridetas");
        }
    }
}
