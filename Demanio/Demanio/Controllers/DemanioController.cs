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

        public IActionResult ElencoDemanio()
        {
            DemanioGetDataViewModel vm = new DemanioGetDataViewModel();
            vm.DatiDemanio =  _demanioService.DaiDati().Result;
            return View(vm);
        }
    }
}
