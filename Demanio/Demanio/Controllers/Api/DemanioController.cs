using Application.Abstractions.Services;
using Application.Factories;
using Demanio.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace Demanio.Controllers.Api
{
    [Route("api/")]
    [ApiController]
    public class DemanioController : ControllerBase
    {
        private readonly IDemanioService _demanioService;
        public DemanioController(IDemanioService demanioService)
        {
            _demanioService = demanioService;
        }


        [HttpGet]
        [Route("demanio")]
        public async Task<IActionResult> ElencoDemanio([FromQuery] string provincia = null, [FromQuery] string regione = null)
        {
            DatoDemanio[] result;
            if (string.IsNullOrEmpty(provincia)&& string.IsNullOrEmpty(regione))
            {
                result = await _demanioService.GetData();
            }
            else if (string.IsNullOrEmpty(provincia)) //se è stata inserita solo la regione
            {
                result = await _demanioService.RicercaPerRegione(regione);   
            }
            else //se la provincia è stata inserita, indipendentemente dalla regione 
            {
                result = await _demanioService.RicercaPerProvincia(provincia);
            }
            

            return Ok(ResponseFactory.WithSuccess(result.ToList()));
        }

        [HttpGet]
        [Route("demanioregione")]
        public async Task<IActionResult> ElencoDemanioPerRegione([FromQuery] string regione = null)
        {
            DatoDemanio[] result;
            if (string.IsNullOrWhiteSpace(regione) )
            {
                result = await _demanioService.GetData();
            }
            else
            {
                result = await _demanioService.RicercaPerRegione(regione);
            }
            
            return Ok(ResponseFactory.WithSuccess(result.ToList()));
            
        }

        [HttpGet]
        [Route("demanio/total")]
        public async Task<IActionResult> ElencoDemanioTotal()
        {
            var result =  await _demanioService.GetDataWithTotal();
            return Ok(
                ResponseFactory
                .WithSuccess(
                    result
                    .ToList()
                    )
            );
        }
    }
}
