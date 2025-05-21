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
        public IActionResult ElencoDemanio(string provincia)
        {
            ///Demanio/ElencoDemanio?provincia=ancona per passare la provincia
            DemanioGetDataViewModel vm = new DemanioGetDataViewModel();
            if(provincia == null || provincia == "")
            {
                vm.DatiDemanio = _demanioService.DaiDati().Result;
            }
            else
            {
                vm.DatiDemanio = _demanioService.RicercaPerProvincia(provincia).Result;
            }
            return View(vm);
        }
    }
}
