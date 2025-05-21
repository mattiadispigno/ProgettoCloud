using Application.Abstractions.Services;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SoapService : ISoapService
    {
        private readonly IDemanioService _demanioService;
        public SoapService(IDemanioService demanioService)
        {
            _demanioService = demanioService;
        }
        public DatoDemanio[] GetData()
        {
            return _demanioService.DaiDati().Result;
        }

        public DatoDemanio[] GetDataByProvincia(string provincia)
        {
            return _demanioService.RicercaPerProvincia(provincia).Result;
        }
    }
}
