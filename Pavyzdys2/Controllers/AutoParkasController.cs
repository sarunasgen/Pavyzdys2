using AutoParkas.Core.Contracts;
using AutoParkas.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

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
        [HttpGet("GautKlientaPagalId")]
        public IActionResult GautiKlientaPagalId(int klientoId)
        {
            return Ok(_autoParkasService.GautiKlientaPagalId(klientoId));
        }
        [HttpGet("GautiVisusKlientus")]
        public IActionResult GautiVisusKlientus()
        {
            return Ok(_autoParkasService.GautiVisusKlientus());
        }
        [HttpPost("PridetiKlienta")]
        public IActionResult PridetiKlienta(Klientas klientas)
        {
            try
            {
                _autoParkasService.PridetiKlienta(klientas);
                return Ok("Klientas sekmingai pridetas");
            }
            catch(Exception e)
            {
                Log.Error($"Nepavyko prideti kliento. Klaida: {e.Message}");
                return Problem();
            }
            
        }
        [HttpPost("PridetiAutomobili")]
        public IActionResult PridetiAutomobili(Automobilis automobilis)
        {
            _autoParkasService.PridetiAutomobili(automobilis);
            return Ok("Automobilis sekmingai pridetas");
        }
        [HttpGet("GautiKlientaPagalVardaPavarde")]
        public IActionResult GautiKlientaPagalVardaPavarde(string vardasPavarde)
        {
            return Ok(_autoParkasService.GautiKlientusPagalVardaPavarde(vardasPavarde));
        }
        [HttpDelete("IstrintiKlientaPagalId")]
        public IActionResult IstrintiKlientaPagalId(int klientoId)
        {
            if(_autoParkasService.IstrintiKlientaPagalId(klientoId))
            {
                Log.Information($"Klientas {klientoId} sekmingai istrintas");
                return Ok("Klientas istrintas sekmingai");
            }
            else
            {
                Log.Warning("Klientas buvo nerastas su id: " + klientoId);
                return NotFound("Klientas nerastas");
            }
            
        }
        [HttpGet("GautiKlientoVardaPavardePagalId")]
        public IActionResult GautiKlientoVardaPavardePagalId(int id)
        {
            Klientas klientas = _autoParkasService.GautiKlientaPagalId(id);
            try
            {
                return Ok(klientas.VardasPavarde);
            }
            catch(Exception e)
            {
                Log.Error($"Ivyko klaida {e.Message}");
                return NoContent();
            }
            
        }
    }
}
