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
        public async Task<IActionResult> ElencoDemanio(string provincia)
        {
            ///Demanio/ElencoDemanio?provincia=ancona per passare la provincia
            DemanioElencoDemanioViewModel vm = new DemanioElencoDemanioViewModel();
            if (provincia == null || provincia == "")
            {
                vm.DatiDemanio = await _demanioService.GetData();
            }
            else
            {
                vm.DatiDemanio = _demanioService.RicercaPerProvincia(provincia).Result;
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