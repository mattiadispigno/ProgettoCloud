using Application.Abstractions.Services;
using Demanio.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Demanio.Controllers
{
    public class DemanioController : Controller
    {
        private readonly IDemanioService _demanioService;
        public DemanioController(IDemanioService demanioService)
        {
            _demanioService = demanioService;
        }

        [HttpGet]
        public async Task<IActionResult> ElencoDemanio([FromQuery] string provincia, [FromQuery] string regione)
        {
            DemanioElencoDemanioViewModel vm = new DemanioElencoDemanioViewModel();
            if (string.IsNullOrEmpty(provincia)&& string.IsNullOrEmpty(regione))
            {
                vm.DatiDemanio = await _demanioService.GetData();
            }
            else if (string.IsNullOrEmpty(provincia)) //se è stata inserita solo la regione
            {
                vm.DatiDemanio = await _demanioService.RicercaPerRegione(regione);   
            }
            else //se la provincia è stata inserita, indipendentemente dalla regione 
            {
                vm.DatiDemanio = await _demanioService.RicercaPerProvincia(provincia);
            }
            
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> ElencoDemanioTotal()
        {
            DemanioElencoDemanioTotalViewModel vm = new DemanioElencoDemanioTotalViewModel();
            vm.DatiDemanioTotal = await _demanioService.GetDataWithTotal();
            return View(vm);
        }
    }
}