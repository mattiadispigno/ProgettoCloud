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
        public async Task<IActionResult> ElencoDemanio([FromQuery] string provincia = null)
        {
            DatoDemanio[] result;
            if (string.IsNullOrWhiteSpace(provincia))
            {
                result = await _demanioService.GetData();
            }
            else
            {
                result = await _demanioService.RicercaPerProvincia(provincia);
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
